namespace GUIprototype
{
    partial class ChooseTagForm
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
            this.NewsTagsBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose a tag that matches the text\r\nfrom the list below.";
            // 
            // NewsTagsBox
            // 
            this.NewsTagsBox.FormattingEnabled = true;
            this.NewsTagsBox.Items.AddRange(new object[] {
            "Brexit",
            "Crime",
            "Egypt_attack",
            "Koran_and_Bible",
            "Stockholm_attack",
            "Syria_war",
            "Terror",
            "Trump",
            "US_Election",
            "US_Travel_Ban",
            "US_Healthcare",
            "US_Trade_War"});
            this.NewsTagsBox.Location = new System.Drawing.Point(58, 82);
            this.NewsTagsBox.Name = "NewsTagsBox";
            this.NewsTagsBox.Size = new System.Drawing.Size(156, 154);
            this.NewsTagsBox.TabIndex = 1;
            this.NewsTagsBox.SelectedIndexChanged += new System.EventHandler(this.NewsTagsBox_SelectedIndexChanged);
            // 
            // ChooseTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.NewsTagsBox);
            this.Controls.Add(this.label1);
            this.Name = "ChooseTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseTagForm";
            this.Load += new System.EventHandler(this.ChooseTagForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox NewsTagsBox;
    }
}