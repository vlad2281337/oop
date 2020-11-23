using System;
using System.Collections.Generic;
using System.Text;

namespace _04.classes
{
    public class Department
    {
        public const int RoomLimit = 20;

        private string name;
        private readonly List<Room> rooms;

        public int RoomsOccupied => rooms.Count;

        public bool AnyRoomAvailable => (RoomsOccupied < RoomLimit);

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1 || value.Length > 100)
                    throw new ArgumentException("Department name must be 1-100 characters");
                name = value;
            }
        }

        public Department(string name)
        {
            Name = name;
            rooms = new List<Room>();
        }

        public bool PlacePatientOnFirstFreeBed(Patient patient)
        {
            if (rooms.Count > 0 && rooms[^1].PlacePatient(patient))
                return true;

            if (!AnyRoomAvailable)
                return false;

            var room = new Room();
            rooms.Add(room);
            return room.PlacePatient(patient);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();

            foreach (var room in rooms)
            {
                var roomPatients = room.GetPatients();
                patients.AddRange(roomPatients);
            }

            return patients;
        }

        public IEnumerable<Patient> GetPatientsInRoom(int roomNumber)
        {
            if (roomNumber < 1 || roomNumber > rooms.Count)
                throw new ArgumentException($"Room with number {roomNumber} does not exist.");
            return rooms[roomNumber - 1].GetPatients();
        }
    }
}
