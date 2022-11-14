using Swsk33.PaimonVirus.Config;
using Swsk33.PaimonVirus.Util;
using Swsk33.ReadAndWriteSharp.FileUtil;
using System;
using System.Windows.Forms;

namespace Swsk33.PaimonVirus
{
	static class Program
	{
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

		private static MainConfig getCommandArgs(string[] args)
		{
			MainConfig config = new MainConfig();
			int languageIndex = Array.IndexOf(args, "-l"), increaseIndex = Array.IndexOf(args, "-i");
			if (languageIndex != -1 && languageIndex != args.Length - 1)
			{
				config.Lang = args[languageIndex + 1].ToLower();
			}
			if (increaseIndex != -1 && increaseIndex != args.Length - 1)
			{
				config.Increase = args[increaseIndex + 1].ToLower();
			}
			return config;
		}

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			initResource();
			MainConfig config = getCommandArgs(args);
			
			Application.Run();
		}
	}
}