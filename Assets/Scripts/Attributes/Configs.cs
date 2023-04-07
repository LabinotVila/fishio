using System.Collections.Generic;

namespace Attributes
{
    public static class Configs
    {
        private static readonly Dictionary<Specie.Type, Dictionary<Type, ValueGrowth>> AllStats = new();

        static Configs()
        {
            AllStats.Add(Specie.Type.Main, new Dictionary<Type, ValueGrowth>
            {
                { Type.Speed, new ValueGrowth(15, 0.15) },
                { Type.Health, new ValueGrowth(5, 0.1) },
                { Type.Agility, new ValueGrowth(1, 0.05) }
            });

            AllStats.Add(Specie.Type.EntrySmall, new Dictionary<Type, ValueGrowth>
            {
                { Type.Speed, new ValueGrowth(5, 0.15) },
                { Type.Health, new ValueGrowth(4, 0.1) },
                { Type.Agility, new ValueGrowth(1, 0.05) }
            });
        }

        public static Dictionary<Type, ValueGrowth> GetForFish(Specie.Type type)
        {
            return AllStats[type];
        }
    }
}