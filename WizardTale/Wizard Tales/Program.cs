﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.IO;
using System.Collections;
using System.Reflection.Emit;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard firstWizard = new Wizard();

            firstWizard.LoadSpells();
            firstWizard.Spell.Add("Magic Blast");
            firstWizard.spellSlots = 2;
            firstWizard.experience = 0;
            firstWizard.level = 1;

            string intro1 = "What do you want your name to be?: ";
            string intro2p1 = "Good choice, ";
            string intro2p2 = "!";
            string intro3 = "You start at level 1.";
            string intro4p1 = "Your most basic spell is '";
            string intro4p2 = "Magic Blast";
            string intro4p3 = ".'";
            string intro5 = "Enjoy!";

            Console.CursorLeft = ((Console.WindowWidth - intro1.Length) / 2);
            Console.CursorTop = ((Console.WindowHeight - 3) / 2);
            Console.Write(intro1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            firstWizard.name = Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            Console.CursorLeft = ((Console.WindowWidth - (intro2p1.Length + firstWizard.name.Length + intro2p2.Length)) / 2);
            Console.CursorTop = ((Console.WindowHeight - 3) / 2);
            Console.Write(intro2p1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(firstWizard.name);
            Console.ResetColor();
            Console.Write(intro2p2);
            System.Threading.Thread.Sleep(2500);
            Console.Clear();

            Console.CursorLeft = ((Console.WindowWidth - intro3.Length) / 2);
            Console.CursorTop = ((Console.WindowHeight - 3) / 2);
            Console.Write(intro3);
            System.Threading.Thread.Sleep(2500);
            Console.Clear();

            Console.CursorLeft = ((Console.WindowWidth - (intro4p1.Length + intro4p2.Length + intro4p3.Length)) / 2);
            Console.CursorTop = ((Console.WindowHeight - 3) / 2);
            Console.Write(intro4p1);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(intro4p2);
            Console.ResetColor();
            Console.Write(intro4p3);
            System.Threading.Thread.Sleep(2500);
            Console.Clear();

            Console.CursorLeft = ((Console.WindowWidth - intro5.Length) / 2);
            Console.CursorTop = ((Console.WindowHeight - 3) / 2);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(intro5);
            Console.ResetColor();
            System.Threading.Thread.Sleep(2500);
            Console.Clear();

            do
            {
                firstWizard.UserPrompt();
            } while (true);
        }
    }
    class Wizard
    {
        public string name;
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
                Console.WriteLine("\nYou (" + name + ") casts " + Spell[spellChoice]);
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
            Console.Write("\n");
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
            Console.Clear();
            titleMethod();
            bool valid = false;
        userpromptstart:
            ReadStats();
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t1.  Practice Spell(s)");
            Console.WriteLine("\t2.  Meditate");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\tESC.  Exit");
            Console.ResetColor();
            Console.Write("\n");
            Console.Write("What would you like to do?: ");
            ConsoleKeyInfo wizardsChoice = Console.ReadKey();
            Console.Clear();
            titleMethod();
            ReadStats();
            if (wizardsChoice.Key == ConsoleKey.D2)
            {
                Meditate();
                valid = true;
                System.Threading.Thread.Sleep(1000);
            }
            if (wizardsChoice.Key == ConsoleKey.D1)
            {
                SpellChoice();
                valid = true;
                System.Threading.Thread.Sleep(1000);
            }
            if (wizardsChoice.Key == ConsoleKey.Escape)
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