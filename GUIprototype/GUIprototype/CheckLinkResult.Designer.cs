namespace GUIprototype
{
    partial class CheckLinkResult
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
            this.Messagelabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.previousForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Messagelabel
            // 
            this.Messagelabel.AutoSize = true;
            this.Messagelabel.Location = new System.Drawing.Point(21, 41);
            this.Messagelabel.Name = "Messagelabel";
            this.Messagelabel.Size = new System.Drawing.Size(226, 26);
            this.Messagelabel.TabIndex = 0;
            this.Messagelabel.Text = "The link does not lead to a trustworthy site.\r\nDo you want to continue by extract" +
    "ing the file?";
            this.Messagelabel.Click += new System.EventHandler(this.Messagelabel_Click);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(172, 192);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 1;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // previousForm
            // 
            this.previousForm.Location = new System.Drawing.Point(24, 191);
            this.previousForm.Name = "previousForm";
            this.previousForm.Size = new System.Drawing.Size(75, 23);
            this.previousForm.TabIndex = 3;
            this.previousForm.Text = "Back";
            this.previousForm.UseVisualStyleBackColor = true;
            this.previousForm.Click += new System.EventHandler(this.previousForm_Click);
            // 
            // CheckLinkResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.previousForm);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.Messagelabel);
            this.Name = "CheckLinkResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckLinkResult";
            this.Load += new System.EventHandler(this.CheckLinkResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Messagelabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button previousForm;
    }
}