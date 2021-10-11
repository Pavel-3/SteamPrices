using Items;
using System;
using System.Collections.Generic;

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

        public double CalculateTheExpectedValue(List<Item> collection)
        {
            CalculateProbability(collection);
            double result;
            result = 0;
            return result;
        }
        private void CalculateProbability(List<Item> collection)
        {
            _probabilityOfConsumer = RatioOfConsumerToRed / SumOfOdds(collection);
            _probabilityOfIndustrial = RatioOfIndustrialToRed / SumOfOdds(collection);
            _probabilityOfBlue = RatioOfBlueToRed / SumOfOdds(collection);
            _probabilityOfPurple = RatioOfPurpleToRed / SumOfOdds(collection);
            _probabilityOfPink = RatioOfPinkToRed / SumOfOdds(collection);
            _probabilityOfRed = 1 / SumOfOdds(collection);
        }
        private double SumOfOdds(List<Item> collection)
        {
            bool hasConsumerGrade = false;
            bool hasIndustrialGrade = false;
            bool hasBlue = false;
            bool hasPurple = false;
            bool hasPink = false;
            bool hasRed = false;
            foreach (Item item in collection)
            { 
                switch (item.Category)
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
        private double CalculateTheArithmeticMeanOfConsumer(List<Item> collection)
        {
            (double, int) temp = FindSumOfTheCategory(collection, Category.ConsumerGrade);
            return temp.Item1/temp.Item2;
        }
        private double CalculateTheArithmeticMeanOfIndustrial(List<Item> collection)
        {
            double result = 0;
            //some code
            return result;
        }
        private double CalculateTheArithmeticMeanOfBlue(List<Item> collection)
        {
            double result = 0;
            //some code
            return result;
        }
        private double CalculateTheArithmeticMeanOfPurple(List<Item> collection)
        {
            double result = 0;
            //some code
            return result;
        }
        private double CalculateTheArithmeticMeanOfPink(List<Item> collection)
        {
            double result = 0;
            //some code
            return result;
        }
        private double CalculateTheArithmeticMeanOfRed(List<Item> collection)
        {
            double result = 0;
            //some code
            return result;
        }
        private (double, int) FindSumOfTheCategory(List<Item> collection, Category category)
        {
            var temp = (sum:0.0, count:0);
            foreach (Item item in collection)
            {
                if (item.ItemCategory == category)
                {
                    temp.sum += item.Price;
                    temp.count++;
                }
            }
            return temp;
        }
    }

    class AgentCollection : Collection
    {
        AgentCollection()
        {

        }
        List<Agent> _agentCollection;


    }
}
