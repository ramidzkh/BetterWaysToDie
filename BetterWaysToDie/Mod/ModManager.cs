using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BetterWaysToDie.Mod
{
    internal static class ModManager
    {
        private static readonly IEnumerable<IMod> Mods = InitializeMods().ToList();

        private static IEnumerable<IMod> InitializeMods()
        {
            return from type in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(IMod).IsAssignableFrom(type)
                select (IMod) Activator.CreateInstance(type);
        }

        internal static void Initialize()
        {
            foreach (var mod in Mods)
            {
                mod.Initialize();
            }
        }
    }
}
