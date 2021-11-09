using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flyweight
{
    public class Flyweight
    {
        private Grocery _sharedState;

        public Flyweight(Grocery pr)
        {
            this._sharedState = pr;
        }

        public void Operation(Grocery uniqueState)
        {
            string s = JsonSerializer.Serialize(this._sharedState);
            string u = JsonSerializer.Serialize(uniqueState);
            Console.WriteLine($"Flyweight: Displaying general {s} and unique {u} state.");
        }
    }

    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Grocery[] args)
        {
            foreach (var elem in args)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.getKey(elem)));
            }
        }

        // Возвращает хеш строки Легковеса для данного состояния.
        public string getKey(Grocery key)
        {
            List<string> elements = new List<string>();

            elements.Add(key.Company);
            elements.Add(key.Type);

            if (key.Rack != null && key.ShelfNumber != null)
            {
                elements.Add(key.Rack);
                elements.Add(key.ShelfNumber);
            }

            elements.Sort();

            return string.Join("_", elements);
        }

        // Возвращает существующий Легковес с заданным состоянием или создает новый.
        public Flyweight GetFlyweight(Grocery sharedState)
        {
            string key = this.getKey(sharedState);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public void listFlyweights()
        {
            var count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }

    public class Grocery
    {
        public string Company { get; set; }

        public string Type { get; set; }

        public string Rack { get; set; }

        public string ShelfNumber { get; set; }
    }
}
