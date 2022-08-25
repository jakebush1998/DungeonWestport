using DungeonLibrary;

namespace DungeonApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DUNGEON OF WESTPORT";
            Console.WriteLine("Your journey begins...\n");

            int score = 0;//declare this running variable outside of the main do while loop. It can then be displayed inside of the menu (Player Info option) or at the end of the game (exit or die).

            #region Player Creation

            Weapon HotSauce = new Weapon(1, 8, "Taco Bell Hot Sauce Packets", 10, false, WeaponType.TacoBelLHotSaucePackets);
            /*
            //Possible Expansion: 
            //Allow player to define chatacter name
            Console.Write("Enter your name: ");
            //string userName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome, {0}! Your journey begins...", userName);
            Console.ReadKey();
            Console.Clear();
            */
            Player player = new Player("Jonathan Pedroza", 70, 5, 40, 40, Race.WebDeveloperStudent, HotSauce);
            #endregion



            bool exit = false;// both loops
            do
            {
                //create a monster -- random monster generator in the Monster class; creates a list of 4 different monsters and randomly selects one of them.
                Monster monster = Monster.GetMonster();
                //create a room
                Console.WriteLine(GetRoom() + $"\nIn this room: {monster.Name}");


                bool reload = false;//inner loop (menu) -- when set to true, will 'reload' a new room with a new monster.

                #region MENU
                //Could extract this into another class library (like an Engine - a class library that houses basic functionality not specific to any datatype class)

                do
                {
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    string choice = Console.ReadKey(true).Key.ToString().ToLower();
                    Console.Clear();

                    switch (choice)
                    {
                        case "a":
                            Console.WriteLine("Attack!");
                            
                            //TODO Combat functionality
                            //If the player wins, leave the inner loop (repeat the outer loop)
                            //If the monster wins, you're dead (leave both loops)
                            break;

                        case "r"://leave the inner loop (into the outer loop)
                            Console.WriteLine("Run away!!!!");
                            reload = true;//UPDATE
                            break;

                        case "p":
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;
                        case "m":
                            Console.WriteLine("Monster Info");
                            //Print monster info
                            Console.WriteLine(monster);
                            break;

                        case "x":
                        case "e":
                        case "escape":
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;//UPDATE -- leave both loops
                            break;
                        default:
                            Console.WriteLine(choice);
                            Console.WriteLine("Input not understood, please try again");
                            break;
                    }//end switch
                } while (!reload && !exit); //if either reload or exit become true, it will exit the inner loop (menu).
                                            //reload == false, != true, !reload

                #endregion

            } while (!exit);// while exit is NOT TRUE, keep looping
            Console.WriteLine("Thanks for playing! Final score: " + score);
        }//end Main()

        private static string GetRoom()
        {
            string[] rooms = new string[]
            {
                "You enter the westport coffee house and find that everyone is a zombie... literally!",
                "You come across a scene of burning and flipped cars and yet the there's still a line at the drive thru...",
                "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                "You enter the TacoBell off broadway and they're out of beans...",
                "As you enter the room, you realize you're the only human there...",
                "Oh my.... what am I stepping on? You appear to be standing in a pile of broken bird scooters..",
                "You enter a dark restaurant and all you can hear is someone complaining to the manager...",
                "Oh no.... the worst of them all... panchos....",
                "You wake up to find yourself on a business zoom call, you stand up and you're only in your underpants!?!?",
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;

            //return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom()
    }//end class
}//end namespace