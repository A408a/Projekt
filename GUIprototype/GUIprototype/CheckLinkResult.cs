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
        private CheckText form1;

        public CheckLinkResult(CheckText form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }


        private void Messagelabel_Click(object sender, EventArgs e)
        {

        }

        private void CheckLinkResult_Load(object sender, EventArgs e)
        {

        }

        

        private void continueButton_Click(object sender, EventArgs e)
        {


            // NewsPage article = new NewsPage(text.Url);

            textBox1.Text = form1.URLbox.Text;
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
