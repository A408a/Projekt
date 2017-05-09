using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
