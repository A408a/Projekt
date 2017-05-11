using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ChangeDatabase;

namespace GUIprototype
{
    public partial class SelectTagForArticle : Form
    {
        public SelectTagForArticle()
        {
            InitializeComponent();

            // The box must load the resent tags from the database folder. 
            ChooseTagsBox.CheckOnClick = true;

            string[] Tags = (from dir in Directory.GetDirectories(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database") select Path.GetFileNameWithoutExtension(dir)).ToArray();

            ChooseTagsBox.Items.AddRange(Tags);
            
            
        }

        
         
        private void ChooseTagsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectTagForArticle_Load(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
        //    AddOrRemoveArticle RemoveArticle = new AddOrRemoveArticle();

        //    foreach (CheckedListBox tag in  )
        //    {

        //    }
        //   RemoveArticle.RemoveArticleFromTag()



        //    if (DialogResult.OK == MessageBox.Show("Article has been removed from database tags"))
        //    {
        //        this.Hide();
        //        Form1 FirstForm = new Form1();
        //        FirstForm.Show();
        //    }
        }
    }
}
