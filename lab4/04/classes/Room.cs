using System;
using System.Collections.Generic;
using System.Text;

namespace _04.classes
{
    public class Room
    {
        public const int BedsLimit = 3;

        private readonly List<Patient> patientsOnBeds;

        public int BedsOccupied => patientsOnBeds.Count;

        public bool AnyBedAvailable => (BedsOccupied < BedsLimit);

        public Room()
        {
            patientsOnBeds = new List<Patient>();
        }

        public IEnumerable<Patient> GetPatients() => patientsOnBeds;

        public bool PlacePatient(Patient patient)
        {
            if (!AnyBedAvailable)
                return false;

            patientsOnBeds.Add(patient);
            return true;
        }
    }
}
