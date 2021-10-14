using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    class Collection
    {
        public Collection()
        {

        }
        const int RatioOfConsumerToRed = 3125;
        const int RatioOfIndustrialToRed = 625;
        const int RatioOfBlueToRed = 125;
        const int RatioOfPurpleToRed = 25;
        const int RatioOfPinkToRed = 5;

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

        public virtual double CalculateTheExpectedValue(List<Item> collection)
        {
            CalculateProbability(collection);
            CalculateTheArithmeticMean(collection);
            return _probabilityOfConsumer * _arithmeticMeanOfConsumer + _probabilityOfIndustrial * _arithmeticMeanOfIndustrial +
                _probabilityOfBlue * _arithmeticMeanOfBlue + _probabilityOfPurple * _arithmeticMeanOfPurple +
                _probabilityOfPink * _arithmeticMeanOfPink + _probabilityOfRed * _arithmeticMeanOfRed;
        }
        private void CalculateProbability(List<Item> collection)
        {
            double sumOfOdds = CulculateSumOfOdds(collection);
            _probabilityOfConsumer = RatioOfConsumerToRed / sumOfOdds;
            _probabilityOfIndustrial = RatioOfIndustrialToRed / sumOfOdds;
            _probabilityOfBlue = RatioOfBlueToRed / sumOfOdds;
            _probabilityOfPurple = RatioOfPurpleToRed / sumOfOdds;
            _probabilityOfPink = RatioOfPinkToRed / sumOfOdds;
            _probabilityOfRed = 1 / sumOfOdds;
        }
        private double CulculateSumOfOdds(List<Item> collection)
        {
            bool hasConsumerGrade = false;
            bool hasIndustrialGrade = false;
            bool hasBlue = false;
            bool hasPurple = false;
            bool hasPink = false;
            bool hasRed = false;
            foreach (Item item in collection)
            {
                switch (item.ItemCategory)
                {
                    case Category.ConsumerGrade:
                        hasConsumerGrade = true;
                        break;
                    case Category.IndustrialGrade:
                        hasIndustrialGrade = true;
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
            return RatioOfConsumerToRed * Convert.ToInt32(hasConsumerGrade) + RatioOfIndustrialToRed * Convert.ToInt32(hasIndustrialGrade) +
                RatioOfBlueToRed * Convert.ToInt32(hasBlue) + RatioOfPurpleToRed * Convert.ToInt32(hasPurple) +
                RatioOfPinkToRed * Convert.ToInt32(hasPink) + Convert.ToInt32(hasRed);
        }
        private void CalculateTheArithmeticMean(List<Item> collection)
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

            foreach (Item item in collection)
            {
                switch (item.ItemCategory)
                {
                    case Category.ConsumerGrade:
                        sumOfConsumer += item.Price;
                        countOfConsumer++;
                        break;
                    case Category.IndustrialGrade:
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
        AgentCollection()
        {

        }
        

        //public double CalculateTheExpectedValue()
        //{
        //    return base.CalculateTheExpectedValue(_agentCollection);
        //}

    }
}
