using System;
using System.Windows.Forms;

namespace Swsk33.PaimonVirus.Config
{
	/// <summary>
	/// 常量列举值
	/// </summary>
	public class CommonValue
	{
		/// <summary>
		/// 系统缓存路径
		/// </summary>
		public static readonly string TEMP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Temp\";

		/// <summary>
		/// 屏幕宽
		/// </summary>
		public static readonly int SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;

		/// <summary>
		/// 屏幕高
		/// </summary>
		public static readonly int SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;

		/// <summary>
		/// 每个窗口间隔
		/// </summary>
		public static readonly int DISTANCE = 10;

		/// <summary>
		/// 最大窗口数量
		/// </summary>
		public static readonly int MAX_DIALOG_NUM = (SCREEN_WIDTH / DISTANCE) * (SCREEN_HEIGHT / DISTANCE);
	}
}