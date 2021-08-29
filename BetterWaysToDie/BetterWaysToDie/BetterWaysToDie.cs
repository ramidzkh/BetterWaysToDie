using System.Diagnostics;
using BetterWaysToDie.Builder;
using BetterWaysToDie.Gui;
using BetterWaysToDie.Mixins;
using BetterWaysToDie.Mixins.Accessor;
using BetterWaysToDie.Mod;
using BetterWaysToDie.Registry;
using UnityEngine;

namespace BetterWaysToDie.BetterWaysToDie {
    public class BetterWaysToDie : IMod {

        public void Initialize()
        {
            Registry<Block>.Event += registry =>
            {
                registry["crab"] = new BlockBuilder("crab")
                    .Build();
            };

            // var windowManager = GameManager.Instance.As<GameManagerAccessor>().windowManager;
            // var testGuiWindow = new TestGuiWindow(GameManager.Instance);
            // windowManager.Add("testWindow", testGuiWindow);
            // testGuiWindow.Open();
        }
    }
}