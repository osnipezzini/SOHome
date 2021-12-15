using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace SOHome.Config.Gtk.Forms
{
    class MainWindow : Window
    {
        [UI] private Entry txtDbPassword = null;
        [UI] private Button btnSave = null;

        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            var img = Module.GetResource("logo-sohome.svg");
            Icon = new Gdk.Pixbuf(img);
            //Icon = Gdk.Pixbuf.LoadFromResource("SOHome.Config.Gtk.Resources.logo-sohome.svg");

            DeleteEvent += Window_DeleteEvent;
            btnSave.Clicked += Button1_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            _counter++;
            txtDbPassword.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
        }
    }
}
