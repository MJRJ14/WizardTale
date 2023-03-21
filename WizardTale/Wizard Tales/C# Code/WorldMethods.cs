using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardTale;
using Wizard_Tales.ExplorationC;
using Wizard_Tales.IntroC;
using Wizard_Tales.SaveAndLoad;
using Wizard_Tales.WizardC;

namespace Wizard_Tales.WorldMethodsC
{
    public class WorldMethods
    {
        public string[] Rarity { get; set; } = { "Common", "Uncommon", "Rare", "Epic", "Legendary", "Mythical", "Godly" };
        public string[] Items { get; set; } = { "Rod", "Crystal", "Orb", "Staff", "Hat", "Robe", "Tarps", "Bag" };
        public ConsoleColor[] RarityColor { get; set; } = { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.DarkRed, ConsoleColor.DarkYellow };
    }
}
