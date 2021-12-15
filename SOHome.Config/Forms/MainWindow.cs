using Gtk;

using System.Linq;
using SOHome.Common;
using SOHome.Common.Models;

using System;

using UI = Gtk.Builder.ObjectAttribute;

namespace SOHome.Config.Forms
{
    internal class MainWindow : Window
    {
        [UI] private readonly Entry txtDbHost = null;
        [UI] private readonly Entry txtDbPort = null;
        [UI] private readonly Entry txtDbName = null;
        [UI] private readonly Entry txtDbUser = null;
        [UI] private readonly Entry txtDbPassword = null;
        [UI] private readonly Button btnSave = null;
        [UI] private readonly ComboBoxText cmbThemes = null;

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
            cmbThemes.AppendText("");
            int index = 0;
            int selectedIndex = 0;
            foreach (var fullThemeName in themeNames)
            {
                index++;
                var themeName = System.IO.Path.GetFileName(fullThemeName);
                if (AppSettings.Settings.Theme == themeName)
                    selectedIndex = index;
                cmbThemes.AppendText(themeName);
            }

            txtDbHost.Text = AppSettings.Settings?.Database?.Host;
            txtDbPort.Text = AppSettings.Settings?.Database?.Port;
            txtDbName.Text = AppSettings.Settings?.Database?.Name;
            txtDbUser.Text = AppSettings.Settings?.Database?.User;
            txtDbPassword.Text = AppSettings.Settings?.Database?.Password;

            cmbThemes.Active = selectedIndex;
        }

        private void CmbThemes_Changed(object sender, EventArgs e)
        {
            try
            {
                Module.ApplyTheme(cmbThemes.ActiveText);
            }
            catch (Exception)
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
            try
            {
                AppSettings.Settings.Theme = cmbThemes.ActiveText;
                var database = new Database
                {
                    Host = txtDbHost.Text,
                    Port = txtDbPort.Text,
                    Name = txtDbName.Text,
                    User = txtDbUser.Text,
                    Password = txtDbPassword.Text
                };
                AppSettings.Settings.Database = database;
                AppSettings.Save();

                MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Info,
                ButtonsType.Close, "Configurações salvas com sucesso!");
                md.Run();
                md.Destroy();
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Error,
                ButtonsType.Close, "Ocorreu um erro ao salvar as configurações!");
                md.Run();
                md.Destroy();
            }
        }
    }
}
