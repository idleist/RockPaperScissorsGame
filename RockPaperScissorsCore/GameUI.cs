using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RockPaperScissorsCore
{
    public static class GameUI
    {
        public static void PlayWelcomeScreen()
        {
            var title = @"

        ______           _       ______                       _____      _                        
        | ___ \         | |      | ___ \                     /  ___|    (_)                       
        | |_/ /___   ___| | __   | |_/ /_ _ _ __   ___ _ __  \ `--.  ___ _ ___ ___  ___  _ __ ___ 
        |    // _ \ / __| |/ /   |  __/ _` | '_ \ / _ \ '__|  `--. \/ __| / __/ __|/ _ \| '__/ __|
        | |\ \ (_) | (__|   < _  | | | (_| | |_) |  __/ |_   /\__/ / (__| \__ \__ \ (_) | |  \__ \
        \_| \_\___/ \___|_|\_( ) \_|  \__,_| .__/ \___|_( )  \____/ \___|_|___/___/\___/|_|  |___/
                             |/            | |          |/                                        
                                           |_|                                                              
        
        Welcome Feeble Humans to my battle lair.  I am The Great Bob!, 45th Dan in the ancient art
        of ROCK, PAPER and SCISSORS.  Do you dare take me on in the greatest battle of wits, bravery 
        and skill ever created.... MWAAA HAAHAA HAA HAA!
        ";


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(title);
            ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.WriteLine(@"
//*** Game Menu ***\\
            
(Choose an option)
1. 1 Player Mode (Go on, be brave and face me!)
2. 2 Player Mode (Wimpy mortals, too scared to face the GREAT BOB!!)
3. Show Instructions (as if you don't know how to play Rock, Paper, Scissors)
4. Quit The Game (Go on... Runaway!!)

");

            Console.Write("Enter Selection (1 - 4): ");

            var menuChoice = Console.ReadLine();

            MenuChoice(menuChoice);
        }

        public static void MenuChoice(string menuChoice)
        {
            switch (menuChoice)
            {
                case "1":
                    InitiateOnePlayerGame();
                    break;
                case "2":
                    InitiateTwoPlayerGame();
                    break;
                case "3":
                    ShowInstructions();
                    break;
                case "4":
                    QuitGame();
                    break;
                default:
                    Console.WriteLine("Incorrect Choice.  Please Enter another number");
                    menuChoice = Console.ReadLine();
                    MenuChoice(menuChoice);
                    break;
            }
        }


        private static void QuitGame()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine(@"
            
            
             _____   ___  ___  ___ _____   _____  _   _ ___________ 
            |  __ \ / _ \ |  \/  ||  ___| |  _  || | | |  ___| ___ \
            | |  \// /_\ \| .  . || |__   | | | || | | | |__ | |_/ /
            | | __ |  _  || |\/| ||  __|  | | | || | | |  __||    / 
            | |_\ \| | | || |  | || |___  \ \_/ /\ \_/ / |___| |\ \ 
             \____/\_| |_/\_|  |_/\____/   \___/  \___/\____/\_| \_|
                                                        
             Oh, you've had enough have you.  You will never be a great 
                        RPS warrior with that attitude!                                           

");
            Thread.Sleep(1500);
        }
        public static void DisplayCountdown()
        {
            Console.WriteLine(@"
 __      
/  |     
`| |     
 | |     
_| |_  _ 
\___/ (_)
         
");
            Thread.Sleep(1000);
            Console.WriteLine(@"
 _____          
/ __  \         
`' / /'         
  / /           
./ /___  _   _  
\_____/ (_) (_) 
                                
");
            Thread.Sleep(1000);
            Console.WriteLine(@"
 _____             
|____ |            
    / /            
    \ \            
.___/ /  _   _   _ 
\____/  (_) (_) (_)
                   
");
            Thread.Sleep(1000);
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine(@"
            |  ___|_   _|  __ \| | | |_   _| | |
            | |_    | | | |  \/| |_| | | | | | |
            |  _|   | | | | __ |  _  | | | | | |
            | |    _| |_| |_\ \| | | | | | |_|_|
            \_|    \___/ \____/\_| |_/ \_/ (_|_)

");
            Thread.Sleep(1000);
        }

        public static void ShowInstructions()
        {
            Console.Clear();
            Console.WriteLine(@"
            Battle Rules - Outcomes
            
            Rock CRUSHES Scissors, Rock SMASHES Lizard.
            Paper SMOTHERS Rock, Paper BAFFLES Spock.
            Scissors SLICE Paper, Scissor DECAPITATE Lizard.
            Lizard EATS Paper, Lizard DEVOURS Spock.
            Spock VAPOURIZES Rock, Spock BLUNTS Scissors.
            
            Press Any Key To Return To Menu...
            ");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }

        public static WeaponStore InitiateLevelDifficulty()
        {
            Console.WriteLine(@"
Would you like to play: 
1: traditional ROCK, PAPER, SCISSORS
2: advanced ROCK, PAPER, SCISSORS, LIZARD, SPOCK

");
            Console.Write("Enter choice (1 or 2): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                return new WeaponStore(new Rock(), new Paper(), new Scissors());
            }
            else if (choice == "2")
            {
                return new WeaponStore(new Rock(), new Paper(), new Scissors(), new Spock(), new Lizard());
            }
            else
            {
                Console.WriteLine("incorrect input, please choose again");
                return InitiateLevelDifficulty();
            }
        }
        private static void InitiateOnePlayerGame()
        {
            Console.Clear();
            Console.WriteLine(@"
               
             _____             ______ _                        ______       _   _   _       
            |  _  |            | ___ \ |                       | ___ \     | | | | | |      
            | | | |_ __   ___  | |_/ / | __ _ _   _  ___ _ __  | |_/ / __ _| |_| |_| | ___  
            | | | | '_ \ / _ \ |  __/| |/ _` | | | |/ _ \ '__| | ___ \/ _` | __| __| |/ _ \ 
            \ \_/ / | | |  __/ | |   | | (_| | |_| |  __/ |    | |_/ / (_| | |_| |_| |  __/ 
             \___/|_| |_|\___| \_|   |_|\__,_|\__, |\___|_|    \____/ \__,_|\__|\__|_|\___| 
                                               __/ |                                        
                                              |___/                                         


            ");
            Console.Write("\nPlayer One, Enter Your Name: ");
            var name = Console.ReadLine();
            var playerOne = new HumanPlayer(string.IsNullOrWhiteSpace(name) ? "Player One" : name);

            var weaponStore = InitiateLevelDifficulty();
            Battle onePlayerBattle = new Battle(playerOne, new ComputerPlayer(), weaponStore);
            DisplayCountdown();
            onePlayerBattle.Fight();

        }

        private static void InitiateTwoPlayerGame()
        {
            Console.Clear();
            Console.WriteLine(@"
             _____              ______ _                        ______       _   _   _       
            |_   _|             | ___ \ |                       | ___ \     | | | | | |      
              | |_      _____   | |_/ / | __ _ _   _  ___ _ __  | |_/ / __ _| |_| |_| | ___  
              | \ \ /\ / / _ \  |  __/| |/ _` | | | |/ _ \ '__| | ___ \/ _` | __| __| |/ _ \ 
              | |\ V  V / (_) | | |   | | (_| | |_| |  __/ |    | |_/ / (_| | |_| |_| |  __/ 
              \_/ \_/\_/ \___/  \_|   |_|\__,_|\__, |\___|_|    \____/ \__,_|\__|\__|_|\___| 
                                                __/ |                                        
                                               |___/                                         
");
            Console.Write("\nPlayer One, Enter Your Name: ");
            var p1name = Console.ReadLine();
            var playerOne = new HumanPlayer(string.IsNullOrWhiteSpace(p1name) ? "Player One" : p1name);

            Console.Write("\nPlayer Two, Enter Your Name: ");
            var p2name = Console.ReadLine();
            var playerTwo = new HumanPlayer(string.IsNullOrWhiteSpace(p2name) ? "Player Two" : p2name);

            var weaponStore = InitiateLevelDifficulty();
            Battle twoPlayerBattle = new Battle(playerOne, playerTwo, weaponStore);

            DisplayCountdown();
            twoPlayerBattle.Fight();

        }
    }
}
