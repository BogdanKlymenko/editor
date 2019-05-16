using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace text_editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(FontFamily font in FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name.ToString());
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        bool saved = false;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saved = true;
            if (CurrentFile == "") saveAsToolStripMenuItem_Click(sender, e);
            else richTextBox1.SaveFile(CurrentFile, RichTextBoxStreamType.PlainText);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved == false)
            {
                if ((MessageBox.Show("Changes were not saved.Exit?", "Warning", MessageBoxButtons.OKCancel)) == DialogResult.Cancel)
                    {
                    e.Cancel = true;
                }
            }
            
        }

        
        string CurrentFile = "";
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text!="")
            {
                if(((DialogResult.OK==MessageBox.Show("The content will be lost.","Continue?",MessageBoxButtons.OKCancel))))
                {
                    richTextBox1.Text = "";
                    CurrentFile = "";
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {

                    CurrentFile = openFileDialog1.FileName;
                    if (Path.GetExtension(CurrentFile) == ".txt" || Path.GetExtension(CurrentFile) == ".cs") richTextBox1.LoadFile(CurrentFile, RichTextBoxStreamType.PlainText);
                    else richTextBox1.LoadFile(CurrentFile);
                    this.Text = Path.GetFileName(CurrentFile) + " - Text Editor";
                }
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CurrentFile=="")
            {
                saveFileDialog1.FileName = "Untitled";
            }
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                if (Path.GetExtension(saveFileDialog1.FileName) == ".txt" || Path.GetExtension(saveFileDialog1.FileName) == ".cs")
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                else richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                CurrentFile = saveFileDialog1.FileName;
                this.Text = Path.GetFileName(CurrentFile) + "- Text Editor";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Underline);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Font = new Font(comboBox1.Text, richTextBox1.Font.Size);
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, float.Parse(comboBox2.SelectedItem.ToString()));
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Color = colorDialog1.ShowDialog();
            if(Color==DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Italic);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Strikeout);
        }
    }
    }

