namespace SnakeGame
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
            this.pictureBoxArena = new System.Windows.Forms.PictureBox();
            this.score_label = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gameoverlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArena)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxArena
            // 
            this.pictureBoxArena.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxArena.Location = new System.Drawing.Point(16, 76);
            this.pictureBoxArena.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxArena.Name = "pictureBoxArena";
            this.pictureBoxArena.Size = new System.Drawing.Size(1109, 567);
            this.pictureBoxArena.TabIndex = 0;
            this.pictureBoxArena.TabStop = false;
            this.pictureBoxArena.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxArena_Paint);
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.Location = new System.Drawing.Point(425, 26);
            this.score_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(107, 30);
            this.score_label.TabIndex = 1;
            this.score_label.Text = "SCORE :";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Arial Black", 12.25F);
            this.score.Location = new System.Drawing.Point(535, 27);
            this.score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(27, 30);
            this.score.TabIndex = 2;
            this.score.Text = "0";
            // 
            // gameoverlbl
            // 
            this.gameoverlbl.AutoSize = true;
            this.gameoverlbl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gameoverlbl.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameoverlbl.Location = new System.Drawing.Point(247, 171);
            this.gameoverlbl.Name = "gameoverlbl";
            this.gameoverlbl.Size = new System.Drawing.Size(151, 60);
            this.gameoverlbl.TabIndex = 3;
            this.gameoverlbl.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 658);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gameoverlbl);
            this.Controls.Add(this.score);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.pictureBoxArena);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxArena;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label gameoverlbl;
        private System.Windows.Forms.Label label2;
    }
}

