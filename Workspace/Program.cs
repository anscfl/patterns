using System;
using Abstract_Factory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder;
using Strategy;
using Adapter;
using Singleton;
using System.Threading;
using Decorator;
using Facade;
using Flyweight;

namespace WorkSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            //AbsFactory();
            //Builder();
            //Singletons();
            //Strategy();
            //Adapter();
            //Decorator();
            //Facade();
            //Flyweight();

        }

        static void AbsFactory()
        {
            var Brand1Factory = new Brand1Factory();
            var Brand2Factory = new Brand2Factory();

            var B1Phone = Brand1Factory.CreatePhone();
            var B2Phone = Brand2Factory.CreatePhone();
            var B1Comp = Brand1Factory.CreateComputer();
            var B2Comp = Brand2Factory.CreateComputer();

            B1Phone.Enable();
            B2Phone.Enable();
            B1Comp.Enable();
            B2Comp.Enable();
        }

        static void Builder()
        {
            var director = new Director();
            var builder = new ToyBuilder();
            director.Builder = builder;

            Console.WriteLine("Toy package:");
            director.BuildProduct();
            Console.WriteLine(builder.GetProduct().ListParts());
        }

        static void Singletons()
        {
            (new Thread(() =>
            {
                Singleton.Singleton singleton1 = Singleton.Singleton.GetInstance();
                Console.WriteLine(singleton1.Car);
            })).Start();

            Singleton.Singleton singleton2 = Singleton.Singleton.GetInstance();
            Console.WriteLine(singleton2.Car);
        }

        static void Strategy()
        {
            var context = new Context();
            Random rnd = new Random();
            int predict = rnd.Next(2);
            Console.WriteLine("Warrior achieved crossroads:\nShould I go left?");
            Console.WriteLine(predict);
            if (predict == 0)
            {
                context.SetStrategy(new StrategyA());
                Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                Console.WriteLine("Warrior goes left");
            }
            else if (predict == 1)
            {
                context.SetStrategy(new StrategyB());
                Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                Console.WriteLine("Should I go right?");
                predict = rnd.Next(2);
                Console.WriteLine(predict);
                if (predict == 0)
                {
                    context.SetStrategy(new StrategyA());
                    Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                    Console.WriteLine("Warrior goes right");
                }
                else 
                {
                    context.SetStrategy(new StrategyB());
                    Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                    Console.WriteLine("Should I go forward?");
                    predict = rnd.Next(2);
                    Console.WriteLine(predict);
                    if (predict == 0)
                    {
                        context.SetStrategy(new StrategyA());
                        Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                        Console.WriteLine("Warrior goes forward");
                    }
                    else if (predict == 1)
                    {
                        context.SetStrategy(new StrategyB());
                        Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                        Console.WriteLine("Warrior goes back");
                    }
                }
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("\nPeasant achieved crossroads:\nShould I go left?");
            predict = rnd.Next(2);
            Console.WriteLine(predict);
            if (predict == 0)
            {
                context.SetStrategy(new StrategyA());
                Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                Console.WriteLine("Peasant goes left");
            }
            else if (predict == 1)
            {
                context.SetStrategy(new StrategyB());
                Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                Console.WriteLine("Should I go right?");
                predict = rnd.Next(2);
                Console.WriteLine(predict);
                if (predict == 0)
                {
                    context.SetStrategy(new StrategyA());
                    Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                    Console.WriteLine("Peasant goes right");
                }
                else
                {
                    context.SetStrategy(new StrategyB());
                    Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                    Console.WriteLine("Should I go forward?");
                    predict = rnd.Next(2);
                    Console.WriteLine(predict);
                    if (predict == 0)
                    {
                        context.SetStrategy(new StrategyA());
                        Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                        Console.WriteLine("Peasant goes forward");
                    }
                    else if (predict == 1)
                    {
                        context.SetStrategy(new StrategyB());
                        Console.WriteLine("Answer of predictor: {0}", context.GetStrategy());
                        Console.WriteLine("Peasant goes back");
                    }
                }
            }
        }
        static void Adapter()
        {
            string text = Console.ReadLine();
            BinaryData bd = new BinaryData(text);
            ITarget target = new Adapter.Adapter(bd);
            Console.WriteLine(target.GetRequest());
        }
        static void Decorator()
        {
            Client client = new Client();

            var g = new DefaultGlasses();
            var wg = new WaterGlasses();
            Console.WriteLine("Client: I get a simple default glasses:");
            client.ClientCode(g);
            Console.WriteLine("Client: I get a simple water glasses:");
            client.ClientCode(wg);
            Console.WriteLine();
            DecoratorA decorator1 = new DecoratorA(g);
            DecoratorB decorator2 = new DecoratorB(decorator1);
            DecoratorC decorator3 = new DecoratorC(decorator2);
            Console.WriteLine("Client: Now I've got a decorated default glasses:");
            client.ClientCode(decorator3);
            DecoratorA wdecorator1 = new DecoratorA(wg);
            DecoratorB wdecorator2 = new DecoratorB(wdecorator1);
            DecoratorC wdecorator3 = new DecoratorC(wdecorator2);
            Console.WriteLine("Client: Now I've got a decorated water glasses:");
            client.ClientCode(wdecorator3);
        }
        static void Facade()
        {
            InstallButton b1 = new InstallButton();
            SettingsButton b2 = new SettingsButton();
            DeleteButton b3 = new DeleteButton();
            Facade.Facade facade = new Facade.Facade(b1, b2, b3);
            ClientF.ShowButtons(facade);
            Console.Write("Choose option: ");
            int n = int.Parse(Console.ReadLine());
            ClientF.ChooseButtons(facade, n);
        }
        static void Flyweight()
        {
            // этап инициализации приложения.
            var factory = new FlyweightFactory(
                new Grocery { Company = "Unilever", Type = "Lipton", Rack = "Teas 2" },
                new Grocery { Company = "Unilever", Type = "Calve", Rack = "Sauces 1" },
                new Grocery { Company = "Mondelez", Type = "Milka", Rack = "Sweets 2" },
                new Grocery { Company = "Mars", Type = "Mars", Rack = "Sweets 3" },
                new Grocery { Company = "Nestle", Type = "Nescafe", Rack = "Coffee 1" }
            );
            factory.listFlyweights();

            addProductToShop(factory, new Grocery
            {
                Company = "Mars",
                Type = "Snickers",
                Rack = "Sweets 3",
                ShelfNumber = "4"
            });

            addProductToShop(factory, new Grocery
            {
                Company = "Nestle",
                Type = "Nescafe",
                Rack = "Cofee 2",
                ShelfNumber = "4"
            });

            factory.listFlyweights();
        }
        public static void addProductToShop(FlyweightFactory factory, Grocery pr)
        {
            Console.WriteLine("\nClient: Adding a product to shop.");

            var flyweight = factory.GetFlyweight(new Grocery
            {
                Company = pr.Company,
                Type = pr.Type,
                Rack = pr.Rack
            });
            flyweight.Operation(pr);
        }
    }
}

