namespace Swsk33.PaimonVirus.Config
{
	/// <summary>
	/// 主要配置对象
	/// </summary>
	public class MainConfig
	{
		private string lang = "jp";

		private string increase = "linear";

		/// <summary>
		/// 语言，中文zh，日文jp，英文en，韩文ko
		/// </summary>
		public string Lang { get => lang; set => lang = value; }

		/// <summary>
		/// 增长方式，分为线性(linear)、指数(index)和随机(random)
		/// </summary>
		public string Increase { get => increase; set => increase = value; }
	}
}