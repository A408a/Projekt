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
            try
            {
                UpdateDatabase.FindOutdatedFolder();
                MessageBox.Show("The database has now been updated");
            }

            catch (ArgumentException)
            {
                // If something goes wrong with the file name. 
                // The user is asked to enter a new name for the file. 

                //TextBox FileNameBox = new TextBox();
                //FileNameBox.Show();
                //this.Hide();

            }

            catch (FormatException)
            {

                FileNameError FileNameForm = new FileNameError(UpdateDatabase);

                this.Hide();
                FileNameForm.Show();

                
            }

             
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

                ChangeDatabase.ChangeDatabase RemoveArticle = new ChangeDatabase.ChangeDatabase(Text);

                RemoveArticleChoices RemoveArticleForm = new RemoveArticleChoices(RemoveArticle);

                this.Hide();

                RemoveArticleForm.Show();
             
            }
                
        }
    }
}
