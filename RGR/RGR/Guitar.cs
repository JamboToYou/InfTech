using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Guitar
    {
        private int ID;
        private string Variation;
        private string Type;
        private string MadeBy;
        private string Model;
        private string DeckWood;
        private string FingerboardWood;
        private string Weight;
        private string Length;
        private string Price;

        public Guitar(int ID, string Variation, string Type, string madeBy, string model, string deckWood, string fingerboardWood, string weight, string length, string price)
            : this(Variation, Type, madeBy, model, deckWood, fingerboardWood, weight, length, price)
        {
            ID1 = ID;
        }

        public Guitar(string Variation, string Type, string madeBy, string model, string deckWood, string fingerboardWood, string weight, string length, string price)
        {
            Variation1 = Variation;
            Type1 = Type;
            MadeBy1 = madeBy;
            Model1 = model;
            DeckWood1 = deckWood;
            FingerboardWood1 = fingerboardWood;
            Weight1 = weight;
            Length1 = length;
            Price1 = price;
        }

        public string MadeBy1 { get => MadeBy; set => MadeBy = value; }
        public string Model1 { get => Model; set => Model = value; }
        public string DeckWood1 { get => DeckWood; set => DeckWood = value; }
        public string FingerboardWood1 { get => FingerboardWood; set => FingerboardWood = value; }
        public string Weight1 { get => Weight; set => Weight = value; }
        public string Length1 { get => Length; set => Length = value; }
        public string Price1 { get => Price; set => Price = value; }
        public string Type1 { get => Type; set => Type = value; }
        public int ID1 { get => ID; set => ID = value; }
        public string Variation1 { get => Variation; set => Variation = value; }

        public override string ToString()
        {
            return $"{Variation} {Type} Guitar:" + Environment.NewLine +
                $" Made by : {MadeBy}" + Environment.NewLine +
                $" Model : {Model}" + Environment.NewLine +
                $" Deck wood : {DeckWood}" + Environment.NewLine +
                $" Fingerboard wood : {FingerboardWood}" + Environment.NewLine +
                $" Weight : {Weight}" + Environment.NewLine +
                $" Length : {Length}" + Environment.NewLine +
                $" Price : {Price}";
        }
    }
}
