using VRage.Plugins;
using HarmonyLib;
using System.Reflection;
using Sandbox.Game.Gui;

namespace avaness.UnlimitedScriptLength
{
    public class Main : IPlugin
    {
        public void Dispose()
        {

        }

        public void Init(object gameInstance)
        {
            Harmony harmony = new Harmony("avaness.UnlimitedScriptLength");
            MethodInfo target = typeof(MyGuiScreenEditor).GetMethod("TextTooLong", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo patch = typeof(Main).GetMethod("TextTooLong", BindingFlags.Static | BindingFlags.Public);
            harmony.Patch(target, new HarmonyMethod(patch));
        }

        public void Update()
        {

        }

        public static bool TextTooLong(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}
