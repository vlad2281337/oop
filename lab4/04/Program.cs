using _04.classes;
using System;
using System.Collections.Generic;

namespace _04

{
    class Program
    {
        static void Main(string[] args)
        {
            var hospital = new Hospital();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Output")
                    break;

                var inputs = line.Split(' ');

                string departmentName = inputs[0],
                        doctorName = inputs[1],
                        doctorSurname = inputs[2],
                        patientName = inputs[3];

                Patient patient = null;

                try
                {
                    hospital.RegisterPatient(patientName, departmentName, out patient);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Patient was not registered. {ex.Message}");
                }

                try
                {
                    hospital.AssignPatientToDoctor(patient, doctorName, doctorSurname);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Patient was not assigned to doctor. {ex.Message}");
                }
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                    break;

                Console.WriteLine();

                var inputs = line.Split(' ');

                try
                {
                    switch (inputs.Length)
                    {
                        case 1:
                            {
                                string departmentName = inputs[0];
                                var patients = hospital.GetPatientsByDepartment(departmentName);
                                PrintPatients(patients);
                                break;
                            }
                        case 2:
                            {
                                bool isRoomNumber = int.TryParse(inputs[1], out int roomNumber);
                                IEnumerable<Patient> patients;

                                if (isRoomNumber)
                                {
                                    string departmentName = inputs[0];
                                    patients = hospital.GetPatientsInDepartmentRoomAsc(departmentName, roomNumber);
                                }
                                else
                                {
                                    string doctorName = inputs[0],
                                            doctorSurname = inputs[1];
                                    patients = hospital.GetPatientsOfDoctorAsc(doctorName, doctorSurname);
                                }

                                PrintPatients(patients);
                                break;
                            }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void PrintPatients(IEnumerable<Patient> patients)
        {
            foreach (var patient in patients)
                Console.WriteLine(patient);
        }
    }
}