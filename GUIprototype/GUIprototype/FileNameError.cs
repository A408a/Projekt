using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChangeDatabase;

namespace GUIprototype
{
    public partial class FileNameError : Form
    {
        public FileNameError(AutomaticRemoveFromDatabase UpdateDatabase)
        {
            InitializeComponent();
            ErrorMessage.Text = $"Found invalid article: {UpdateDatabase.FileInformation.Name}.";
            ChangingDatabase = UpdateDatabase;
        }

        AutomaticRemoveFromDatabase ChangingDatabase;

        private void ErrorMessage_Click(object sender, EventArgs e)
        {

        }

        private void UserQuestion_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            ChangingDatabase.HandleException("Delete");
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            RenameFileForm RenameFile = new RenameFileForm(ChangingDatabase);
            this.Hide();
            RenameFile.Show();

        }
    }
}
