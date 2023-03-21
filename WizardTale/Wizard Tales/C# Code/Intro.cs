using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizard_Tales.WizardC;
using WizardTale;
using Wizard_Tales.WorldMethodsC;
using Wizard_Tales.ExplorationC;
using Wizard_Tales.SaveAndLoad;
using System.Threading;

namespace Wizard_Tales.IntroC
{
    public class Intro
    {
        public string chosenName { get; set; }
        public bool finishedIntro { get; set; } = false;
        public void Introduction()
        {
            Wizard firstWizard = new Wizard();

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
            chosenName = Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            Console.CursorLeft = ((Console.WindowWidth - (intro2p1.Length + chosenName.Length + intro2p2.Length)) / 2);
            Console.CursorTop = ((Console.WindowHeight - 3) / 2);
            Console.Write(intro2p1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(chosenName);
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
            finishedIntro= true;
            System.Threading.Thread.Sleep(2500);
            Console.Clear();


        }
    }
}
