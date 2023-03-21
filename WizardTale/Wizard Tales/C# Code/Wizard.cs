using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardTale;
using Wizard_Tales.IntroC;
using Wizard_Tales.ExplorationC;
using Wizard_Tales.SaveAndLoad;
using Wizard_Tales.WorldMethodsC;

namespace Wizard_Tales.WizardC
{
    public class Wizard
    {
        public string name { get; set; }
        public List<string> Spell = new List<string>();
        public string[] levelOneSpellList = { "Eldrich Blast", "Fireball", "Magic Missle" };
        public List<string> LevelOneList = new List<string>();
        public string[] levelThreeSpellList = { "Healing Word", "Magic Shield", "Thamauturgy" };
        public List<string> LevelThreeList = new List<string>();
        public int spellSlots;
        public double experience;
        public int level;
        public int spellSlotsUsed;
        public int spellChoice;
        public bool startProgram { get; set; } = false;
        public void SpellChoice()
        {
            Console.Clear();
            titleMethod();
        start:
            ReadStats();
            Spell.Sort();
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < Spell.Count; i++)
            {
                Console.WriteLine("\t" + Spell[i]);
            }
            Console.ResetColor();
            Console.Write("\n");
            Console.Write("What spell would you like to cast? (Type 'Back' to exit): ");
            string spellChoiceString = Console.ReadLine();
            if (Spell.Contains(spellChoiceString))
            {
                spellChoice = Spell.IndexOf(spellChoiceString);
                CastSpell();
            }
            else if (spellChoiceString == "Back")
            {
                Console.Clear();
                UserPrompt();
            }
            else
            {
                Console.Clear();
                titleMethod();
                goto start;
            }
        }
        public void CastSpell()
        {
            if (spellSlots > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou cast " + Spell[spellChoice]);
                Console.ResetColor();
                spellSlots--;
                spellSlotsUsed++;
                experience += 0.25;
                if (experience >= 1 * level)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nYou have leveled up!");
                    Console.ResetColor();
                    level++;
                    experience = 0.0;
                    System.Threading.Thread.Sleep(1000);
                    LearnSpell();
                }
            }
            else
            {
                Console.WriteLine("\nYou are out of spell slots.");
            }
        }
        public void ReadStats()
        {
            Console.ResetColor();
            Console.Write("\n");
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(name);
            Console.ResetColor();
            Console.WriteLine("Level: " + level);
            Console.WriteLine($"Experience: {(experience * 100) / level:F0} XP");
            Console.WriteLine("Spell Slots: " + spellSlots);
        }
        public void Meditate()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n");
            Console.WriteLine("Through meditation you have recovered all your spell slots!");
            Console.ResetColor();
            spellSlots += spellSlotsUsed;
            spellSlotsUsed = 0;
        }
        public void UserPrompt()
        {
            if (startProgram == true)
            {
                Exporation exporation = new Exporation();
                Console.Clear();
                Console.ResetColor();
                titleMethod();
                bool valid = false;
            userpromptstart:
                ReadStats();
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t1.  Practice Spell(s)");
                Console.WriteLine("\t2.  Meditate");
                Console.WriteLine("\t3.  Explore");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\tESC.  Exit");
                Console.ResetColor();
                Console.Write("\n");
                Console.Write("What would you like to do?: ");
                ConsoleKeyInfo UserKeyPress = Console.ReadKey(true);
                Console.Clear();
                titleMethod();
                ReadStats();
                if (UserKeyPress.Key == ConsoleKey.D3)
                {
                    exporation.ExporationChance();
                    valid = true;
                }
                if (UserKeyPress.Key == ConsoleKey.D2)
                {
                    Meditate();
                    valid = true;
                    System.Threading.Thread.Sleep(1000);
                }
                if (UserKeyPress.Key == ConsoleKey.D1)
                {
                    SpellChoice();
                    valid = true;
                    System.Threading.Thread.Sleep(1000);
                }
                if (UserKeyPress.Key == ConsoleKey.Escape)
                {
                    System.Environment.Exit(0);
                }
                if (valid == false)
                {
                    Console.Clear();
                    titleMethod();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("You can only 'Meditate,' or 'Cast Spell.'");
                    Console.ResetColor();
                    goto userpromptstart;
                }
            }
        }
        public void LearnSpell()
        {
            if (level <= 2)
            {
                spellSlots = 2;
            }
            else if (level > 2 && level < 10)
            {
                spellSlots = 2 + (level - 2);
            }
            spellSlotsUsed = 0;
            bool restart = true;
            Console.Clear();
            titleMethod();
            do
            {
                ReadStats();
                Console.Write("\n");
                if (level >= 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\tLevel 1 Spells:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < LevelOneList.Count(); i++)
                    {
                        Console.WriteLine("\t\t" + LevelOneList[i]);
                    }
                    Console.ResetColor();
                    Console.Write("\n");
                }
                if (level >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\tLevel 3 Spells:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < LevelThreeList.Count(); i++)
                    {
                        Console.WriteLine("\t\t" + LevelThreeList[i]);
                    }
                    Console.ResetColor();
                    Console.Write("\n");
                }
                Console.Write("Choose Spells from the list above: ");
                string spellChoiceString = Console.ReadLine();
                if (LevelOneList.Contains(spellChoiceString))
                {
                    LevelOneList.Remove(spellChoiceString);
                    Spell.Add(spellChoiceString);
                    restart = false;
                    Console.Clear();
                    titleMethod();
                    string congratulations = "You have learned " + spellChoiceString + "!";
                    Console.Write("\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.CursorLeft = ((Console.WindowWidth - congratulations.Length) / 2);
                    Console.WriteLine(congratulations);
                    Console.ResetColor();
                }
                else if (LevelThreeList.Contains(spellChoiceString))
                {
                    LevelThreeList.Remove(spellChoiceString);
                    Spell.Add(spellChoiceString);
                    restart = false;
                    Console.Clear();
                    titleMethod();
                    string congratulations = "You have learned " + spellChoiceString + "!";
                    Console.Write("\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.CursorLeft = ((Console.WindowWidth - congratulations.Length) / 2);
                    Console.WriteLine(congratulations);
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    titleMethod();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Pick a valid spell from the list.");
                    Console.ResetColor();
                }
            } while (restart == true);
        }
        public void LoadSpells()
        {
            for (int i = 0; i < levelOneSpellList.Count(); i++)
            {
                LevelOneList.Add(levelOneSpellList[i]);
            }
            for (int i = 0; i < levelThreeSpellList.Count(); i++)
            {
                LevelThreeList.Add(levelThreeSpellList[i]);
            }
        }
        public void titleMethod()
        {
            string title = "~Wizard Tales~";
            Console.CursorLeft = ((Console.WindowWidth - title.Length) / 2);
            Console.WriteLine(title);
        }
    }
}
