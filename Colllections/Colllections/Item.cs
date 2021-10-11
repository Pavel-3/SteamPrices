namespace Items
{
    enum Category
    {
        ConsumerGrade,
        IndustrialGrade,
        Blue,
        Purple,
        Pink,
        Red
    }    
    public enum Exterior
    {
        FieldTested,
        MinimalWear,
        BattleScarred,
        WellWorn,
        FactoryNew
    }
    class Item
    {
        protected string id { get; set; }
        protected Category _itemCategory;
        private int _price;

        public int Price
        {
            get { return _price; }
            private set { _price = value; }
        }

        public Category ItemCategory
        {
            get { return _itemCategory; }
            private set { _itemCategory = value; }
        }

        protected string nameEN;
        protected string nameRU;

    }

    class Weapon : Item
    {
        Exterior _exterior;
        public Weapon(string id, Category category, Exterior exterior)
        {
            this.id = id;
            _category = category;
            _exterior = exterior;
        }
    }

    class Stiker : Item
    {
        public Stiker(string id, Category category)
        {
            this.id = id;
            _category = category;
        }
    }
    class Agent : Item
    {
        public Agent(string id, Category category)
        {
            this.id = id;
            _category = category;
        }
    }
}
