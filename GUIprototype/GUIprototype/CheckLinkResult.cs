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
using System.Net;

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

            try
            {
                NewsPage article = new NewsPage(pastForm.URLbox.Text);
                // This code is used to test if the variabel is send to the next form. 
                textBox1.Text = pastForm.URLbox.Text;
            }

            catch (WebException Web)
            {

                MessageBox.Show(Web.Message);
            }

            catch(ArgumentException Argument)
            {
                MessageBox.Show(Argument.Message);
            }



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
