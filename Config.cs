namespace HelveHammerExtensions
{
    public class Config
    {
        // Will this work for any items
        public bool AllWorkable { get; set; } = false;

        // Default behavior
        public bool DefaultWorkable { get; set; } = true;

        // Minimum anvil tier (1 - copper, 2 - bronze, 3 - iron, 4 - steel in vanilla)
        public int AnvilTier { get; set; } = 3;
    }
}
