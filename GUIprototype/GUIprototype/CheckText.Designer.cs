namespace GUIprototype
{
    partial class CheckText
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
            this.CheckLink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.URLbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CheckLink
            // 
            this.CheckLink.Location = new System.Drawing.Point(91, 170);
            this.CheckLink.Name = "CheckLink";
            this.CheckLink.Size = new System.Drawing.Size(75, 23);
            this.CheckLink.TabIndex = 0;
            this.CheckLink.Text = "Check Link";
            this.CheckLink.UseVisualStyleBackColor = true;
            this.CheckLink.Click += new System.EventHandler(this.CheckLink_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter an URL to check";
            // 
            // URLbox
            // 
            this.URLbox.Location = new System.Drawing.Point(57, 120);
            this.URLbox.Name = "URLbox";
            this.URLbox.Size = new System.Drawing.Size(154, 20);
            this.URLbox.TabIndex = 2;
            this.URLbox.TextChanged += new System.EventHandler(this.URLbox_TextChanged);
            // 
            // CheckText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.URLbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckLink);
            this.Name = "CheckText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckText";
            this.Load += new System.EventHandler(this.CheckText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckLink;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox URLbox;
    }
}