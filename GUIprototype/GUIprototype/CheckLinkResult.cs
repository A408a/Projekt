using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebArticleURLToText;

namespace GUIprototype
{
    public partial class CheckLinkResult : Form
    {
        // Declaring an instance of the checkText form. 
        private CheckText pastForm;

        public CheckLinkResult(CheckText pastForm)
        {
            InitializeComponent();
            // Setting the instance of checkText equel to the parameter that is passed in the constructer. 
            this.pastForm = pastForm;
        }


        private void Messagelabel_Click(object sender, EventArgs e)
        {

        }

        private void CheckLinkResult_Load(object sender, EventArgs e)
        {

        }

        

        private void continueButton_Click(object sender, EventArgs e)
        {


            NewsPage article = new NewsPage(pastForm.URLbox.Text);

            textBox1.Text = pastForm.URLbox.Text;
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void previousForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            pastForm.URLbox.Clear();
            pastForm.Show();

        }
    }
}
