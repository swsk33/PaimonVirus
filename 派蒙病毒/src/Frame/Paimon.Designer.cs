
namespace Swsk33.PaimonVirus.Frame
{
    partial class Paimon
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paimon));
            this.BoxPaimon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BoxPaimon)).BeginInit();
            this.SuspendLayout();
            // 
            // BoxPaimon
            // 
            this.BoxPaimon.Image = global::Swsk33.PaimonVirus.MainResource.paimon;
            this.BoxPaimon.Location = new System.Drawing.Point(12, 12);
            this.BoxPaimon.Name = "BoxPaimon";
            this.BoxPaimon.Size = new System.Drawing.Size(132, 206);
            this.BoxPaimon.TabIndex = 0;
            this.BoxPaimon.TabStop = false;
            // 
            // Paimon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(155, 232);
            this.Controls.Add(this.BoxPaimon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Paimon";
            this.ShowInTaskbar = false;
            this.Text = "Paimon";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Paimon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BoxPaimon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BoxPaimon;
    }
}

