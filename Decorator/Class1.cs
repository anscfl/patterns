using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Glasses
    {
        public abstract string Operation();
    }
    public class DefaultGlasses : Glasses
    {
        public override string Operation()
        {
            return "Default Glasses";
        }
    }
    public class WaterGlasses : Glasses
    {
        public override string Operation()
        {
            return "Water Glasses";
        }
    }
    public abstract class Decorator : Glasses
    {
        protected Glasses _component;

        public Decorator(Glasses component)
        {
            this._component = component;
        }

        public void SetComponent(Glasses component)
        {
            this._component = component;
        }
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }
    public class DecoratorA : Decorator
    {
        public DecoratorA(Glasses comp) : base(comp)
        {
        }
        public override string Operation()
        {
            return $"Vision {base.Operation()}";
        }
    }
    public class DecoratorB : Decorator
    {
        public DecoratorB(Glasses comp) : base(comp)
        {
        }
        public override string Operation()
        {
            return $"Polarized {base.Operation()}";
        }
    }
    public class DecoratorC : Decorator
    {
        public DecoratorC(Glasses comp) : base(comp)
        {
        }
        public override string Operation()
        {
            return $"Photochromatic {base.Operation()}";
        }
    }

    public class Client
    {
        public void ClientCode(Glasses component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }
}
