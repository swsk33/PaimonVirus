using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace PaimonVirus
{
    public partial class Main : Form
    {
        private static string TMP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Temp\\";
        /// <summary>
        /// 获取屏幕宽
        /// </summary>
        private static int width = Screen.PrimaryScreen.Bounds.Width;
        /// <summary>
        /// 获取屏幕高
        /// </summary>
        private static int height = Screen.PrimaryScreen.Bounds.Height;
        /// <summary>
        /// 每个窗口间隔
        /// </summary>
        private static int distance = 15;
        /// <summary>
        /// 最大窗口数量
        /// </summary>
        private static int max = (width / distance) * (height / distance);
        /// <summary>
        /// 语言，中文zh，日文jp，英文en，韩文ko
        /// </summary>
        private static string lang = "jp";
        /// <summary>
        /// 增长方式，分为线性(linear)、指数(index)和随机(random)
        /// </summary>
        private static string increase = "linear";
        /// <summary>
        /// 储存位置的列表
        /// </summary>
        private static List<int[]> locations = new List<int[]>();

        /// <summary>
        /// 释放resx里面的普通类型文件
        /// </summary>
        /// <param name="resource">resx里面的资源</param>
        /// <param name="path">释放到的路径</param>
        private void ExtractNormalFileInResx(byte[] resource, String path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            file.Write(resource, 0, resource.Length);
            file.Flush();
            file.Close();
        }

        /// <summary>
        /// 释放resx文件里面的音频资源文件
        /// </summary>
        /// <param name="fileInResx">在resx里面的音频文件</param>
        /// <param name="path">释放到的路径</param>
        private void ExtractAudioFileInResx(Stream fileInResx, String path)
        {
            Stream input = fileInResx;
            FileStream output = new FileStream(path, FileMode.Create);
            byte[] data = new byte[1024];
            int lengthEachRead;
            while ((lengthEachRead = input.Read(data, 0, data.Length)) > 0)
            {
                output.Write(data, 0, lengthEachRead);
            }
            output.Flush();
            output.Close();
        }

        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="audioLang">声音语言</param>
        private void PlaySound(string audioLang)
        {
            string filePath;
            switch (audioLang)
            {
                case "zh":
                    filePath = TMP_PATH + "zh.wav";
                    break;
                case "jp":
                    filePath = TMP_PATH + "jp.wav";
                    break;
                case "en":
                    filePath = TMP_PATH + "en.wav";
                    break;
                case "ko":
                    filePath = TMP_PATH + "ko.wav";
                    break;
                default:
                    filePath = TMP_PATH + "zh.wav";
                    break;
            }
            new Thread(() =>
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine("\"" + TMP_PATH + "WavPlayer.exe\" \"" + filePath + "\"");
                process.WaitForExit();
            }).Start();
        }

        /// <summary>
        /// 异步延迟
        /// </summary>
        /// <param name="waitTime">延迟时间(s)</param>
        private void DelayAsync(int waitTime)
        {
            DateTime nowTimer = DateTime.Now;
            int interval = 0;
            while (interval < waitTime)
            {
                Application.DoEvents();
                TimeSpan spand = DateTime.Now - nowTimer;
                interval = spand.Seconds;
            }
        }

        /// <summary>
        /// 计算并设定每个窗口位置（防止位置重叠）
        /// </summary>
        /// <param name="n">计算n次</param>
        /// <returns></returns>
        private void SetLocation(int n)
        {
            int x, y;
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int[] point = new int[2];
                x = rand.Next(0, width - 132);
                y = rand.Next(0, height - 206);
                for (int j = 0; j < locations.Count; j++)
                {
                    int[] eachPoint = locations[j];
                    if (n > max)
                    {
                        break;
                    }
                    if (Math.Abs(x - eachPoint[0]) < distance && Math.Abs(y - eachPoint[1]) < distance)
                    {
                        SetLocation(n - locations.Count);
                    }
                }
                point[0] = x;
                point[1] = y;
                locations.Add(point);
            }
        }

        /// <summary>
        /// 显示派蒙
        /// </summary>
        /// <param name="n">一次显示n个</param>
        private void ShowPaimon(int n)
        {
            locations.Clear();
            SetLocation(n);
            for (int i = 0; i < n; i++)
            {
                int[] eachPoint = locations[i];
                new Paimon(eachPoint[0], eachPoint[1]).Show();
                Application.DoEvents();
                PlaySound(lang);
            }
        }

        public Main()
        {
            ExtractNormalFileInResx(MainResource.WavPlayer, TMP_PATH + "WavPlayer.exe");
            ExtractAudioFileInResx(MainResource.zh, TMP_PATH + "zh.wav");
            ExtractAudioFileInResx(MainResource.jp, TMP_PATH + "jp.wav");
            ExtractAudioFileInResx(MainResource.en, TMP_PATH + "en.wav");
            ExtractAudioFileInResx(MainResource.ko, TMP_PATH + "ko.wav");
            InitializeComponent();
        }

        public Main(string lang, string increase)
        {
            Main.lang = lang;
            Main.increase = increase;
            ExtractNormalFileInResx(MainResource.WavPlayer, TMP_PATH + "WavPlayer.exe");
            ExtractAudioFileInResx(MainResource.zh, TMP_PATH + "zh.wav");
            ExtractAudioFileInResx(MainResource.jp, TMP_PATH + "jp.wav");
            ExtractAudioFileInResx(MainResource.en, TMP_PATH + "en.wav");
            ExtractAudioFileInResx(MainResource.ko, TMP_PATH + "ko.wav");
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            int n = 1;
            while (true)
            {
                ShowPaimon(n);
                if (increase.Equals("linear"))
                {
                    n++;
                }
                else if (increase.Equals("index"))
                {
                    n = n * 2;
                }
                else if (increase.Equals("random"))
                {
                    n = n + new Random().Next(0, 11);
                }
                else
                {
                    n++;
                }
                DelayAsync(2);
            }
        }
    }
}