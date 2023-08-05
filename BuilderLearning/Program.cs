using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleWorker vehicleWorker = new VehicleWorker();
            VehicleBuilder vehicleBuilder = new CarVehicleBuilder();

            Vehicle carVehicle = vehicleWorker.CreateVehicle(vehicleBuilder);
            Console.WriteLine(carVehicle.GetVehicleInfo());

            vehicleBuilder = new BicycleVehicleBuilder();
            Vehicle bicycleVehicle = vehicleWorker.CreateVehicle(vehicleBuilder);
            Console.WriteLine(bicycleVehicle.GetVehicleInfo());

        }
    }

    //wheels
    class Wheels
    {
        // WheelsCount
        public int Count { get; set; }
    }
    // Engine
    class Engine
    {
        //Engine type
        public string EngineType { get; set; }
    }
    // Body
    class Body
    {
        public string BodyType { get; set; }
    }

    // abstract class Vehicle builder
    abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; private set; }
        public void CreateVehicle()
        {
            Vehicle = new Vehicle();
        }
        public abstract void SetWheels();
        public abstract void SetEngine();
        public abstract void SetBody();
    }

    class Vehicle
    {
        // Wheels
        public Wheels Wheels { get; set; }
        // Engine
        public Engine Engine { get; set; }
        // Body
        public Body Body { get; set; }
        public string GetVehicleInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (Wheels != null)
                sb.Append("Количество колёс: " + Wheels.Count + "\n");
            if (Engine != null)
                sb.Append("Модель двигателя: " + Engine.EngineType + "\n");
            if (Body != null)
                sb.Append("Корпус: " + Body.BodyType + " \n");
            return sb.ToString();
        }
    }

    // vehicle worker which creates vehicles
    class VehicleWorker
    {
        public Vehicle CreateVehicle(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.CreateVehicle();
            vehicleBuilder.SetWheels();
            vehicleBuilder.SetEngine();
            vehicleBuilder.SetBody();
            return vehicleBuilder.Vehicle;
        }
    }
    // car vehicle builder
    class CarVehicleBuilder : VehicleBuilder
    {
        public override void SetWheels()
        {
            this.Vehicle.Wheels = new Wheels { Count = 4};
        }

        public override void SetEngine()
        {
            this.Vehicle.Engine = new Engine { EngineType = "V12" };
        }

        public override void SetBody()
        {
            this.Vehicle.Body = new Body { BodyType = "Car body" };
        }
    }
    // bicycle vehicle builder
    class BicycleVehicleBuilder : VehicleBuilder
    {
        public override void SetWheels()
        {
            this.Vehicle.Wheels = new Wheels { Count = 2 };
        }

        public override void SetEngine()
        {
            
        }

        public override void SetBody()
        {
            this.Vehicle.Body = new Body { BodyType = "Bicycle body" };
        }
    }
}
