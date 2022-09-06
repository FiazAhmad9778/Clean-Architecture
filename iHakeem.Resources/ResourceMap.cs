using System.IO;
using System.Reflection;

namespace iHakeem.Resources
{
    public static class ResourceMap
    {
        private const string LocalizationsDir = "Localizations";

        public static string GetLocalizationsRootPath()
        {
            string assemblyDir = GetAssemblyDir();
            return Path.Combine(assemblyDir, LocalizationsDir);
        }

        private static string GetAssemblyDir()
        {
            Assembly assembly = typeof(ResourceMap).Assembly;
            return Path.GetDirectoryName(assembly.Location);
        }
    }
}
