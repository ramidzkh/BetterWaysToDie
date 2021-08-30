using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace BetterWaysToDie.Mod
{
    internal static class ModManager
    {
        private static readonly IEnumerable<IMod> Mods = InitializeMods().ToList();

        private static IEnumerable<IMod> InitializeMods()
        {
            var assemblies = new List<Assembly>
            {
                Assembly.GetExecutingAssembly()
            };

            var mods = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Better Ways To Die",
                "Mods");

            if (Directory.Exists(mods))
            {
                assemblies.AddRange(Directory.EnumerateFiles(mods, "*.dll").Select(Assembly.Load));
            }
            else
            {
                Directory.CreateDirectory(mods);
            }

            return from type in assemblies.SelectMany(assembly => assembly.GetTypes())
                where typeof(IMod).IsAssignableFrom(type) && type.IsClass
                select (IMod) Activator.CreateInstance(type);
        }

        internal static void Initialize()
        {
            Debug.LogWarning("======================================");
            Debug.LogWarning($"Better Ways To Die Mod Loader ({Mods.Count()} mods)");
            Debug.LogWarning("======================================");

            foreach (var mod in Mods)
            {
                mod.Initialize();
            }
        }
    }
}
