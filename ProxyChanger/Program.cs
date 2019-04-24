using ProxyChanger.Properties;
using System;
using System.Windows.Forms;

namespace ProxyChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length== 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainGUI());
            }
            else
            {
                if (args[0] == "/disable")
                {
                    mainGUI.setProxy("", false, false);
                    return;
                }
                else if (args[0] == "/enable")
                {
                    if (args[1] != "")
                    {
                        try
                        {
                            if (args[2] == "/bypass")
                            {
                                mainGUI.setProxy(args[1], true, true);
                            }
                        }
                        catch
                        {
                            mainGUI.setProxy(args[1], true, false);

                        }
                    }
                    return;
                }
                else if (args[0] == "/?")
                {
                    MessageBox.Show(Resources.CommandLine_Arguments, "ProxyChanger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}
