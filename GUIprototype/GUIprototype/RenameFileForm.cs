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
    public partial class RenameFileForm : Form
    {
        public RenameFileForm(FileInfo InvalidFile, AutomaticRemoveFromDatabase EditFile)
        {
            InitializeComponent();

            this.EditFile = EditFile;
        }
        FileInfo InvalidFile;
        AutomaticRemoveFromDatabase EditFile;


        private void ChangeNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            EditFile.HandleException(InvalidFile, ChangeNameBox.Text);
            if(DialogResult.OK ==  MessageBox.Show("The file has been renamed."))
            {
                this.Hide();
                Form1 StartForm = new Form1();
                StartForm.Show();
            }        

        }

        private void RenameFileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
