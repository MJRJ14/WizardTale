using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard_Tales.InventoryC
{
    public class Inventory
    {
        public List<string> InventoryList { get; set; } = new List<string>();
        string Common { get; set; } = "Common";
        public List<string> CommonItemList { get; set; } = new List<string>();
        string Uncommon { get; set; } = "Uncommon";
        public List<string> UncommonItemList { get; set; } = new List<string>();
        string Rare { get; set; } = "Rare";
        public List<string> RareItemList { get; set; } = new List<string>();
        string Epic { get; set; } = "Epic";
        public List<string> EpicItemList { get; set; } = new List<string>();
        string Legendary { get; set; } = "Legendary";
        public List<string> LegendaryItemList { get; set; } = new List<string>();
        string Mythical { get; set; } = "Mythical";
        public List<string> MythicalItemList { get; set; } = new List<string>();
        string Godly { get; set; } = "Godly";
        public List<string> GodlyItemList { get; set; } = new List<string>();

        public int InventoryCount { get; set; } = 0;
        public void InventoryMethod() 
        {
            string[] commonList = CommonItemList.ToArray();
            for (int i = 0; i < commonList.Length; i++)
            {
                if (commonList[i].StartsWith(Common))
                {
                    CommonItemList.Add(commonList[i]);
                    InventoryCount++;
                }
            }
            string[] uncommonList = CommonItemList.ToArray();
            for (int i = 0; i < uncommonList.Length; i++)
            {
                if (uncommonList[i].StartsWith(Uncommon))
                {
                    UncommonItemList.Add(uncommonList[i]);
                    InventoryCount++;
                }
            }
            string[] rareList = RareItemList.ToArray();
            for (int i = 0; i < rareList.Length; i++)
            {
                if (rareList[i].StartsWith(Rare))
                {
                    RareItemList.Add(rareList[i]);
                    InventoryCount++;
                }
            }
            string[] epicList = EpicItemList.ToArray();
            for (int i = 0; i < epicList.Length; i++)
            {
                if (epicList[i].StartsWith(Epic))
                {
                    EpicItemList.Add(epicList[i]);
                    InventoryCount++;
                }
            }
            string[] legendaryList = LegendaryItemList.ToArray();
            for (int i = 0; i < legendaryList.Length; i++)
            {
                if (legendaryList[i].StartsWith(Legendary))
                {
                    LegendaryItemList.Add(legendaryList[i]);
                    InventoryCount++;
                }
            }
            string[] mythicalList = MythicalItemList.ToArray();
            for (int i = 0; i < mythicalList.Length; i++)
            {
                if (mythicalList[i].StartsWith(Mythical))
                {
                    MythicalItemList.Add(mythicalList[i]);
                    InventoryCount++;
                }
            }
            string[] godlyList = GodlyItemList.ToArray();
            for (int i = 0; i < godlyList.Length; i++)
            {
                if (godlyList[i].StartsWith(Godly))
                {
                    GodlyItemList.Add(godlyList[i]);
                    InventoryCount++;
                }
            }
        } 
    }
}
