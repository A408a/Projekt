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
using JaccardSimilarityLibrary;



namespace GUIprototype
{
    public partial class TextSimilarityForm : Form
    {

        // Declaring an instance of the checkText form. 
        private CheckText pastForm;

        public TextSimilarityForm(CheckText pastForm)
        {
            InitializeComponent();

            // Setting the instance of checkText equel to the parameter that is passed in the constructer. 
            this.pastForm = pastForm;

           


        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TextSimilarityForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckButton_Click(object sender, EventArgs e)
        {

            // The methods that are used by the constructer of this class are not so efficient. 
            NewsPage article = new NewsPage(pastForm.URLbox.Text);

            if ((string)comboBox1.SelectedItem == "Jaccard similarity.")
            {

                MessageBox.Show("Jaccard similarity was chosen.");
            }
            else if ((string)comboBox1.SelectedItem == "Cosine similarity.")
            {
                MessageBox.Show("Cosine similarity was chosen");
            }
            else
            {
                MessageBox.Show("Both similarity methods were chosen");
            }

            
                 
        }
    }
}
