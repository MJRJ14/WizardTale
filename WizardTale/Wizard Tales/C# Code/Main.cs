using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.IO;
using System.Collections;
using System.Reflection.Emit;
using Wizard_Tales.WizardC;
using Wizard_Tales.IntroC;
using Wizard_Tales.SaveAndLoad;
using Wizard_Tales.WorldMethodsC;

namespace WizardTale
{
    class MainGame
    {
        static void Main(string[] args)
        {
            Wizard firstWizard = new Wizard();
            Intro Start = new Intro();
            SaveAndLoad Initialize = new SaveAndLoad();

            // Wizard Stat Block
            firstWizard.LoadSpells();
            firstWizard.Spell.Add("Magic Blast");
            firstWizard.spellSlots = 2;
            firstWizard.experience = 0;
            firstWizard.level = 1;

            Start.Introduction();
            firstWizard.name = Start.chosenName.ToString();

            do
            {
                firstWizard.UserPrompt();
            } while (true);
        }
    }
}