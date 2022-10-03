using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

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
        protected IEnumerable<Item> _collection;

        public Collection(string nameEN, string nameRU, IEnumerable<Item> collection)
        {
            NameOfcollectionEN = nameEN;
            NameOfcollectionRU = nameRU;
            collection = collection.Distinct();
            //_collection = from item in collection
            //              orderby item.ItemCategory
            //              group item by item.ItemCategory;
            _collection = collection.Distinct();

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

        private bool _hasConsumer = false;
        private bool _hasIndustrial = false;
        private bool _hasBlue = false;
        private bool _hasPurple = false;
        private bool _hasPink = false;
        private bool _hasRed = false;

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
            CalculateProbability();
            CalculateTheArithmeticMeanOfGrade();
            return _probabilityOfConsumer * _arithmeticMeanOfConsumer + _probabilityOfIndustrial * _arithmeticMeanOfIndustrial +
                _probabilityOfBlue * _arithmeticMeanOfBlue + _probabilityOfPurple * _arithmeticMeanOfPurple +
                _probabilityOfPink * _arithmeticMeanOfPink + _probabilityOfRed * _arithmeticMeanOfRed;
        }
        private void CalculateProbability()
        {
            double sumOfOdds = CulculateSumOfOdds();
            _probabilityOfConsumer = _hasConsumer ? RatioOfConsumerToRed / sumOfOdds : 0;
            _probabilityOfIndustrial = _hasIndustrial ? RatioOfIndustrialToRed / sumOfOdds : 0;
            _probabilityOfBlue = _hasBlue ? RatioOfBlueToRed / sumOfOdds : 0;
            _probabilityOfPurple = _hasPurple ? RatioOfPurpleToRed / sumOfOdds : 0;
            _probabilityOfPink = _hasPink ? RatioOfPinkToRed / sumOfOdds : 0;
            _probabilityOfRed = _hasRed ? 1 / sumOfOdds : 0;
        }
        private double CulculateSumOfOdds()
        {
            foreach (Item item in _collection)
            {
                switch (item.ItemCategory)
                {
                    case Category.Consumer:
                        _hasConsumer = true;
                        break;
                    case Category.Industrial:
                        _hasIndustrial = true;
                        break;
                    case Category.Blue:
                        _hasBlue = true;
                        break;
                    case Category.Purple:
                        _hasPurple = true;
                        break;
                    case Category.Pink:
                        _hasPink = true;
                        break;
                    case Category.Red:
                        _hasRed = true;
                        break;
                }
            }
            return RatioOfConsumerToRed * Convert.ToInt32(_hasConsumer) + RatioOfIndustrialToRed * Convert.ToInt32(_hasIndustrial) +
                RatioOfBlueToRed * Convert.ToInt32(_hasBlue) + RatioOfPurpleToRed * Convert.ToInt32(_hasPurple) +
                RatioOfPinkToRed * Convert.ToInt32(_hasPink) + Convert.ToInt32(_hasRed);
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

            _arithmeticMeanOfConsumer = _hasConsumer ? sumOfConsumer / countOfConsumer : 0;
            _arithmeticMeanOfIndustrial = _hasIndustrial ? sumOfIndustrial / countOfIndustrial : 0;
            _arithmeticMeanOfBlue = _hasBlue ? sumOfBlue / countOfBlue : 0;
            _arithmeticMeanOfPurple = _hasPurple ? sumOfPurple / countOfPurple : 0;
            _arithmeticMeanOfPink = _hasPink ? sumOfPink / countOfPink : 0;
            _arithmeticMeanOfRed = _hasRed ? sumOfRed / countOfRed : 0;
        }
    }

    public class AgentCollection : Collection
    {
        public AgentCollection(string nameEN, string nameRU, IEnumerable<Item> collections) : base(nameEN, nameRU, collections) { }
    }
    public class WeaponCollection : Collection
    {
        public WeaponCollection(string nameEN, string nameRU, IEnumerable<ExteriorWeapon> collections) : base(nameEN, nameRU,collections)
        {

        } 
        private void createNonExteriorList()
        {
            var groupingWeapon = from item in _collection
                                 let weapon = (ExteriorWeapon)item
                                 orderby weapon.ItemCategory, weapon.ExteriorOfWeapon
                                 group weapon by weapon.ItemCategory into groupingByCategory
                                 from i in (
                                    from weapon in groupingByCategory
                                    group weapon by weapon.NameEN)
                                 group i by groupingByCategory.Key;
            List<NonExteriorWeapon> nonExteriorWeapons = new List<NonExteriorWeapon>();
            foreach (var groupingByCategory in groupingWeapon)
            {
                foreach (var groupingByName in groupingByCategory)
                {
                    int countOfWeapons = 0;
                    double price = 0;
                    int countOfWeaponsOnMarket = 0;
                    foreach(var weapon in groupingByName)
                    {
                        countOfWeapons++;
                        countOfWeaponsOnMarket += weapon.CountOfWeapons;
                        price += weapon.Price * weapon.CountOfWeapons;
                    }
                    nonExteriorWeapons.Add(new NonExteriorWeapon(GetNonExteriorWeaponId(groupingByName), groupingByCategory.Key,
                        countOfWeaponsOnMarket == 0 ? price/countOfWeapons : price / (countOfWeaponsOnMarket),
                        groupingByName.Key, "", NameOfcollectionEN));
                }
            }
            _collection = nonExteriorWeapons;
        }
        private int GetNonExteriorWeaponId(IGrouping<string, ExteriorWeapon> someWeapon)
        {
            //some code
            return 0;
        }
        protected override void CalculateTheArithmeticMeanOfGrade()
        {
            _collection.Distinct();
            createNonExteriorList();
            base.CalculateTheArithmeticMeanOfGrade();
        }
    }
}
