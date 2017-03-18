namespace lab5._1
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
            this.anTvas = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // anTvas
            // 
            this.anTvas.AccumBits = ((byte)(0));
            this.anTvas.AutoCheckErrors = false;
            this.anTvas.AutoFinish = false;
            this.anTvas.AutoMakeCurrent = true;
            this.anTvas.AutoSwapBuffers = true;
            this.anTvas.BackColor = System.Drawing.Color.LightGray;
            this.anTvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.anTvas.ColorBits = ((byte)(32));
            this.anTvas.DepthBits = ((byte)(16));
            this.anTvas.Location = new System.Drawing.Point(-3, -1);
            this.anTvas.Name = "anTvas";
            this.anTvas.Size = new System.Drawing.Size(726, 490);
            this.anTvas.StencilBits = ((byte)(0));
            this.anTvas.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(729, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerMove
            // 
            this.timerMove.Interval = 36;
            this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Location = new System.Drawing.Point(729, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 56);
            this.button3.TabIndex = 3;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Location = new System.Drawing.Point(729, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 56);
            this.button4.TabIndex = 4;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 449);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.anTvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl anTvas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerMove;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

