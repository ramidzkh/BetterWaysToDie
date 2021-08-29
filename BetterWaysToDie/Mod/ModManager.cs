using System;
using System.Collections.Generic;
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
            return from type in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(IMod).IsAssignableFrom(type) && type.IsClass
                select (IMod) Activator.CreateInstance(type);
        }

        internal static void Initialize()
        {
            Debug.LogWarning("======================================");
            Debug.LogWarning("Better Ways To Die Mod Loader (1 mod)");
            Debug.LogWarning("======================================");

            foreach (var mod in Mods)
            {
                mod.Initialize();
            }
        }
    }
}