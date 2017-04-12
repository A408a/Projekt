using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoadTextLibrary;

namespace Jaccardalgoritme
{
    public partial class BrowseFile : Form
    {
        public string firstText;
        public string secondText;
        public double jaccardSimilarity = 0;

        public BrowseFile()
        {
            InitializeComponent();
        }

        private void filePath_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                firstText = openFileDialog1.SafeFileName;
                this.label2.Text = openFileDialog1.SafeFileName;
                
            }

            if(openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                secondText = openFileDialog2.SafeFileName;
                this.label3.Text = openFileDialog2.SafeFileName;
                
            }

        }

        private void calculateValue_Click(object sender, EventArgs e)
        {
            LoadEachWordToList tekstA = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database\" + firstText);
            LoadEachWordToList tekstB = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database\" + secondText);
            JaccardSimilarity nytekstA = new JaccardSimilarity();
            JaccardSimilarity nytekstB = new JaccardSimilarity();

            nytekstA.GetShingles(tekstA.Words);
            nytekstB.GetShingles(tekstB.Words);


            jaccardSimilarity = nytekstA.CalculateSimilarity(nytekstA.shingles, nytekstB.shingles);
            this.label1.Text = "The Jaccard similarity of the two texts is: " + jaccardSimilarity;
        }
    }
}
