using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Downloader
{
    public partial class Shiroi : Form
    {
        public Shiroi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "") {
                MessageBox.Show("请选择保存的文件夹", "提示");
            } else {
                button1.Enabled = false;
                Boolean init = HttpDownloader.SaveImage(textBox1.Text, @label1.Text);
                button1.Enabled = true;
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionLength = 0;
                richTextBox1.SelectionColor = init ? Color.Green: Color.Red;
                richTextBox1.AppendText(textBox1.Text + (init ? "下载成功" : "下载失败") + "\r\n");
                richTextBox1.ScrollToCaret();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                label1.Text = folderBrowserDialog.SelectedPath + "\\";
            }
        }
    }
}
