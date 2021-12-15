using Gdk;

using System.IO;
using System.Reflection;

namespace SOHome.Config
{
    internal class Module
    {
        private static Pixbuf _iconInstance;
        public static Stream GetResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = $"{assembly.GetName().Name}.Resources.{resourceName}";
            return assembly.GetManifestResourceStream(fileName);
        }

        public static Pixbuf Icon
        {
            get
            {
                if (_iconInstance == null)
                {
                    var imgResource = GetResource("logo-sohome.svg");
                    _iconInstance = new Pixbuf(imgResource);
                }
                return _iconInstance;
            }
        }

        public static void ApplyTheme(string themeName = null)
        {
            // Based on this Link http://awesome.naquadah.org/wiki/Better_Font_Rendering

            // Get the Global Settings
            var setts = Gtk.Settings.Default;
            // This enables clear text on Win32, makes the text look a lot less crappy
            setts.XftRgba = "rgb";
            // This enlarges the size of the controls based on the dpi
            //setts.XftDpi = 96;
            // By Default Anti-aliasing is enabled, if you want to disable it for any reason set this value to 0
            //setts.XftAntialias = 0
            // Enable text hinting
            setts.XftHinting = 1;
            //setts.XftHintstyle = "hintslight"
            setts.XftHintstyle = "hintfull";

            // Load the Theme
            Gtk.CssProvider css_provider = new Gtk.CssProvider();
            //css_provider.LoadFromPath("themes/DeLorean-3.14/gtk-3.0/gtk.css")
            css_provider.LoadFromPath($"Assets/Themes/{themeName ?? "Sweet"}/gtk-3.0/gtk.css");
            Gtk.StyleContext.AddProviderForScreen(Gdk.Screen.Default, css_provider, 800);
        }
    }
}
