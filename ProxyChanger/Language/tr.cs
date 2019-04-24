using System.Linq;
using System.Windows.Forms;

namespace ProxyChanger.Language
{
    class tr
    {
        internal static void _main_()
        {
            mainGUI _mainGUI = Application.OpenForms.OfType<mainGUI>().FirstOrDefault<mainGUI>();

            settings._lang = "tr";
            _mainGUI.lblAddressandPort.Text = "Adres ve Port :";
            _mainGUI.lblExamples.Text = "Örnek : 192.168.1.1:8080";
            _mainGUI.cbBypass.Text = "Yerel adresler için proxy sunucuyu atla";
            _mainGUI.cbDisabled.Text = "Devre Dışı";
            _mainGUI.btnChange.Text = "Şimdi Değiştir!";
            _mainGUI.btnSettings.Text = "Ayarlar";
            _mainGUI.languageToolStripMenuItem.Text = "Dil";
            _mainGUI.toolStripMenuItem1.Text = "Windows Proxy Ayarları";
            _mainGUI.gitHubRepositiesToolStripMenuItem.Text = "Benim GitHub Depolarım";
            _mainGUI.aboutToolStripMenuItem.Text = "Hakkında";
        }
        internal static void _about_()
        {
            aboutForm _aboutForm = Application.OpenForms.OfType<aboutForm>().FirstOrDefault<aboutForm>();

            _aboutForm.Text = "Hakkında";
            _aboutForm.lblCMDLine.Text = "Komut Satırı Argümanları";
            _aboutForm.linkLabel1.Text = "Icon and Logo yazar bilgisi";
        }
    }
}
