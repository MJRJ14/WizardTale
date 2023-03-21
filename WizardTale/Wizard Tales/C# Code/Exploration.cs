﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardTale;
using Wizard_Tales.IntroC;
using Wizard_Tales.WizardC;
using Wizard_Tales.SaveAndLoad;
using Wizard_Tales.WorldMethodsC;

namespace Wizard_Tales.ExplorationC
{
    public class Exporation
    {
        public int ExplorationAttempt { get; set; } = 0;
        public void ExporationChance()
        {
            Random random = new Random();
            do
            {
                int result = random.Next(1, 5 - ExplorationAttempt);
                if (result == 1) // Succesfully found
                {
                    ExplorationAttempt = 0;
                    Console.Clear();
                    string results = "You discovered something!";
                    Console.CursorLeft = ((Console.WindowWidth - results.Length) / 2);
                    Console.CursorTop = ((Console.WindowHeight - 3) / 2);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(results);
                    System.Threading.Thread.Sleep(1000);
                    ExplorationDestination();
                    break;
                }
                else if (result != 1) // Failed to find
                {
                    ExplorationAttempt++;
                    Console.Clear();
                    string results = "You found nothing!";
                    Console.CursorLeft = ((Console.WindowWidth - results.Length) / 2);
                    Console.CursorTop = ((Console.WindowHeight - 3) / 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(results);
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            } while (true);
        }
        public void ExplorationDestination()
        {
            Console.Clear();
            WorldMethods Information = new WorldMethods();
            Random random = new Random();
            int encounterResult = random.Next(1, 31); // DEF: 1, 101
            int monument = random.Next(2,101); // DEF: 1, 101
            int itemRarity = random.Next(1, 1001); // DEF: 1, 1001
            if (monument == 1) // Monument was found
            {

            }
            else if (monument != 1) // Monument wasn't found
            {

                if (encounterResult >= 1 && encounterResult <= 30) // Item
                {
                    List<string> RandomItem = Information.Items.ToList<string>();
                    int itemMaxNumber = RandomItem.Count();
                    int randomItemSelection = random.Next(0, (itemMaxNumber-1));
                    List<string> RandomRarirty = Information.Rarity.ToList<string>();
                    int rarityMaxNumber = RandomRarirty.Count();
                    int randomRaritySelection = random.Next(0, (rarityMaxNumber - 1));
                    Console.CursorTop = ((Console.WindowHeight - 3) / 2);
                    Console.CursorLeft = ((Console.WindowWidth - (RandomRarirty[randomRaritySelection].Length + 3 + RandomItem[randomItemSelection].Length)) / 2);
                    Console.WriteLine(RandomRarirty[randomRaritySelection] + " - " + RandomItem[randomItemSelection]);
                }
                if (encounterResult >= 31 && encounterResult <= 99) // Combat
                {

                }
                if (encounterResult == 100) // Relic
                {

                }
            }
        }
    }
}