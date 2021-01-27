using System;

namespace Framework.Models
{
    public class MirrorCard : Card
    {
        public string Name { get; set; } = "Mirror";

        public int Cost { get; set; } = 1;

        public string Rarity { get; set; } = "Epic";

        public string Type { get; set; } = "Spell";

        public string Arena { get; set; } = "Arena 12";
    }
}
