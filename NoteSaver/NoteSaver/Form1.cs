using NoteSaver.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace NoteSaver
{
    public partial class Form1 : Form
    {
        private readonly IConstructTreeList _constructTreeList;
        public Form1(IConstructTreeList constructTreeList)
        {
            this._constructTreeList = constructTreeList;

            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                try
                {
                    richTextBox1.Text = File.ReadAllText(file);
                    toolStripStatusLabelFileName.Text = file;
                }
                catch (IOException)
                {
                    MessageBox.Show("Unable to open the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var treeList =_constructTreeList.Construct();
        }
    }
}
