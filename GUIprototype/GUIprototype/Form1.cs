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
            if (DialogResult.Yes == MessageBox.Show($"Found {UpdateDatabase.FileNameError.Count} Invalid files. \nDo you want to delete all the articles at once?", "", MessageBoxButtons.YesNo))
            {
                foreach (FileInfo InvalidFile in UpdateDatabase.FileNameError)
                {
                    UpdateDatabase.HandleException(InvalidFile, "Delete");
                }

            }

            else
            {
                foreach (FileInfo InvalidFile in UpdateDatabase.FileNameError)
                {
                    // Create only one form:
                    FileNameError FileNameForm = new FileNameError(InvalidFile, UpdateDatabase);
                    FileNameForm.Show();

                    FileNameForm.RemoveButton.Click;
                   // FileNameForm.Close();

                    
                }

            }

            //                MessageBox.Show($"Found {UpdateDatabase.FileNameError.Count} invalid files. Do you want to edit them or remove them")
            //MessageBox.Show("The database has now been updated");


            //FileNameError FileNameForm = new FileNameError(UpdateDatabase);
            //this.Hide();
            //FileNameForm.Show();
            // MessageBox.Show(UpdateDatabase.Dir());
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
