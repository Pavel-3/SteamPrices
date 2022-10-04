using System;
using System.Runtime.Serialization;

namespace Collections
{
    class InvalidValueException : Exception
    {
        public InvalidValueException() : base() { }
        public InvalidValueException(string message) : base(message) { }
        public InvalidValueException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string ToString() => Message;
    }
    public abstract class Item : IEquatable<Item>
    {
        public static bool operator ==(Item item1, Item item2)
        {
            if (item1 is null || item2 is null)
                return false;
            return item1.Id == item2.Id && item1.ItemCategory == item2.ItemCategory &&
                item1.NameEN == item2.NameEN && item1._price == item2._price;
        }
        public static bool operator !=(Item item1, Item item2) => !(item1 == item2);

        public override bool Equals(object obj)
        {
            if (obj is Item item)
                return this == item;
            return false;
        }
        public bool Equals(Item other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            return this == other;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(Id, ItemCategory, Price, NameEN, NameOfCollection).GetHashCode();
        }
        public Item(int id, Category category, double price, string nameEN, string nameRU, string nameOfCollection)
        {
            Id = id;
            ItemCategory = category;
            Price = price;
            NameEN = nameEN;
            NameRU = nameRU;
            NameOfCollection = nameOfCollection;
        }
        public readonly string NameOfCollection;
        public readonly int Id;
        public readonly Category ItemCategory;
        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                    _price = value;
                else
                    throw new InvalidValueException();
            }
        }
        public void ChangeNameRU(string newNameRU) => NameRU = newNameRU;
        public readonly string NameEN;
        public string NameRU { get; protected set; }
        public override string ToString()
        {
            return $"id: {Id}\tItem Category: {ItemCategory}\t\tPrice: {Price}\tNameEN: {NameEN}\tNameRU: {NameRU}\t Name of collection: {NameOfCollection}";
        }
    }
}
