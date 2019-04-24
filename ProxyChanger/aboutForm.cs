using ProxyChanger.Language;
using ProxyChanger.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ProxyChanger
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
        }

        private void aboutForm_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = String.Format("Version : {0}.{1}", version.Major,version.Minor);

            if(settings._lang == "en")
            {
                en._about_();
            }
            else if(settings._lang == "tr")
            {
                tr._about_();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Resources.CommandLine_Arguments, "ProxyChanger", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process _mail = new Process();
            _mail.StartInfo.FileName = "mailto:sekmanyasin@hotmail.com?subject=ProxyChanger";
            _mail.Start();
        }

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var logoAuthors = Path.Combine(Path.GetTempPath(), "authors.txt");
            File.WriteAllText(logoAuthors, Resources.authors);
            Process.Start(logoAuthors);
        }
    }
}
