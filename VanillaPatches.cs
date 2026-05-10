using System.Text;
using HarmonyLib;
using Vintagestory.API.Common;

namespace HelveHammerExtensions
{
    public class VanillaPatches : ModSystem
    {
        private Harmony? harmonyInstance;

        public override void Start(ICoreAPI api)
        {
            harmonyInstance = new Harmony(Mod.Info.ModID);
            harmonyInstance.PatchAll();

            var builder = new StringBuilder("Harmony Patched Methods: ");
            foreach (var val in harmonyInstance.GetPatchedMethods())
            {
                builder.Append(val.Name + ", ");
            }
            Mod.Logger.Notification(builder.ToString());
        }

        public override void Dispose()
        {
            harmonyInstance?.UnpatchAll(Mod.Info.ModID);
        }
    }
}
