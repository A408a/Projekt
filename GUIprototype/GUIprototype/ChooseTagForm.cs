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

namespace GUIprototype
{
    public partial class ChooseTagForm : Form
    {

        private CheckText pastform = new CheckText();   
        public ChooseTagForm(CheckText pastform)
        {
            InitializeComponent();
            this.pastform = pastform;

            NewsTagsBox.CheckOnClick = true;

            string[] Array = (from dir in Directory.GetDirectories(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database") select Path.GetFileNameWithoutExtension(dir)).ToArray();

            NewsTagsBox.Items.AddRange(Array);
        }

        private void NewsTagsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChooseTagForm_Load(object sender, EventArgs e)
        {
           
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            TextSimilarityForm Textsimilarity = new TextSimilarityForm(this);
            Textsimilarity.Show();
            
        }
    }
}
