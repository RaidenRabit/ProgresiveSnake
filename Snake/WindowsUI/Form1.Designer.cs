namespace WindowsUI
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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eassy_cb = new System.Windows.Forms.CheckBox();
            this.medium_cb = new System.Windows.Forms.CheckBox();
            this.hard_cb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbCanvas.Location = new System.Drawing.Point(12, 12);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(579, 426);
            this.pbCanvas.TabIndex = 2;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PbCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // eassy_cb
            // 
            this.eassy_cb.AutoSize = true;
            this.eassy_cb.Location = new System.Drawing.Point(657, 194);
            this.eassy_cb.Name = "eassy_cb";
            this.eassy_cb.Size = new System.Drawing.Size(61, 21);
            this.eassy_cb.TabIndex = 4;
            this.eassy_cb.Text = "Easy";
            this.eassy_cb.UseVisualStyleBackColor = true;
            this.eassy_cb.CheckedChanged += new System.EventHandler(this.eassy_cb_CheckedChanged);
            // 
            // medium_cb
            // 
            this.medium_cb.AutoSize = true;
            this.medium_cb.Location = new System.Drawing.Point(657, 221);
            this.medium_cb.Name = "medium_cb";
            this.medium_cb.Size = new System.Drawing.Size(79, 21);
            this.medium_cb.TabIndex = 5;
            this.medium_cb.Text = "Medium";
            this.medium_cb.UseVisualStyleBackColor = true;
            this.medium_cb.CheckedChanged += new System.EventHandler(this.medium_cb_CheckedChanged);
            // 
            // hard_cb
            // 
            this.hard_cb.AutoSize = true;
            this.hard_cb.Location = new System.Drawing.Point(657, 248);
            this.hard_cb.Name = "hard_cb";
            this.hard_cb.Size = new System.Drawing.Size(61, 21);
            this.hard_cb.TabIndex = 6;
            this.hard_cb.Text = "Hard";
            this.hard_cb.UseVisualStyleBackColor = true;
            this.hard_cb.CheckedChanged += new System.EventHandler(this.hard_cb_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hard_cb);
            this.Controls.Add(this.medium_cb);
            this.Controls.Add(this.eassy_cb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox eassy_cb;
        private System.Windows.Forms.CheckBox medium_cb;
        private System.Windows.Forms.CheckBox hard_cb;
    }
}

