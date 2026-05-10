using System;
using Vintagestory.API.Common;

namespace HelveHammerExtensions
{
    public class Core : ModSystem
    {
        public static Config Config { get; private set; } = new Config();

        public override void Start(ICoreAPI api)
        {
            Config? loaded = null;
            try
            {
                loaded = api.LoadModConfig<Config>("helvehammerext.json");
            }
            catch (Exception ex)
            {
                Mod.Logger.Warning("Could not read helvehammerext.json ({0}); resetting to defaults.", ex.Message);
            }

            Config = loaded ?? new Config();
            api.StoreModConfig(Config, "helvehammerext.json");
        }
    }
}
