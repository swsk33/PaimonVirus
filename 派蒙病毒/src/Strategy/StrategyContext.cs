using Swsk33.PaimonVirus.Config;
using Swsk33.PaimonVirus.Strategy.Impl;
using System.Collections.Generic;

namespace Swsk33.PaimonVirus.Strategy
{
	/// <summary>
	/// 策略上下文
	/// </summary>
	public class StrategyContext
	{
		/// <summary>
		/// 音频策略
		/// </summary>
		private static readonly Dictionary<string, AudioStrategy> audioMap = new Dictionary<string, AudioStrategy>();

		static StrategyContext()
		{
			audioMap.Add("zh", new EheZhAudioStrategy());
			audioMap.Add("jp", new EheJpAudioStrategy());
			audioMap.Add("ko", new EheKoAudioStrategy());
			audioMap.Add("en", new EheEnAudioStrategy());
		}

		/// <summary>
		/// 传入配置对象以执行策略
		/// </summary>
		/// <param name="config">配置对象</param>
		public static void execute(MainConfig config)
		{
			if (audioMap.ContainsKey(config.Lang))
			{
				audioMap[config.Lang].PlayAudio();
			}
			else
			{
				audioMap["jp"].PlayAudio();
			}
		}
	}
}