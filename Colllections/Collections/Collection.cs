using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// написать метод определения id для Non Exterior Weapon
namespace Collections
{
    public enum Category
    {
        Consumer,
        Industrial,
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
    public class Collection
    {
        protected IEnumerable<IGrouping<Category, Item>> _collection;

        public Collection(string nameEN, string nameRU, IEnumerable<Item> collection)
        {
            NameOfcollectionEN = nameEN;
            NameOfcollectionRU = nameRU;
            _collection = from item in collection
                          orderby item.ItemCategory
                          group item by item.ItemCategory;
        }
        protected const int RatioOfConsumerToRed = 3125;
        protected const int RatioOfIndustrialToRed = 625;
        protected const int RatioOfBlueToRed = 125;
        protected const int RatioOfPurpleToRed = 25;
        protected const int RatioOfPinkToRed = 5;

        private double _probabilityOfConsumer;
        private double _probabilityOfIndustrial;
        private double _probabilityOfBlue;
        private double _probabilityOfPurple;
        private double _probabilityOfPink;
        private double _probabilityOfRed;

        private double _arithmeticMeanOfConsumer;
        private double _arithmeticMeanOfIndustrial;
        private double _arithmeticMeanOfBlue;
        private double _arithmeticMeanOfPurple;
        private double _arithmeticMeanOfPink;
        private double _arithmeticMeanOfRed;

        public readonly string NameOfcollectionEN;
        private string _nameOfcollectionRU;
        public string NameOfcollectionRU
        {
            get => _nameOfcollectionRU;
            private set => _nameOfcollectionRU = value;
        }
        public void ChangeNameOfCollection(string newName) => NameOfcollectionRU = newName;
        public virtual double CalculateTheExpectedValue()
        {
            _collection.Distinct();
            CalculateProbability();
            CalculateTheArithmeticMeanOfGrade();
            return _probabilityOfConsumer * _arithmeticMeanOfConsumer + _probabilityOfIndustrial * _arithmeticMeanOfIndustrial +
                _probabilityOfBlue * _arithmeticMeanOfBlue + _probabilityOfPurple * _arithmeticMeanOfPurple +
                _probabilityOfPink * _arithmeticMeanOfPink + _probabilityOfRed * _arithmeticMeanOfRed;
        }
        private void CalculateProbability()
        {
            double sumOfOdds = CulculateSumOfOdds();
            _probabilityOfConsumer = RatioOfConsumerToRed / sumOfOdds;
            _probabilityOfIndustrial = RatioOfIndustrialToRed / sumOfOdds;
            _probabilityOfBlue = RatioOfBlueToRed / sumOfOdds;
            _probabilityOfPurple = RatioOfPurpleToRed / sumOfOdds;
            _probabilityOfPink = RatioOfPinkToRed / sumOfOdds;
            _probabilityOfRed = 1 / sumOfOdds;
        }
        private double CulculateSumOfOdds()
        {
            bool hasConsumer = false;
            bool hasIndustrial = false;
            bool hasBlue = false;
            bool hasPurple = false;
            bool hasPink = false;
            bool hasRed = false;
            foreach (Item item in _collection)
            {
                switch (item.ItemCategory)
                {
                    case Category.Consumer:
                        hasConsumer = true;
                        break;
                    case Category.Industrial:
                        hasIndustrial = true;
                        break;
                    case Category.Blue:
                        hasBlue = true;
                        break;
                    case Category.Purple:
                        hasPurple = true;
                        break;
                    case Category.Pink:
                        hasPink = true;
                        break;
                    case Category.Red:
                        hasRed = true;
                        break;
                }
            }
            return RatioOfConsumerToRed * Convert.ToInt32(hasConsumer) + RatioOfIndustrialToRed * Convert.ToInt32(hasIndustrial) +
                RatioOfBlueToRed * Convert.ToInt32(hasBlue) + RatioOfPurpleToRed * Convert.ToInt32(hasPurple) +
                RatioOfPinkToRed * Convert.ToInt32(hasPink) + Convert.ToInt32(hasRed);
        }
        protected virtual void CalculateTheArithmeticMeanOfGrade()
        {
            double sumOfConsumer = 0;
            double sumOfIndustrial = 0;
            double sumOfBlue = 0;
            double sumOfPurple = 0;
            double sumOfPink = 0;
            double sumOfRed = 0;

            int countOfConsumer = 0;
            int countOfIndustrial = 0;
            int countOfBlue = 0;
            int countOfPurple = 0;
            int countOfPink = 0;
            int countOfRed = 0;
            foreach (Item item in _collection)
            {
                switch (item.ItemCategory)
                {
                    case Category.Consumer:
                        sumOfConsumer += item.Price;
                        countOfConsumer++;
                        break;
                    case Category.Industrial:
                        sumOfIndustrial += item.Price;
                        countOfIndustrial++;
                        break;
                    case Category.Blue:
                        sumOfBlue += item.Price;
                        countOfBlue++;
                        break;
                    case Category.Purple:
                        sumOfPurple += item.Price;
                        countOfPurple++;
                        break;
                    case Category.Pink:
                        sumOfPink += item.Price;
                        countOfPink++;
                        break;
                    case Category.Red:
                        sumOfRed += item.Price;
                        countOfRed++;
                        break;
                }
            }

            _arithmeticMeanOfConsumer = sumOfConsumer / countOfConsumer;
            _arithmeticMeanOfIndustrial = sumOfIndustrial / countOfIndustrial;
            _arithmeticMeanOfBlue = sumOfBlue / countOfBlue;
            _arithmeticMeanOfPurple = sumOfPurple / countOfPurple;
            _arithmeticMeanOfPink = sumOfPink / countOfPink;
            _arithmeticMeanOfRed = sumOfRed / countOfRed;
        }
    }


    public class WeaponCollection : Collection
    {
        WeaponCollection(string nameEN, string nameRU, IEnumerable<Item> collections) : base(nameEN, nameRU,collections)
        {

        }


        private List<ExteriorWeapon> _exteriorWeaponCollection = new List<ExteriorWeapon>();
        private List<weapon> weapons = new List<weapon>();
        private class weapon
        {
            public weapon(Category cat, int id, string nameEN, string nameRu)
            {
                category = cat;
                Id = id;
                NameEN = nameEN;
                NameRu = nameRu;
            }

            public int Id;
            public string NameEN;
            public string NameRu;

            public double priceFieldTested;
            public double priceMinimalWear;
            public double priceBattleScarred;
            public double priceWellWorn;
            public double priceFactoryNew;

            public int countFieldTested;
            public int countMinimalWear;
            public int countBattleScarred;
            public int countWellWorn;
            public int countFactoryNew;

            public Category category;
        }
        private void createNonExteriorList()
        {
            createWeaponList();
            foreach (weapon temp in weapons)
            {
                double arithmeticMeanOfWeaponPrice = 0;
                int countOfAllExterior = temp.countBattleScarred + temp.countFactoryNew + temp.countFieldTested +
                    temp.countMinimalWear + temp.countWellWorn;

                arithmeticMeanOfWeaponPrice = temp.priceBattleScarred * temp.countBattleScarred / countOfAllExterior +
                    temp.priceFactoryNew * temp.countFactoryNew / countOfAllExterior +
                    temp.priceFieldTested * temp.countFieldTested / countOfAllExterior +
                    temp.priceMinimalWear * temp.countMinimalWear / countOfAllExterior +
                    temp.priceWellWorn * temp.countWellWorn / countOfAllExterior;
                NonExteriorWeapon t = new NonExteriorWeapon(GetNonExteriorWeaponId(temp), temp.category, arithmeticMeanOfWeaponPrice, temp.NameEN, temp.NameRu, NameOfcollectionEN);
                _collection.Add(t);
            }
        }
        private int GetNonExteriorWeaponId(weapon someWeapon)
        {
            //some code
            return 0;
        }
        private void createWeaponList()
        {
            var WeaponList = from item in _collection
                             let weapon_ = (ExteriorWeapon)item
                             orderby weapon_.ItemCategory, weapon_.exterior
                             group weapon_ by weapon_.ItemCategory
                             into weaponItem
                             group weaponItem by 

        }
        protected override void CalculateTheArithmeticMeanOfGrade()
        {
            _collection.Distinct();
            //createNonExteriorList();
            base.CalculateTheArithmeticMeanOfGrade();
        }
    }
}
