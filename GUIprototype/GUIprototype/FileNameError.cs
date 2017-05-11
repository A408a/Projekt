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
using System.IO;

namespace GUIprototype
{
    public partial class FileNameError : Form
    {
        public FileNameError(FileInfo InvalidFile, AutomaticRemoveFromDatabase EditFile)
        {
            InitializeComponent();
            ErrorMessage.Text = $"Found invalid article: {InvalidFile.Name}.";
            this.InvalidFile = InvalidFile;
            this.EditFile = EditFile;
        }
 
        FileInfo InvalidFile;
        AutomaticRemoveFromDatabase EditFile;

        private void ErrorMessage_Click(object sender, EventArgs e)
        {

        }

        private void UserQuestion_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            EditFile.HandleException(InvalidFile,"Delete");
            MessageBox.Show("The file has been deleted.");
            // Not all files are deleted. This needs to be fixed. 

            //if (DialogResult.OK == MessageBox.Show("The file has been renamed."))
            //{
            //    this.Hide();
            //    Form1 StartForm = new Form1();
            //    StartForm.Show();
            //}
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            RenameFileForm RenameFile = new RenameFileForm(InvalidFile,EditFile);
            this.Hide();
            RenameFile.Show();
            
        }


        private void FileNameError_Load(object sender, EventArgs e)
        {

        }
    }
}
