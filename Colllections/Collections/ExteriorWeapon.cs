namespace Collections
{
    public class ExteriorWeapon : Item
    {

        public ExteriorWeapon(int id, Category category, double price, string nameEN, string nameRU, string nameOfCollection, Exterior exterior)
            : base(id, category, price, nameEN, nameRU, nameOfCollection) 
        {
            this.exterior = exterior;
        }
        public Exterior exterior { get; private set; }
        public int countOfWeapon { get; private set; }

    }
}
