using System;
using System.Reflection;

using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace SOHome.Config.Forms
{
    class MainWindow : Window
    {
        [UI] private Entry txtDbPassword = null;
        [UI] private Button btnSave = null;
        [UI] private ComboBoxText cmbThemes = null;

        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            Icon = Module.Icon;

            DeleteEvent += Window_DeleteEvent;
            btnSave.Clicked += SaveButton_Clicked;

            cmbThemes.Changed += CmbThemes_Changed;

            var themeDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Themes");
            var themeNames = System.IO.Directory.GetDirectories(themeDir);
            foreach (var themeName in themeNames)
                cmbThemes.AppendText(System.IO.Path.GetFileName(themeName));
        }

        private void CmbThemes_Changed(object sender, EventArgs e)
        {
            try
            {
                Module.ApplyTheme(cmbThemes.ActiveText);
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Error,
                ButtonsType.Close, "Tema incompatível");
                md.Run();
                md.Destroy();

                Module.ApplyTheme();
            }
            
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void SaveButton_Clicked(object sender, EventArgs a)
        {
            _counter++;
            txtDbPassword.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
        }
    }
}
