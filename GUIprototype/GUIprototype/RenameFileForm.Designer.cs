namespace GUIprototype
{
    partial class RenameFileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.ChangeNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the new name in the field below.";
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(88, 175);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(75, 23);
            this.ContinueButton.TabIndex = 2;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // ChangeNameBox
            // 
            this.ChangeNameBox.Location = new System.Drawing.Point(53, 104);
            this.ChangeNameBox.Name = "ChangeNameBox";
            this.ChangeNameBox.Size = new System.Drawing.Size(138, 20);
            this.ChangeNameBox.TabIndex = 3;
            this.ChangeNameBox.TextChanged += new System.EventHandler(this.ChangeNameBox_TextChanged);
            // 
            // RenameFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ChangeNameBox);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.label1);
            this.Name = "RenameFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RenameFileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.TextBox ChangeNameBox;
    }
}