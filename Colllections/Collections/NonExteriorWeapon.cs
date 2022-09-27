using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class NonExteriorWeapon : Item
    {
        public NonExteriorWeapon(int id, Category category, double price, string nameEN, string nameRU, string nameOfCollection)
    : base(id, category, price, nameEN, nameRU, nameOfCollection) { }
    }
}
