using System.Linq;
using System.Windows.Forms;

namespace ProxyChanger.Language
{
    class en
    {
        internal static void _main_()
        {
            mainGUI _mainGUI = Application.OpenForms.OfType<mainGUI>().FirstOrDefault<mainGUI>();

            settings._lang = "en";
            _mainGUI.lblAddressandPort.Text = "Address and Port :";
            _mainGUI.lblExamples.Text = "Example : 192.168.1.1:8080";
            _mainGUI.cbBypass.Text = "Bypass Proxy Server for Local Addresses";
            _mainGUI.cbDisabled.Text = "Disabled";
            _mainGUI.btnChange.Text = "Change Now!";
            _mainGUI.btnSettings.Text = "Settings";
            _mainGUI.languageToolStripMenuItem.Text = "Language";
            _mainGUI.toolStripMenuItem1.Text = "Windows Proxy Settings";
            _mainGUI.gitHubRepositiesToolStripMenuItem.Text = "My GitHub Reposities";
            _mainGUI.aboutToolStripMenuItem.Text = "About";
        }
        internal static void _about_()
        {
            aboutForm _aboutForm = Application.OpenForms.OfType<aboutForm>().FirstOrDefault<aboutForm>();

            _aboutForm.Text = "About";
            _aboutForm.lblCMDLine.Text = "CommandLine Arguments";
            _aboutForm.linkLabel1.Text = "Icon and Logo author info";
        }
    }
}
