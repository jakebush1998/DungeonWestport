using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }//CONTAINMENT

        public Player(string name, int hitChance, int block, int maxLife, int life, Race characterRace, Weapon equippedWeapon) : base(name, hitChance, block, maxLife, life)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            //Potential Expansion - Modify prop values based on the chosen Race
            switch (CharacterRace)
            {
                case Race.Commoner:
                    break;
                case Race.Barista:
                    break;
                case Race.ArtStudent:
                    HitChance += 5;
                    break;
                case Race.WebDeveloperStudent:
                    break;
                case Race.CentriqTrainer:
                    break;
                case Race.FireFighter:
                    break;
                case Race.Gamer:
                    break;
                default:
                    break;
            }
        }//FQ Ctor

        public override string ToString()
        {
            string description = "";
            switch (CharacterRace)
            {
                case Race.Commoner:
                    description = "Commoner";
                    break;
                case Race.Barista:
                    description = "Barista";
                    break;
                case Race.ArtStudent:
                    description = "ArtStudent";
                    break;
                case Race.WebDeveloperStudent:
                    description = "WebDeveloperStudent";
                    break;
                case Race.CentriqTrainer:
                    description = "CentriqTrainer";
                    break;
                case Race.FireFighter:
                    description = "FireFighter";
                    break;
                case Race.Gamer:
                    description = "Gamer";
                    break;
            }//end switch

            return base.ToString() + $"\nWeapon: {EquippedWeapon.Name}\n" +
                                     $"Total Hit Chance: {CalcHitChance()}\n" +
                                     $"Description: {description}";
        }//end ToString();

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }//end CalcDamage() override
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}
