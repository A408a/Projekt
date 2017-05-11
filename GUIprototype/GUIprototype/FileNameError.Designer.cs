namespace GUIprototype
{
    partial class FileNameError
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
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.UserQuestion = new System.Windows.Forms.Label();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.Location = new System.Drawing.Point(47, 33);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(42, 13);
            this.ErrorMessage.TabIndex = 0;
            this.ErrorMessage.Text = "Label 1\r\n";
            this.ErrorMessage.Click += new System.EventHandler(this.ErrorMessage_Click);
            // 
            // UserQuestion
            // 
            this.UserQuestion.AutoSize = true;
            this.UserQuestion.Location = new System.Drawing.Point(47, 69);
            this.UserQuestion.Name = "UserQuestion";
            this.UserQuestion.Size = new System.Drawing.Size(198, 13);
            this.UserQuestion.TabIndex = 1;
            this.UserQuestion.Text = "Remove the article or change file name. ";
            this.UserQuestion.Click += new System.EventHandler(this.UserQuestion_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(34, 174);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(177, 174);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(75, 23);
            this.RenameButton.TabIndex = 3;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // FileNameError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.UserQuestion);
            this.Controls.Add(this.ErrorMessage);
            this.Name = "FileNameError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileNameError";
            this.Load += new System.EventHandler(this.FileNameError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.Label UserQuestion;
        public System.Windows.Forms.Button RemoveButton;
        public System.Windows.Forms.Button RenameButton;
    }
}