
namespace FroggerFINAL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.froggerTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreCounterLabel = new System.Windows.Forms.Label();
            this.titleText = new System.Windows.Forms.Label();
            this.subtitleText = new System.Windows.Forms.Label();
            this.gameOver = new System.Windows.Forms.Label();
            this.deathLabel = new System.Windows.Forms.Label();
            this.arroLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // froggerTimer
            // 
            this.froggerTimer.Interval = 20;
            this.froggerTimer.Tick += new System.EventHandler(this.froggerTimer_Tick);
            // 
            // scoreCounterLabel
            // 
            this.scoreCounterLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreCounterLabel.Font = new System.Drawing.Font("MS Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreCounterLabel.Location = new System.Drawing.Point(4, 4);
            this.scoreCounterLabel.Name = "scoreCounterLabel";
            this.scoreCounterLabel.Size = new System.Drawing.Size(169, 30);
            this.scoreCounterLabel.TabIndex = 0;
            this.scoreCounterLabel.Text = "SCORE:";
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.BackColor = System.Drawing.Color.Transparent;
            this.titleText.Font = new System.Drawing.Font("MS Gothic", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.Location = new System.Drawing.Point(53, 224);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(285, 58);
            this.titleText.TabIndex = 1;
            this.titleText.Text = "FROGGER 2:\r\nElectric Boogaloo";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // subtitleText
            // 
            this.subtitleText.BackColor = System.Drawing.Color.Transparent;
            this.subtitleText.Font = new System.Drawing.Font("MS Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.subtitleText.Location = new System.Drawing.Point(12, 294);
            this.subtitleText.Name = "subtitleText";
            this.subtitleText.Size = new System.Drawing.Size(360, 212);
            this.subtitleText.TabIndex = 2;
            this.subtitleText.Text = "Space - Play || Esc - Quit\r\n";
            this.subtitleText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gameOver
            // 
            this.gameOver.BackColor = System.Drawing.Color.Transparent;
            this.gameOver.Image = global::FroggerFINAL.Properties.Resources.GAME_OVER;
            this.gameOver.Location = new System.Drawing.Point(-5, 66);
            this.gameOver.Name = "gameOver";
            this.gameOver.Size = new System.Drawing.Size(406, 228);
            this.gameOver.TabIndex = 3;
            this.gameOver.Visible = false;
            // 
            // deathLabel
            // 
            this.deathLabel.BackColor = System.Drawing.Color.Transparent;
            this.deathLabel.Font = new System.Drawing.Font("MS Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathLabel.Location = new System.Drawing.Point(260, 4);
            this.deathLabel.Name = "deathLabel";
            this.deathLabel.Size = new System.Drawing.Size(112, 30);
            this.deathLabel.TabIndex = 4;
            this.deathLabel.Text = "DEATHS:";
            // 
            // arroLabel
            // 
            this.arroLabel.BackColor = System.Drawing.Color.Transparent;
            this.arroLabel.Location = new System.Drawing.Point(-2, -17);
            this.arroLabel.Name = "arroLabel";
            this.arroLabel.Size = new System.Drawing.Size(388, 569);
            this.arroLabel.TabIndex = 5;
            this.arroLabel.Text = "label1";
            // 
            // Form1
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.arroLabel);
            this.Controls.Add(this.deathLabel);
            this.Controls.Add(this.gameOver);
            this.Controls.Add(this.subtitleText);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.scoreCounterLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FROGGER 2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer froggerTimer;
        private System.Windows.Forms.Label scoreCounterLabel;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Label subtitleText;
        private System.Windows.Forms.Label gameOver;
        private System.Windows.Forms.Label deathLabel;
        private System.Windows.Forms.Label arroLabel;
    }
}

