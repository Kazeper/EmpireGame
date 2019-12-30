namespace Empire
{
	partial class FightForm
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
			this.pictureBoxFight = new System.Windows.Forms.PictureBox();
			this.timerMain = new System.Windows.Forms.Timer(this.components);
			this.timerEnemyPosition = new System.Windows.Forms.Timer(this.components);
			this.pictureBoxEnemy = new System.Windows.Forms.PictureBox();
			this.labelCounter = new System.Windows.Forms.Label();
			this.labelCounterInfo = new System.Windows.Forms.Label();
			this.timerShowFight = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxFight
			// 
			this.pictureBoxFight.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.pictureBoxFight.Image = global::Empire.Properties.Resources.knightsFight;
			this.pictureBoxFight.Location = new System.Drawing.Point(0, -4);
			this.pictureBoxFight.Name = "pictureBoxFight";
			this.pictureBoxFight.Size = new System.Drawing.Size(985, 580);
			this.pictureBoxFight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxFight.TabIndex = 0;
			this.pictureBoxFight.TabStop = false;
			this.pictureBoxFight.Visible = false;
			// 
			// timerMain
			// 
			this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
			// 
			// timerEnemyPosition
			// 
			this.timerEnemyPosition.Interval = 500;
			this.timerEnemyPosition.Tick += new System.EventHandler(this.timerEnemyPosition_Tick);
			// 
			// pictureBoxEnemy
			// 
			this.pictureBoxEnemy.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxEnemy.Image = global::Empire.Properties.Resources.skyrim_fighter;
			this.pictureBoxEnemy.Location = new System.Drawing.Point(744, 30);
			this.pictureBoxEnemy.Name = "pictureBoxEnemy";
			this.pictureBoxEnemy.Size = new System.Drawing.Size(241, 507);
			this.pictureBoxEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxEnemy.TabIndex = 1;
			this.pictureBoxEnemy.TabStop = false;
			this.pictureBoxEnemy.Click += new System.EventHandler(this.pictureBoxEnemy_Click);
			// 
			// labelCounter
			// 
			this.labelCounter.AutoSize = true;
			this.labelCounter.BackColor = System.Drawing.Color.Transparent;
			this.labelCounter.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCounter.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.labelCounter.Location = new System.Drawing.Point(732, 540);
			this.labelCounter.Name = "labelCounter";
			this.labelCounter.Size = new System.Drawing.Size(24, 26);
			this.labelCounter.TabIndex = 2;
			this.labelCounter.Text = "0";
			// 
			// labelCounterInfo
			// 
			this.labelCounterInfo.AutoSize = true;
			this.labelCounterInfo.BackColor = System.Drawing.Color.Transparent;
			this.labelCounterInfo.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCounterInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.labelCounterInfo.Location = new System.Drawing.Point(599, 540);
			this.labelCounterInfo.Name = "labelCounterInfo";
			this.labelCounterInfo.Size = new System.Drawing.Size(119, 26);
			this.labelCounterInfo.TabIndex = 3;
			this.labelCounterInfo.Text = "Trafionych:";
			// 
			// timerShowFight
			// 
			this.timerShowFight.Interval = 3000;
			this.timerShowFight.Tick += new System.EventHandler(this.timerShowFight_Tick);
			// 
			// FightForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Empire.Properties.Resources.woods_background;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(985, 570);
			this.Controls.Add(this.labelCounterInfo);
			this.Controls.Add(this.labelCounter);
			this.Controls.Add(this.pictureBoxEnemy);
			this.Controls.Add(this.pictureBoxFight);
			this.Name = "FightForm";
			this.Text = "FightForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxFight;
		private System.Windows.Forms.Timer timerMain;
		private System.Windows.Forms.Timer timerEnemyPosition;
		private System.Windows.Forms.PictureBox pictureBoxEnemy;
		private System.Windows.Forms.Label labelCounter;
		private System.Windows.Forms.Label labelCounterInfo;
		private System.Windows.Forms.Timer timerShowFight;
	}
}