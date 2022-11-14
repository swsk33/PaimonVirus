﻿using Swsk33.PaimonVirus.Config;
using Swsk33.PaimonVirus.Util;

namespace Swsk33.PaimonVirus.Strategy.Impl
{
	/// <summary>
	/// 诶嘿-中文语音
	/// </summary>
	public class EheZhAudioStrategy : AudioStrategy
	{
		public void PlayAudio()
		{
			AudioUtils.Play(CommonValue.TEMP_PATH + "zh.wav");
		}
	}
}