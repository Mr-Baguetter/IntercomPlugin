using System;
using Exiled.API.Features;
using HarmonyLib;

namespace IntercomPlugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "IntercomPlugin";
        public override string Author { get; } = "Aran";
        public override string Prefix { get; } = "intercomplugin";
        public override Version Version { get; } = new Version(1, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(9, 5, 2);
        
        private static Harmony harmony;

        public override void OnEnabled()
        {
            instance = this;
            harmony = new Harmony("testid");
            harmony.PatchAll();
            Log.Info("========================================");
            Log.Info("Enabled: Created by: Aran.");
            Log.Info("Thank you for using it!");
            Log.Info("========================================");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            harmony.UnpatchAll(harmony.Id);
            harmony = null;
            instance = null;
            Log.Info("========================================");
            Log.Info("Disabled: Created by: Aran.");
            Log.Info("Thank you for using it!");
            Log.Info("========================================");
            base.OnDisabled();
        }
        
        public static Plugin instance;
    }
}