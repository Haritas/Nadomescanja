using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Maturitetna_Naloga
{
    public partial class Form1 : Form
    {
        const string quote = "\"";
        int start,start2;
        string x;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            richTextBox1.Text = client.DownloadString("http://www.sc-celje.si/ek/informacije/Lists/Suplence/AllItems.aspx");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start = richTextBox1.Text.IndexOf("Summary=" + quote + "Suplence");
           string x = richTextBox1.Text.Substring(start);
            richTextBox1.Text = x;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            start = richTextBox1.Text.IndexOf("<TBODY id="+quote+"titl1-1");
            x = richTextBox1.Text.Substring(start);
            start = richTextBox1.Text.IndexOf("<TR class=" + quote + quote);
            x = richTextBox1.Text.Substring(start);
            richTextBox1.Text = x;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            start = richTextBox1.Text.IndexOf("</TABLE>");
            x = richTextBox1.Text.Substring(0, start);
            richTextBox1.Text = x;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] values = richTextBox1.Text.Split(new string[] { "<tr>", "</tr>", "<td>", "</td>" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> list = new List<string>(values);

            string[,] atributes = new string[list.Count, 8];

            for (int i = 1; i < values.Length; i++) // REZANJE IZ VSAKE VRSTICE IZ TABELE
            {
                start = list[i].IndexOf("<NOBR>");
                start2 = list[i].IndexOf("</NOBR>");
                atributes[i,0] = list[i].Substring(start+6,start2-25); // DATUM

                list[i] = list[i].Substring(start2+31);
                start2 = list[i].IndexOf("</TD>");
                atributes[i, 1] = list[i].Substring(0, start2); // IME MANJKAJOČEGA UČITELJA

                list[i] = list[i].Substring(start2 + 24);
                start2 = list[i].IndexOf("</TD>");
                atributes[i, 2] = list[i].Substring(0, start2); // IME NADOMESTNEGA UČITELJA

                list[i] = list[i].Substring(start2 + 24);
                start2 = list[i].IndexOf("</TD>");
                atributes[i, 3] = list[i].Substring(0, start2); // RAZRED

                list[i] = list[i].Substring(start2 + 24);
                start2 = list[i].IndexOf("</TD>");
                atributes[i, 4] = list[i].Substring(0, start2); // UCILNICA

                list[i] = list[i].Substring(start2 + 24);
                start2 = list[i].IndexOf("</TD>");
                atributes[i, 5] = list[i].Substring(0, start2); // PREDMET

                list[i] = list[i].Substring(start2 + 24);
                start2 = list[i].IndexOf("</TD>");
                atributes[i, 6] = list[i].Substring(0, start2); // VRSTA NADOMESCANJA

                list[i] = list[i].Substring(start2 + 41);
                start2 = list[i].IndexOf("</DIV>");
                atributes[i, 7] = list[i].Substring(0, start2); // URA
            }

            


        }
    }
}
