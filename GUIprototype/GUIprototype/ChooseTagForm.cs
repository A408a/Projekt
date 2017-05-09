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
        
        public ChooseTagForm()
        {
            InitializeComponent();

            NewsTagsBox.CheckOnClick = true;
        }

        private void NewsTagsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChooseTagForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
