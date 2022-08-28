using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SOHome.Fitness.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum @enum)
        {
            var assembly = @enum.GetType().Assembly;
            var att = assembly.GetCustomAttribute<DisplayAttribute>();
            return att.Name;
        }
    }
}
