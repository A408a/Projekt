using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckLinkTrustworthinessLibrary;

namespace GUIprototype
{
    public partial class CheckText : Form
    {
        public CheckText()
        {
            InitializeComponent();
        }


        private void URLbox_TextChanged(object sender, EventArgs e)
        {


        }

        private void CheckLink_Click(object sender, EventArgs e)
        {
            

            CheckLinkTrustworthiness link = new CheckLinkTrustworthiness();

            try
            {
                link.IsLinkValid(URLbox.Text);
            }

            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }

            if (link.CheckLink(URLbox.Text))
            {
                this.Hide();
                // Create instance of form CheckLinkResult and pass the current CheckText as a parameter to the constructer.
                CheckLinkResult CheckLinkResult = new CheckLinkResult(this);
                CheckLinkResult.Show();
                
            }

            else
            {
                this.Hide();
                //TextSimilarityForm TextSimilarity = new TextSimilarityForm(this);
                //TextSimilarity.Show();
                ChooseTagForm TagsForm = new ChooseTagForm(this);
                TagsForm.Show();

            }

        }

        private void CheckText_Load(object sender, EventArgs e)
        {

        }
    }
}
