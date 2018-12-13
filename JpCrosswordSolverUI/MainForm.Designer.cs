namespace JpCrosswordSolverUI
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pbCrossWord = new System.Windows.Forms.PictureBox();
			this.MainPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pbCrossWord)).BeginInit();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbCrossWord
			// 
			this.pbCrossWord.Location = new System.Drawing.Point(3, 3);
			this.pbCrossWord.Name = "pbCrossWord";
			this.pbCrossWord.Size = new System.Drawing.Size(235, 187);
			this.pbCrossWord.TabIndex = 0;
			this.pbCrossWord.TabStop = false;
			// 
			// MainPanel
			// 
			this.MainPanel.AutoScroll = true;
			this.MainPanel.Controls.Add(this.pbCrossWord);
			this.MainPanel.Location = new System.Drawing.Point(12, 12);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(425, 426);
			this.MainPanel.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.MainPanel);
			this.Name = "MainForm";
			this.Text = "Jp crossword solver";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbCrossWord)).EndInit();
			this.MainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbCrossWord;
		private System.Windows.Forms.Panel MainPanel;
	}
}

