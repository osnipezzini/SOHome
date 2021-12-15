using System.IO;
using System.Reflection;

namespace SOHome.Config.Gtk
{
    internal class Module
    {
        public static Stream GetResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = $"{assembly.GetName().Name}.Resources.{resourceName}";
            return assembly.GetManifestResourceStream(fileName);
        }
    }
}
