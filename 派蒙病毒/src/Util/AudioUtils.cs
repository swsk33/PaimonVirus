using Swsk33.PaimonVirus.Config;
using Swsk33.ReadAndWriteSharp.System;
using Swsk33.ReadAndWriteSharp.System.Result;
using Swsk33.ReadAndWriteSharp.Util;

namespace Swsk33.PaimonVirus.Util
{
	/// <summary>
	/// 音频实用类
	/// </summary>
	public class AudioUtils
	{
		/// <summary>
		/// 播放音频
		/// </summary>
		/// <param name="path">音频路径</param>
		public static void Play(string path)
		{
			TerminalResult result = new TerminalResult();
			TerminalUtils.RunCommandAsynchronously(CommonValue.TEMP_PATH + @"\wp.exe", StringUtils.SurroundByDoubleQuotes(path), result);
		}

	}
}