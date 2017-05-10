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
    public partial class RenameFileForm : Form
    {
        public RenameFileForm(AutomaticRemoveFromDatabase ChangingDatabase)
        {
            InitializeComponent();

            this.ChangingDatabase = ChangingDatabase;
        }

        AutomaticRemoveFromDatabase ChangingDatabase;


        private void ChangeNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            ChangingDatabase.HandleException(ChangeNameBox.Text);
            if(DialogResult.OK ==  MessageBox.Show("The file has been renamed."))
            {
                this.Hide();
                Form1 StartForm = new Form1();
                StartForm.Show();
            }
                
            

        }

       
    }
}
