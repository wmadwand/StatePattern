using System;

namespace Recall
{
    public class Water
    {
        public IWaterState state;

        public Water(IWaterState state)
        {
            this.state = state;
        }

        public void Frost()
        {
            state.Frost(this);
        }

        public void Heat()
        {
            state.Heat(this);
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
            Console.WriteLine("We've produced frost water");
            water.state = new FrostWaterState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("We've produced gas water");
            water.state = new GasWaterState();
        }
    }

    public class FrostWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("We've produced even more frost water");
        }

        public void Heat(Water water)
        {
            Console.WriteLine("We've produced liquid water");
            water.state = new LiquidWaterState();
        }
    }

    public class GasWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("We've produced liquid water");
            water.state = new LiquidWaterState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("We've produced even more gas water");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(new LiquidWaterState());

            water.Frost();
            water.Frost();

            water.Heat();
            water.Heat();
            water.Frost();
        }
    }
}
