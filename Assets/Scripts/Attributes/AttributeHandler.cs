using System.Collections.Generic;
using UnityEngine;

namespace Attributes
{
    public static class Handler
    {
        private static readonly Dictionary<FishTypes, Dictionary<Types, int>> AllStats = new();

        static Handler()
        {
            AllStats.Add(FishTypes.MAIN, new Dictionary<Types, int>
            {
                { Types.Speed, 15 },
                { Types.Health, 5 },
                { Types.Agility, 1 }
            });

            AllStats.Add(FishTypes.ENEMY_SMALL, new Dictionary<Types, int>
            {
                { Types.Speed, 5 },
                { Types.Health, 5 },
                { Types.Agility, 1 }
            });
        }

        public static Dictionary<Types, int> GetAttributesForFish(FishTypes type)
        {
            return AllStats[type];
        }
    }
}