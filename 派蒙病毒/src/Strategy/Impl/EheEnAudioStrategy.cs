using Swsk33.PaimonVirus.Config;
using Swsk33.PaimonVirus.Util;

namespace Swsk33.PaimonVirus.Strategy.Impl
{
	/// <summary>
	/// 诶嘿-英文语音
	/// </summary>
	public class EheEnAudioStrategy : AudioStrategy
	{
		public void PlayAudio()
		{
			AudioUtils.Play(CommonValue.TEMP_PATH + "en.wav");
		}
	}
}