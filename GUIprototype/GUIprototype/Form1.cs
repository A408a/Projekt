using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JaccardSimilarityLibrary;
using ChangeDatabase;
using System.IO;

namespace GUIprototype
{
    public partial class Form1 : Form
    {

        public string Text;
        public Form1()
        {
            InitializeComponent();
        }

        public CheckText CheckText = new CheckText();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkText_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            CheckText.Show();
            
        }

        private void UpdateDatabase_Click(object sender, EventArgs e)
        {
            // This will update the database automatically. 
            AutomaticRemoveFromDatabase UpdateDatabase = new AutomaticRemoveFromDatabase();

            UpdateDatabase.FindOutdatedFolder();
            MessageBox.Show("Update of database has been performed");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Text = openFileDialog1.SafeFileName;

                ChangeDatabase.AddOrRemoveArticle RemoveArticle = new ChangeDatabase.AddOrRemoveArticle(Text);

                RemoveArticleChoices RemoveArticleForm = new RemoveArticleChoices(RemoveArticle);

                this.Hide();

                RemoveArticleForm.Show();
             
            }
                
        }
    }
}
