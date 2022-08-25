using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class ZombieHipster : Monster
    {

        //fields/properties (using autos)
        public bool IsRotting { get; set; }

        //constructors, create an FQ ctor, that we can use to make a super bad monster
        public ZombieHipster(string name, int life, int maxLife, int hitChance,
            int block, int minDamage, int maxDamage, string description,
            bool isRotting)
            : base(name, life, maxLife, hitChance, block, maxDamage,
            minDamage, description)
        {
            //just handle unique ones
            IsRotting = IsRotting;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsRotting ? "Rotting" : "Not so Rotting...");
        }

        //override the block to say if they are fluffy they get a bonus
        //50% to their block value
        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsRotting)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}