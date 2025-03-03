using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Author: {FullName}");
        }
    }
}

