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
            this.ExtractText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckLink
            // 
            this.CheckLink.Location = new System.Drawing.Point(30, 166);
            this.CheckLink.Name = "CheckLink";
            this.CheckLink.Size = new System.Drawing.Size(75, 23);
            this.CheckLink.TabIndex = 0;
            this.CheckLink.Text = "Check Link";
            this.CheckLink.UseVisualStyleBackColor = true;
            // 
            // ExtractText
            // 
            this.ExtractText.Location = new System.Drawing.Point(187, 166);
            this.ExtractText.Name = "ExtractText";
            this.ExtractText.Size = new System.Drawing.Size(75, 23);
            this.ExtractText.TabIndex = 1;
            this.ExtractText.Text = "Extract text";
            this.ExtractText.UseVisualStyleBackColor = true;
            this.ExtractText.Click += new System.EventHandler(this.ExtractText_Click);
            // 
            // CheckText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ExtractText);
            this.Controls.Add(this.CheckLink);
            this.Name = "CheckText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckText";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CheckLink;
        private System.Windows.Forms.Button ExtractText;
    }
}