﻿using System;
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

        private CheckLinkResult otherform;
        private void GetOtherForm()
        {
            otherform.url = URLbox.Text;
        }

       
           


        private void URLbox_TextChanged(object sender, EventArgs e)
        {


        }

        private void CheckLink_Click(object sender, EventArgs e)
        {
            //string url = URLbox.Text;

            CheckLinkTrustworthiness link = new CheckLinkTrustworthiness(URLbox.Text);

            //if (link.DoesLinkToFakeNews)
            //{
                this.Hide();
                CheckLinkResult CheckLinkResult = new CheckLinkResult();
                CheckLinkResult.Show();
            //}

        }

        
    }
}
