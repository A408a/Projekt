﻿namespace GUIprototype
{
    partial class SelectTagForArticle
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
            this.ChooseTagsBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChooseTagsBox
            // 
            this.ChooseTagsBox.FormattingEnabled = true;
            this.ChooseTagsBox.Location = new System.Drawing.Point(72, 83);
            this.ChooseTagsBox.Name = "ChooseTagsBox";
            this.ChooseTagsBox.Size = new System.Drawing.Size(120, 139);
            this.ChooseTagsBox.TabIndex = 0;
            this.ChooseTagsBox.SelectedIndexChanged += new System.EventHandler(this.ChooseTagsBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please choose the tag(s) to remove the article from.";
            // 
            // SelectTagForArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChooseTagsBox);
            this.Name = "SelectTagForArticle";
            this.Text = "SelectTagForArticle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ChooseTagsBox;
        private System.Windows.Forms.Label label1;
    }
}