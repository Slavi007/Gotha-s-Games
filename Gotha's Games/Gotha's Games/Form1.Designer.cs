namespace Gotha_s_Games
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btSnake = new System.Windows.Forms.Button();
            this.btTron = new System.Windows.Forms.Button();
            this.btPingPong = new System.Windows.Forms.Button();
            this.btSantase = new System.Windows.Forms.Button();
            this.btBrickBreaker = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSnake
            // 
            this.btSnake.BackColor = System.Drawing.Color.Transparent;
            this.btSnake.BackgroundImage = global::Gotha_s_Games.Properties.Resources.Snake;
            this.btSnake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSnake.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSnake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSnake.Location = new System.Drawing.Point(41, 210);
            this.btSnake.Name = "btSnake";
            this.btSnake.Size = new System.Drawing.Size(270, 115);
            this.btSnake.TabIndex = 0;
            this.btSnake.UseVisualStyleBackColor = false;
            this.btSnake.Click += new System.EventHandler(this.button1_Click);
            // 
            // btTron
            // 
            this.btTron.BackColor = System.Drawing.Color.Transparent;
            this.btTron.BackgroundImage = global::Gotha_s_Games.Properties.Resources.tron_marquee_game_sticker;
            this.btTron.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btTron.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTron.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTron.Location = new System.Drawing.Point(353, 210);
            this.btTron.Name = "btTron";
            this.btTron.Size = new System.Drawing.Size(270, 115);
            this.btTron.TabIndex = 1;
            this.btTron.UseVisualStyleBackColor = false;
            this.btTron.Click += new System.EventHandler(this.btTron_Click);
            // 
            // btPingPong
            // 
            this.btPingPong.BackColor = System.Drawing.Color.Transparent;
            this.btPingPong.BackgroundImage = global::Gotha_s_Games.Properties.Resources.pingpong_1x;
            this.btPingPong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPingPong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPingPong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btPingPong.Location = new System.Drawing.Point(669, 210);
            this.btPingPong.Name = "btPingPong";
            this.btPingPong.Size = new System.Drawing.Size(270, 115);
            this.btPingPong.TabIndex = 2;
            this.btPingPong.UseVisualStyleBackColor = false;
            this.btPingPong.Click += new System.EventHandler(this.btPingPong_Click);
            // 
            // btSantase
            // 
            this.btSantase.BackColor = System.Drawing.Color.Transparent;
            this.btSantase.BackgroundImage = global::Gotha_s_Games.Properties.Resources.santase;
            this.btSantase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSantase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSantase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSantase.Font = new System.Drawing.Font("Broadway", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSantase.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btSantase.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSantase.Location = new System.Drawing.Point(156, 389);
            this.btSantase.Name = "btSantase";
            this.btSantase.Size = new System.Drawing.Size(270, 115);
            this.btSantase.TabIndex = 3;
            this.btSantase.UseVisualStyleBackColor = false;
            // 
            // btBrickBreaker
            // 
            this.btBrickBreaker.BackColor = System.Drawing.Color.Transparent;
            this.btBrickBreaker.BackgroundImage = global::Gotha_s_Games.Properties.Resources.H2x1_WiiUDS_BrickBreaker;
            this.btBrickBreaker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBrickBreaker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBrickBreaker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBrickBreaker.Location = new System.Drawing.Point(556, 389);
            this.btBrickBreaker.Name = "btBrickBreaker";
            this.btBrickBreaker.Size = new System.Drawing.Size(270, 115);
            this.btBrickBreaker.TabIndex = 4;
            this.btBrickBreaker.UseVisualStyleBackColor = false;
            this.btBrickBreaker.Click += new System.EventHandler(this.btBrickBreaker_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTitle.Font = new System.Drawing.Font("Ravie", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(29, 63);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(924, 73);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Gotha\'s Games presents:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gotha_s_Games.Properties.Resources.rsz_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btBrickBreaker);
            this.Controls.Add(this.btSantase);
            this.Controls.Add(this.btPingPong);
            this.Controls.Add(this.btTron);
            this.Controls.Add(this.btSnake);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gotha\'s Games";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSnake;
        private System.Windows.Forms.Button btTron;
        private System.Windows.Forms.Button btPingPong;
        private System.Windows.Forms.Button btSantase;
        private System.Windows.Forms.Button btBrickBreaker;
        private System.Windows.Forms.Label lblTitle;
    }
}

