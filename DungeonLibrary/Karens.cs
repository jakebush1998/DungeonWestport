using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Karens : Monster
    {
        public bool IsTalkingToManager { get; set; }

        public Karens(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description, bool isTalkingToManager)
            : base(name, life, maxLife, hitChance, block, maxDamage,
            minDamage, description)
        {
            IsTalkingToManager = isTalkingToManager;
        }

        public override string ToString()
        {
            return base.ToString() + (IsTalkingToManager ? "She's speaking to your manager now" : "She only sent your food back");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsTalkingToManager)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}