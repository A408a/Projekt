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
    public partial class RemoveArticleChoices : Form
    {
        public RemoveArticleChoices(ChangeDatabase.ChangeDatabase RemoveArticle)
        {
            InitializeComponent();
            this.RemoveArticle = RemoveArticle;
        }

        ChangeDatabase.ChangeDatabase RemoveArticle;
        private void RemoveArticleChoices_Load(object sender, EventArgs e)
        {

        }

        private void DatabaseButton_Click(object sender, EventArgs e)
        {
            RemoveArticle.RemoveArticleFromDatabase();
        }

        private void TagButton_Click(object sender, EventArgs e)
        {
            // Create form for entering tag. 

        }
    }
}
