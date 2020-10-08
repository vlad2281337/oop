using System;
using System.Collections.Generic;
using System.Text;

namespace _07
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public int DistanceTraveled { get; private set; }


        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumption;
        }

        public bool HasEnoughFuelToMove(int kilometers)
            => kilometers * FuelConsumptionPerKm <= FuelAmount;

        public void Drive(int kilometers)
        {
            FuelAmount -= kilometers * FuelConsumptionPerKm;
            DistanceTraveled += kilometers;
        }

        public override string ToString()
            => $"{Model} {FuelAmount:0.00} {DistanceTraveled}";
    }
}
