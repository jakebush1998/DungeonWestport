using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class DMVClerk : Monster
    {
        //fields/properties
        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }

        //constructor
        public DMVClerk(string name, int life, int maxLife, int hitChance,
            int block, int minDamage, int maxDamage, string description,
            int bonusBlock, int hidePercent)
            : base(name, life, maxLife, hitChance, block, maxDamage,
            minDamage, description)
        {
            //just handle unique ones
            BonusBlock = bonusBlock;
            HidePercent = hidePercent;

        }//end FQ Ctor

        //methods
        public override string ToString()
        {
            return string.Format("{0}\nChance it'll say you have the wrong papers: {1}%" +
                " and then it has a bonus block of {2}",
                base.ToString(), HidePercent, BonusBlock);
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            //get a number from 0-100
            Random rand = new Random();
            int percent = rand.Next(101);

            //see if that is less than or equal to the hide percent
            if (percent <= HidePercent)
            {
                //if so, add the bonus block
                calculatedBlock += BonusBlock;
            }
            //return the calculated block
            return calculatedBlock;
        }//end calcblock
    }
}
