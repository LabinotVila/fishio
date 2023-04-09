using System.Collections.Generic;

namespace Attributes
{
    public static class Metadata
    {
        private static readonly Dictionary<Specie.Type, Basic> AllStats = new();

        static Metadata()
        {
            var npcAttributes = new Basic(5, 1, 1);
            AllStats.Add(Specie.Type.Basic, npcAttributes);
            
            var playerAttributes = new Player(15, 1, 1, 1);
            AllStats.Add(Specie.Type.Player, playerAttributes);
        }

        public static Basic GetForFish(Specie.Type type)
        {
            return AllStats[type];
        }
    }
}