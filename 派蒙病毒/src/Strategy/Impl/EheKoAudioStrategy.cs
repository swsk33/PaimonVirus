using Swsk33.PaimonVirus.Config;
using Swsk33.PaimonVirus.Util;

namespace Swsk33.PaimonVirus.Strategy.Impl
{
	/// <summary>
	/// 诶嘿-韩文语音
	/// </summary>
	public class EheKoAudioStrategy : AudioStrategy
	{
		public void PlayAudio()
		{
			AudioUtils.Play(CommonValue.TEMP_PATH + "ko.wav");
		}
	}
}