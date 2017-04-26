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
        public CheckLinkResult()
        {
            InitializeComponent();
        }

        public string url;
        private void Messagelabel_Click(object sender, EventArgs e)
        {

        }

        private void CheckLinkResult_Load(object sender, EventArgs e)
        {

        }

        private void continueButton_Click(object sender, EventArgs e)
        {

            
           // NewsPage article = new NewsPage(text.Url);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = url;
            
        }
    }
}
