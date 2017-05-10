namespace GUIprototype
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkText = new System.Windows.Forms.Button();
            this.UpdateDatabase = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose an action.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkText
            // 
            this.checkText.Location = new System.Drawing.Point(333, 176);
            this.checkText.Name = "checkText";
            this.checkText.Size = new System.Drawing.Size(75, 23);
            this.checkText.TabIndex = 1;
            this.checkText.Text = "Check text";
            this.checkText.UseVisualStyleBackColor = true;
            this.checkText.Click += new System.EventHandler(this.checkText_Click);
            // 
            // UpdateDatabase
            // 
            this.UpdateDatabase.Location = new System.Drawing.Point(23, 170);
            this.UpdateDatabase.Name = "UpdateDatabase";
            this.UpdateDatabase.Size = new System.Drawing.Size(94, 35);
            this.UpdateDatabase.TabIndex = 2;
            this.UpdateDatabase.Text = "Update database";
            this.UpdateDatabase.UseVisualStyleBackColor = true;
            this.UpdateDatabase.Click += new System.EventHandler(this.UpdateDatabase_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(172, 178);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(94, 27);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove article";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 283);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.UpdateDatabase);
            this.Controls.Add(this.checkText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button checkText;
        private System.Windows.Forms.Button UpdateDatabase;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

