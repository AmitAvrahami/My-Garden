using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{
    public partial class Form1 : Form
    {
        start_game st = new start_game();
        garden myg = new garden();
        public Form1()
        {
            InitializeComponent();
        }

        private void SG_Click(object sender, EventArgs e)
        {
            st.Show();
        }

        private void EX_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LG_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            //openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.RestoreDirectory = true;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
            //    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //    //!!!!
            //    myg = (garden)binaryFormatter.Deserialize(stream);
            //    st..Invalidate();
            //}
        }
    }
}
