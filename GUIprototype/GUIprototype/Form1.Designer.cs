﻿namespace GUIprototype
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
            this.EditDatabase = new System.Windows.Forms.Button();
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
            this.checkText.Location = new System.Drawing.Point(175, 170);
            this.checkText.Name = "checkText";
            this.checkText.Size = new System.Drawing.Size(75, 23);
            this.checkText.TabIndex = 1;
            this.checkText.Text = "Check text";
            this.checkText.UseVisualStyleBackColor = true;
            this.checkText.Click += new System.EventHandler(this.checkText_Click);
            // 
            // EditDatabase
            // 
            this.EditDatabase.Location = new System.Drawing.Point(23, 170);
            this.EditDatabase.Name = "EditDatabase";
            this.EditDatabase.Size = new System.Drawing.Size(83, 23);
            this.EditDatabase.TabIndex = 2;
            this.EditDatabase.Text = "Edit database";
            this.EditDatabase.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.EditDatabase);
            this.Controls.Add(this.checkText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button checkText;
        private System.Windows.Forms.Button EditDatabase;
    }
}

