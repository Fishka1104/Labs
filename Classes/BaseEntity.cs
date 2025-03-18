using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract void DisplayInfo(); 
    }
}

//Він містить абстрактний метод DisplayInfo(), який мають перевизначати всі похідні класи
