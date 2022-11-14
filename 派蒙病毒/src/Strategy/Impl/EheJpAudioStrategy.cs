using Swsk33.PaimonVirus.Config;
using Swsk33.PaimonVirus.Util;

namespace Swsk33.PaimonVirus.Strategy.Impl
{
	/// <summary>
	/// 诶嘿-日语语音
	/// </summary>
	public class EheJpAudioStrategy : AudioStrategy
	{
		public void PlayAudio()
		{
			AudioUtils.Play(CommonValue.TEMP_PATH + "jp.wav");
		}
	}
}