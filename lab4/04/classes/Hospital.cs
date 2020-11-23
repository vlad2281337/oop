using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _04.classes
{
    public class Hospital
    {
        public List<Department> Departments { get; }

        public List<Doctor> Doctors { get; }

        public Hospital()
        {
            Departments = new List<Department>();
            Doctors = new List<Doctor>();
        }

        private Department FindDepartment(string departmentName, bool create = false)
        {
            Department department = Departments.Find(d => d.Name == departmentName);

            if (department == null)
            {
                if (create)
                {
                    department = new Department(departmentName);
                    Departments.Add(department);
                }
                else
                    throw new ArgumentException($"Department \"{departmentName}\" does not exist.");
            }

            return department;
        }

        private Doctor FindDoctor(string doctorName, string doctorSurname, bool create = false)
        {
            Doctor doctor = Doctors.Find(doc => doc.Name == doctorName && doc.Surname == doctorSurname);

            if (doctor == null)
            {
                if (create)
                {
                    doctor = new Doctor(doctorName, doctorSurname);
                    Doctors.Add(doctor);
                }
                else
                    throw new ArgumentException($"Doctor {doctorName} {doctorSurname} was not found.");
            }

            return doctor;
        }

        public void RegisterPatient(string patientName, string departmentName, out Patient patient)
        {
            var department = FindDepartment(departmentName, create: true);

            var existingPatient = department.GetAllPatients()
                                            .ToList()
                                            .Find(p => p.Name == patientName);

            if (existingPatient == null)
            {
                patient = new Patient(patientName);

                bool placed = department.PlacePatientOnFirstFreeBed(patient);
                if (!placed)
                    throw new ArgumentException($"Department \"{departmentName}\" is full.");
            }
            else
                patient = existingPatient;
        }

        public void AssignPatientToDoctor(Patient patient, string doctorName, string doctorSurname)
        {
            var doctor = FindDoctor(doctorName, doctorSurname, create: true);
            bool patientExists = doctor.Patients.Contains(patient);

            if (!patientExists)
                doctor.Patients.Add(patient);
        }

        public IEnumerable<Patient> GetPatientsByDepartment(string departmentName)
        {
            var department = FindDepartment(departmentName);
            return department.GetAllPatients();
        }

        public IEnumerable<Patient> GetPatientsInDepartmentRoomAsc(string departmentName, int roomNumber)
        {
            var department = FindDepartment(departmentName);
            var patients = department.GetPatientsInRoom(roomNumber).ToList();

            patients.Sort((left, right) => string.Compare(left.Name, right.Name));
            return patients;
        }

        public IEnumerable<Patient> GetPatientsOfDoctorAsc(string doctorName, string doctorSurname)
        {
            var doctor = FindDoctor(doctorName, doctorSurname);
            var patients = new List<Patient>(doctor.Patients);

            patients.Sort((left, right) => string.Compare(left.Name, right.Name));
            return patients;
        }
    }
}
