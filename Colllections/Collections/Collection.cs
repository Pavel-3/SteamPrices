using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    enum Category
    {
        Consumer,
        Industrial,
        Blue,
        Purple,
        Pink,
        Red
    }
    enum Exterior
    {
        FieldTested,
        MinimalWear,
        BattleScarred,
        WellWorn,
        FactoryNew
    }
    class Collection
    {
        protected List<Item> _collection = new List<Item>();

        public Collection(string nameEN, string nameRU)
        {
            NameOfcollectionEN = nameEN;
            NameOfcollectionRU = nameRU;
        }
        private const int RatioOfConsumerToRed = 3125;
        private const int RatioOfIndustrialToRed = 625;
        private const int RatioOfBlueToRed = 125;
        private const int RatioOfPurpleToRed = 25;
        private const int RatioOfPinkToRed = 5;

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

    class AgentCollection : Collection
    {
        public AgentCollection(string nameEN, string nameRU):base(nameEN, nameRU)
        {

        }
        public void Add(Agent agent) => _collection.Add(agent);
    }

    class StikerCollection : Collection
    {             
        public StikerCollection(string nameEN, string nameRU):base(nameEN, nameRU)
        {

        }
        public void Add(Stiker stiker) => _collection.Add(stiker);

    }

    class WeaponCollection : Collection
    {
        WeaponCollection(string nameEN, string nameRU) : base(nameEN, nameRU)
        {

        }
        public void Add(ExteriorWeapon weapon) => _collection.Add(weapon);
    }
}
