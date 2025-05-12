using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public class Isbn : BaseEntity
    {
        [Required(ErrorMessage = "Код ISBN обов'язковий")]
        [StringLength(13, MinimumLength = 5, ErrorMessage = "ISBN має бути від 5 до 13 символів")]
        public string Code { get; set; }

        public Isbn() { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {Code}");
        }
    }
}

