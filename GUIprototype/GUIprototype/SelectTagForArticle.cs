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
    public partial class SelectTagForArticle : Form
    {
        public SelectTagForArticle()
        {
            InitializeComponent();

            // The box must load the resent tags from the database folder. 
            ChooseTagsBox.CheckOnClick = true;

            string[] Array = (from dir in Directory.GetDirectories(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database") select Path.GetFileNameWithoutExtension(dir)).ToArray();

            ChooseTagsBox.Items.AddRange(Array);
        }

        // The box must load the resent tags from the database folder. 
        private void ChooseTagsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
