using System;
namespace StateMS01
{
    public class Water
    {
        public IWaterState State;

        public Water(IWaterState state)
        {
            State = state;
        }

        public void Frost()
        {
            State.Frost(this);
        }

        public void Heat()
        {
            State.Heat(this);
        }
    }

    public interface IWaterState
    {
        void Frost(Water water);
        void Heat(Water water);
    }

    public class LiquidWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("We've produced solid water");
            water.State = new SolidWaterState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("We've produced gas water");
            water.State = new GasWaterState();
        }
    }

    public class SolidWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("Keep making solid water way more solid");
        }

        public void Heat(Water water)
        {
            Console.WriteLine("We've produced liquid water");
            water.State = new LiquidWaterState();
        }
    }

    public class GasWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("We've produced liquid water");
            water.State = new LiquidWaterState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Keep making gas water way more gas");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Heat();
            water.Frost();
            water.Frost();
            water.Frost();

            Console.ReadLine();
        }
    }
}