using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RockPaperScissorsCore
{
    
    public class Battle
    {
        public WeaponStore WeaponsAvailable { get; private set; }
        public IPlayer PlayerOne { get; private set; }
        public IPlayer PlayerTwo { get; private set; }
        public List<string> Winners { get; set; } = new List<string>();
        public List<string> WeaponsUsed { get; set; } = new List<string>();
        public bool BattleOver { get; set; } = false;
        public int Rounds { get; set; } = 1;

            
        // CTOR - Each battle needs 2 players and a selection of weapons (depending on level difficulty)
        public Battle(IPlayer player1, IPlayer player2, WeaponStore weaponStore)
        {
            PlayerOne = player1;
            PlayerTwo = player2;
            WeaponsAvailable = weaponStore;
        }
            
        // METHOD - Contains each Round and Controls bool Battle Over
        public void Fight()
        {
            Console.WriteLine("Welcome To The Fighting Arena {0} and {1} \n", PlayerOne.Name, PlayerTwo.Name);
       
            WeaponMenu();


            while (!BattleOver)
            {
                Console.WriteLine("\nRound " + Rounds + "\n");
                    

                PlayerChooseWeapon(PlayerOne);
                PlayerChooseWeapon(PlayerTwo);

                    

                Console.WriteLine(BattleOutcome());

                Console.WriteLine("Fight Again? Press Y to play again or any key to quit...");
                var choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Rounds++;
                    Console.Clear();
                    WeaponMenu();
                    BattleOver = false;
                }
                else
                {
                    BattleOver = true;
                } 

            }
            BattleData();

            Console.Write("\nPress any key to return to main menu...");
            Console.ReadLine();
            Console.Clear();
            GameUI.PlayWelcomeScreen();
        }

        // Takes the WeaponsAvailable in the Battle Instance, Iterates and returns a printed weapon menu
        private void WeaponMenu()
        {
            Console.WriteLine("Weapons to choose from: \n");
            var weaponsAvailable = WeaponsAvailable.Weapons;
            for (var i = 0; i < weaponsAvailable.Count(); i++)
            {
                Console.WriteLine(i + ": " + weaponsAvailable[i].WeaponName);
            }

            Console.WriteLine("\n");
        }

        // Determines if the player is of type Computer or Human.  If Computer, makes a random choice based
        // on the number of weapons available for the particular battle.
        private void PlayerChooseWeapon(IPlayer player)
        {
            if (player.GetType() == typeof(ComputerPlayer))
            {
                Console.WriteLine("\n" + player.Name + " is thinking...");
                Thread.Sleep(2000);
                Console.WriteLine("OK " + player.Name + " has chosen.");
                int choice = new Random().Next(WeaponsAvailable.Weapons.Count());
                player.CurrentWeapon = WeaponsAvailable.Weapons[choice];
            }
            else
            {
                Thread.Sleep(1000);
                Console.Write("\n" + player.Name + " choose your weapon: ");
                var choice = CheckPlayerChooseWeaponInput();
                    
                player.CurrentWeapon = WeaponsAvailable.Weapons[choice];

            }
        }
            

        // CHECK FUNCTION - Prevents Human players entering invalid weapon selection or choosing 
        // a number out of range of the available weapons List
        private int CheckPlayerChooseWeaponInput()
        {
            var choice = Console.ReadLine();
            int number;

            bool success = Int32.TryParse(choice, out number);
            while (success && (number < WeaponsAvailable.Weapons.Count() && number >= 0))
            {
                return Convert.ToInt32(choice);
            }

            Console.WriteLine("Input was invalid.  Try again");
            return CheckPlayerChooseWeaponInput();

        }

            
        // Method to determine winner of Round.
        // Compares Weapon Types to determine winner.
        // Uses the CanBeat List fields of the Weapon Type to determine if opponent has a weapon that you can beat.
        private string BattleOutcome()
        {
            WeaponsUsed.Add(PlayerOne.CurrentWeapon.WeaponName);
            WeaponsUsed.Add(PlayerTwo.CurrentWeapon.WeaponName);

            var p1Weapon = PlayerOne.CurrentWeapon.GetType();
            var p2Weapon = PlayerTwo.CurrentWeapon.GetType();

            var message = String.Format("\n{0} chose {1}, {2} chose {3}. ",
                                        PlayerOne.Name,
                                        PlayerOne.CurrentWeapon.WeaponName,
                                        PlayerTwo.Name,
                                        PlayerTwo.CurrentWeapon.WeaponName);
                
            // Determines winner and adds names to Winners List for sorting after the battle
            // Both names are added if a draw.  Only winners name is added for a win.
            if (p1Weapon == p2Weapon)
            {
                Winners.Add(PlayerOne.Name);
                Winners.Add(PlayerTwo.Name);
                return message + "It's A Draw";
            }
            else if (PlayerOne.CurrentWeapon.CanBeat.Contains(p2Weapon))
            {
                Winners.Add(PlayerOne.Name);
                return message + PlayerOne.Name + " is the WINNER";
            }
            else
            {
                Winners.Add(PlayerTwo.Name);
                return message + PlayerTwo.Name + " is the WINNER";
            }

        }

        // Collates the battle data from the different methods and prints a summary of battle on screen
        private void BattleData()
        {
            Console.Clear();
            Thread.Sleep(1500);
            Console.WriteLine("\n \n This strongly fought Contest took place over {0} rounds", Rounds);
            Console.WriteLine("*******************************************************");
            WinnersInBattle();
            MostUsedWeaponsInBattle();
        }
            
        // Iterates through WeaponsUsed List to determine which weapons, and how often they were used
        // in the battle.  Sorts them in descending order and prints the results to the console.
        private void MostUsedWeaponsInBattle()
        {
            Console.WriteLine("\nWeapons used in this battle");
            var result = WeaponsUsed
                .GroupBy(weaponname => weaponname)
                .OrderByDescending(weapongroup => weapongroup.Count())
                .ToList();
            result.ForEach(weapongroup => Console.WriteLine("{0} x {1} used.", weapongroup.Count(), weapongroup.Key));
        }
            

        
        // Iterates through Winners List.  Counts the times a name is in the winners array and displays 
        // the points of the players.
        private void WinnersInBattle()
        {
            Console.WriteLine("\nPlayer Points (1 each for a draw, 1 for the winner)\n");
            var result = Winners
                .GroupBy(winnername => winnername)
                .OrderByDescending(winnergroup => winnergroup.Count())
                .ToList();

            result.ForEach(winnergroup => Console.WriteLine("{0} has {1} points.", winnergroup.Key, winnergroup.Count()));


            // In the event of only one player having points (therefore only one name in the winners List)
            // This ensures a message of 0 points for the loser. 
            if(result.Count() == 1)
            {
                var message = " has 0 points.";
                Console.WriteLine(
                PlayerOne.Name == result[0].Key ? PlayerTwo.Name + message : PlayerOne.Name + message
                ); 
            }
        }
    }
    
}
