namespace Empire
{
	partial class RepairWallForm
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
			this.components = new System.ComponentModel.Container();
			this.pictureBoxWall = new System.Windows.Forms.PictureBox();
			this.timerMain = new System.Windows.Forms.Timer(this.components);
			this.timerBrickPosition = new System.Windows.Forms.Timer(this.components);
			this.labelCounter = new System.Windows.Forms.Label();
			this.pictureBoxBrick = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWall)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrick)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxWall
			// 
			this.pictureBoxWall.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxWall.Image = global::Empire.Properties.Resources.sciana;
			this.pictureBoxWall.Location = new System.Drawing.Point(1, -1);
			this.pictureBoxWall.Name = "pictureBoxWall";
			this.pictureBoxWall.Size = new System.Drawing.Size(976, 579);
			this.pictureBoxWall.TabIndex = 0;
			this.pictureBoxWall.TabStop = false;
			// 
			// timerMain
			// 
			this.timerMain.Interval = 15000;
			this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
			// 
			// timerBrickPosition
			// 
			this.timerBrickPosition.Interval = 734;
			this.timerBrickPosition.Tick += new System.EventHandler(this.timerBrickPosition_Tick);
			// 
			// labelCounter
			// 
			this.labelCounter.AutoSize = true;
			this.labelCounter.BackColor = System.Drawing.Color.Transparent;
			this.labelCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCounter.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.labelCounter.Location = new System.Drawing.Point(847, 505);
			this.labelCounter.Name = "labelCounter";
			this.labelCounter.Size = new System.Drawing.Size(24, 18);
			this.labelCounter.TabIndex = 25;
			this.labelCounter.Text = "##";
			// 
			// pictureBoxBrick
			// 
			this.pictureBoxBrick.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxBrick.Image = global::Empire.Properties.Resources.brick;
			this.pictureBoxBrick.Location = new System.Drawing.Point(387, 105);
			this.pictureBoxBrick.Name = "pictureBoxBrick";
			this.pictureBoxBrick.Size = new System.Drawing.Size(100, 61);
			this.pictureBoxBrick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxBrick.TabIndex = 26;
			this.pictureBoxBrick.TabStop = false;
			this.pictureBoxBrick.Click += new System.EventHandler(this.pictureBoxBrick_Click);
			// 
			// RepairWallForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Empire.Properties.Resources.buttonBackground;
			this.ClientSize = new System.Drawing.Size(989, 590);
			this.Controls.Add(this.pictureBoxBrick);
			this.Controls.Add(this.labelCounter);
			this.Controls.Add(this.pictureBoxWall);
			this.Name = "RepairWallForm";
			this.Text = "RepairWallForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWall)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrick)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxWall;
		private System.Windows.Forms.Timer timerMain;
		private System.Windows.Forms.Timer timerBrickPosition;
		private System.Windows.Forms.Label labelCounter;
		private System.Windows.Forms.PictureBox pictureBoxBrick;
	}
}