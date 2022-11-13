using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Swsk33.PaimonVirus.Config;
using Swsk33.ReadAndWriteSharp.FileUtil;

namespace Swsk33.PaimonVirus
{
	static class Program
	{
		/// <summary>
		/// 启动控制台
		/// </summary>
		/// <returns></returns>
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		/// <summary>
		/// 释放控制台
		/// </summary>
		/// <returns></returns>
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

		private static bool IsArrayContains(string[] array, string value)
		{
			bool isContain = false;
			foreach (string s in array)
			{
				if (s.Equals(value))
				{
					isContain = true;
					break;
				}
			}
			return isContain;
		}

		/// <summary>
		/// 初始化资源
		/// </summary>
		private static void initResource()
		{
			BinaryUtils.ExtractNormalFileInResx(MainResource.WavPlayer, CommonValue.TEMP_PATH + "wp.exe");
			BinaryUtils.ExtractAudioFileInResx(MainResource.zh, CommonValue.TEMP_PATH + "zh.wav");
			BinaryUtils.ExtractAudioFileInResx(MainResource.jp, CommonValue.TEMP_PATH + "jp.wav");
			BinaryUtils.ExtractAudioFileInResx(MainResource.ko, CommonValue.TEMP_PATH + "ko.wav");
			BinaryUtils.ExtractAudioFileInResx(MainResource.en, CommonValue.TEMP_PATH + "en.wav");
		}

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (IsArrayContains(args, "-h"))
			{
				AllocConsole();
				Console.WriteLine("派蒙病毒 [版本 v1.1.3]\r\n\r\n食用方法：\r\n直接打开exe程序（日文语音，线性增长）\r\n\r\n命令行参数运行：\r\n派蒙病毒 [-l] [语言] [-i] [增长方式]\r\n派蒙病毒 -h   显示此帮助\r\n派蒙病毒 -v   显示版本信息\r\n\r\n语言：\r\nzh 中文语音     jp 日文语音（默认）\r\nen 英文语音     ko 韩文语音\r\n\r\n增长方式：\r\nlinear 线性增长（默认）\r\nindex 指数增长\r\nrandom 随机增长\r\n\r\n例如：\r\n派蒙病毒 -l jp -i index     使用日文语音指数增长\r\n\r\n两个参数可以只取其一，未规定的参数按照默认值执行！");
				Console.WriteLine("\r\n按任意键退出。");
				_ = Console.ReadLine();
			}
			else if (IsArrayContains(args, "-v"))
			{
				AllocConsole();
				Console.WriteLine("派蒙病毒 [版本 v2.1.3]\r\n项目网址：https://gitee.com/swsk33/PaimonVirus\r\n娱乐性的派蒙病毒。\r\n“诶嘿”\r\n“诶嘿是什么意思啊？”");
				Console.WriteLine("\r\n按任意键退出。");
				_ = Console.ReadLine();
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				string lang = "jp";
				string increase = "linear";
				if (IsArrayContains(args, "-l"))
				{
					int index = Array.IndexOf(args, "-l");
					if (index < args.Length)
					{
						lang = args[index + 1];
					}
				}
				if (IsArrayContains(args, "-i"))
				{
					int index = Array.IndexOf(args, "-i");
					if (index < args.Length)
					{
						increase = args[index + 1];
					}
				}
				if (args.Length != 0)
				{
					Application.Run(new Main(lang, increase));
				}
				else
				{
					Application.Run(new Main());
				}
			}
		}
	}
}