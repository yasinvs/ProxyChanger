using Microsoft.Win32;
using ProxyChanger.Language;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProxyChanger
{
    public partial class mainGUI : Form
    {

        #region Windows Proxy API
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        #endregion

        bool Starting = true;
        internal string _lang = "en";

        public mainGUI()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            if (Convert.ToString(registry.GetValue("ProxyEnable")) == "0")
            {
                cbDisabled.Checked = true;
            }
            else
            {
                txtAddress.Text = Convert.ToString(registry.GetValue("ProxyServer"));
            }

            string bypassLocalAddress = Convert.ToString(registry.GetValue("ProxyOverride"));

            if (bypassLocalAddress.Contains("<local>"))
            {
                cbBypass.Checked = true;
            }
            else
            {
                cbBypass.Checked = false;
            }

            Starting = false;
            en._main_();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtAddress.Text != "")
            {
                if(cbBypass.Checked == true)
                {
                    setProxy(txtAddress.Text, true,true);
                }
                else
                {
                    setProxy(txtAddress.Text, true,false);
                }

                if(settings._lang == "en")
                {
                    MessageBox.Show(this, "Proxy is enabled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(settings._lang == "tr")
                {
                    MessageBox.Show(this, "Proxy etkinleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (settings._lang == "en")
                {
                    MessageBox.Show(this, "Proxy address can not be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (settings._lang == "tr")
                {
                    MessageBox.Show(this, "Proxy adresi boş geçilmez", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisabled.Checked == true)
            {
                btnChange.Enabled = false;
                txtAddress.Enabled = false;
                lblAddressandPort.Enabled = false;
                lblExamples.Enabled = false;
                cbBypass.Enabled = false;
                cbBypass.Checked = false;
                setProxy("", false,false);
                if(Starting == false)
                {
                    if (settings._lang == "en")
                    {
                        MessageBox.Show(this, "Proxy is disabled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (settings._lang == "tr")
                    {
                        MessageBox.Show(this, "Proxy devre dışı bırakıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                btnChange.Enabled = true;
                txtAddress.Enabled = true;
                lblAddressandPort.Enabled = true;
                lblExamples.Enabled = true;
                cbBypass.Enabled = true;
            }
        }

        public static void setProxy(string proxyhost, bool proxyEnabled,bool bypassLocalAddress)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, "ProxyEnable", proxyEnabled ? 1 : 0);

            Registry.SetValue(keyName, "ProxyServer", proxyhost);
            
            if (bypassLocalAddress == true)
            {
                Registry.SetValue(keyName, "ProxyOverride", "<local>");
            }
            else
            {
                Registry.SetValue(keyName, "ProxyOverride", "");
            }

            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to realy update
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnSettings,0,btnSettings.Height);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm aboutform = new aboutForm();
            aboutform.ShowDialog();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            en._main_();
        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tr._main_();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("rundll32", "shell32.dll,Control_RunDLL inetcpl.cpl,,4");
        }
    }
}
