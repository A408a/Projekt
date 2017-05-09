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

        }
    }
}
