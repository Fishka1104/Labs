using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public class Isbn : BaseEntity
    {
        public string Code { get; set; }

        public Isbn() { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {Code}");
        }
    }
}

