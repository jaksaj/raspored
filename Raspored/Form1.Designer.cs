namespace Raspored
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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.rtbRaspored = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(24, 37);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(125, 20);
            this.txtIme.TabIndex = 0;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(179, 19);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(72, 54);
            this.btn.TabIndex = 1;
            this.btn.Text = "napravi raspored";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // rtbRaspored
            // 
            this.rtbRaspored.Location = new System.Drawing.Point(24, 85);
            this.rtbRaspored.Name = "rtbRaspored";
            this.rtbRaspored.Size = new System.Drawing.Size(722, 312);
            this.rtbRaspored.TabIndex = 2;
            this.rtbRaspored.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbRaspored);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txtIme);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.RichTextBox rtbRaspored;
    }
}

