using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Publisher: {Name}");
        }
    }
}

