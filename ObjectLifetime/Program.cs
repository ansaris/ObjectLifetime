using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLifetime
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            Car.MyMethod();

            /*
            myCar.Make = "Oldsmobile";
            myCar.Model = "Cutlas Supreme";
            myCar.Year = 1986;
            myCar.Color = "Silver";
            */

            Car myThirdCar = new Car("Jeep", "Thunder", 1969, "Yellow");

            Car myOtherCar;
            myOtherCar = myCar;

            Console.WriteLine("{0} {1} {2} {3}",
                myOtherCar.Make,
                myOtherCar.Model,
                myOtherCar.Year,
                myOtherCar.Color);

            myOtherCar.Model = "Accord";

            Console.WriteLine("{0} {1} {2} {3}",
                myCar.Make,
                myCar.Model,
                myCar.Year,
                myCar.Color);

            //myOtherCar = null;
            myCar = null;
            // "deterministic finalization" approach to garbage collection

            Console.WriteLine("{0} {1} {2} {3}",
            myOtherCar.Make,
            myOtherCar.Model,
            myOtherCar.Year,
            myOtherCar.Color);

            Console.ReadLine();
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car()
        {
            // You could load constructors from a configuration file,
            // a database, etc. to intialize default values
            this.Make = "Nissan";
        }

        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }

        public static void MyMethod()
        {
            Console.WriteLine("Called the static MyMethod");
            // Console.WriteLine(Make); // Won't work because is a static method
            // Make is not static, it is instance-based.
            // Static members vs Instance members
        }
    }
}
