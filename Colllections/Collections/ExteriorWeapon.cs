namespace Collections
{
    public class ExteriorWeapon : NonExteriorWeapon
    {

        public ExteriorWeapon(int id, Category category, double price, string nameEN, string nameRU, string nameOfCollection, Exterior exterior, int countOfWeapons)
            : base(id, category, price, nameEN, nameRU, nameOfCollection) 
        {
            ExteriorOfWeapon = exterior;
            CountOfWeapons = countOfWeapons;
        }
        public Exterior ExteriorOfWeapon { get; private set; }
        public int CountOfWeapons { get; private set; }
        public override string ToString()
        {
            return $"id: {Id}\tItem Category: {ItemCategory}\t\tPrice: {Price}\tHashCode: {GetHashCode()}\tExterior: {ExteriorOfWeapon}";
        }
    }
}
