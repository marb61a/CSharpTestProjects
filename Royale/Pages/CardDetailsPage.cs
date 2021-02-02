using System;
using System.Linq;
using OpenQA.Selenium;
using Framework.Selenium;
using Framework.Models;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsPageMap Map;

        public CardDetailsPage()
        {
            Map = new CardDetailsPageMap();
        }

        public (string Type, int Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            var type = categories[0].ToLower();
            var arena = categories[1].Trim().Split(' ').Last();
            
            int intArena;
            if(int.TryParse(arena, out intArena))
            {
                return (type, intArena);
            }
            else
            {
                return (type, 0);
            }
        }

        public Card GetBaseCard()
        {
            var (type, arena) = GetCardCategory();

            return new Card
            {
                Name = Map.CardName.Text,
                Rarity = Map.CardRarity.Text.Split('\n').Last(),
                Type = type,
                Arena = arena
            };
        }
    }

    public class CardDetailsPageMap 
    {
         public Element CardName => Driver.FindElement(By.CssSelector("div[class*='cardName']"), "Card Name");
         public Element CardCategory => Driver.FindElement(By.CssSelector("div[class*='card__rarity']"), "Card Category");
         public Element CardRarity => Driver.FindElement(By.CssSelector("div[class*='rarityCaption']"), "Card Rarity");
    }
}