using System;
using Gtk;

using SOHome.Common;
using SOHome.Config.Forms;

namespace SOHome.Config
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();
            try
            {
                Module.ApplyTheme(AppSettings.Settings.Theme);                 
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }

            var app = new Application("org.SOHome.Config.Gtk.SOHome.Config.Gtk", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }
    }
}
