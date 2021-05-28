namespace Break_out
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lvl = new System.Windows.Forms.Label();
            this.HP = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.BackColor = System.Drawing.Color.Transparent;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtScore.Location = new System.Drawing.Point(14, 10);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(76, 20);
            this.txtScore.TabIndex = 0;
            this.txtScore.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lvl
            // 
            this.lvl.AutoSize = true;
            this.lvl.BackColor = System.Drawing.Color.Transparent;
            this.lvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lvl.Location = new System.Drawing.Point(291, 10);
            this.lvl.Name = "lvl";
            this.lvl.Size = new System.Drawing.Size(51, 20);
            this.lvl.TabIndex = 4;
            this.lvl.Text = "LVL: ";
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.BackColor = System.Drawing.Color.Transparent;
            this.HP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.HP.Location = new System.Drawing.Point(572, 9);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(19, 20);
            this.HP.TabIndex = 5;
            this.HP.Text = "3";
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Cyan;
            this.ball.Location = new System.Drawing.Point(315, 422);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(25, 25);
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.player.Location = new System.Drawing.Point(278, 483);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(100, 32);
            this.player.TabIndex = 1;
            this.player.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(687, 527);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.player);
            this.Controls.Add(this.HP);
            this.Controls.Add(this.lvl);
            this.Controls.Add(this.txtScore);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = " Break Out Emrle Edition";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label HP;
        private System.Windows.Forms.Label lvl;
    }
}

