using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void Fight(Character fighter, Character defender)
        {
            Random rand = new Random();

            int Damage = rand.Next(1, 101);

            System.Threading.Thread.Sleep(30);
            

            if(Damage <= (fighter.CalcHitChance() - defender.CalcBlock()))
            {
                int damageDealt = fighter.CalcDamage();

                defender.Life -= damageDealt;

                Console.WriteLine(fighter.Name + " dealt " + defender.Name + " "+ damageDealt + " Wow!!");
            }
            else
            {
                Console.WriteLine("Swing and a miss!");
            }
                
        }


        public static void Tussle(Player player, Monster monster)
        {
            Fight(player, monster);

            if (monster.Life > 0)
            {
                Fight(monster, player);
            }
        }
    }
}
