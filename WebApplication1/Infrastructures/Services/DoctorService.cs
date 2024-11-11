using BusinessLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.DoctorEntities;

namespace WebApplication1.Infrastructures.Services
{
    public class DoctorsService
    {
        private DataManager _dataManager;
        public DoctorsService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void CreateDoctor(DoctorVm doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException("doctor is null");
            }

            Doctor DbDoctor = GetDoctorDBModel(doctor);
            _dataManager.Doctors.Create(DbDoctor);
        }

        public List<DoctorVm> GetAllDoctors()
        {
            var _doctors = _dataManager.Doctors.GetAll();

            List<DoctorVm> doctorsList = new List<DoctorVm>();

            foreach (var item in _doctors)
            {
                doctorsList.Add(GetDoctorVmEntity(item));
            }
            return doctorsList;
        }

        public DoctorVm GetDoctorById(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }

            var doctor = _dataManager.Doctors.GetById(Id.Value);

            return GetDoctorVmEntity(doctor);
        }

        public void DeleteDoctor(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }

            _dataManager.Doctors.Delete(Id.Value);
        }

        public void EditDoctor(DoctorVm doctorVm)
        {
            var doctor = GetDoctorDBModel(doctorVm);
            _dataManager.Doctors.Update(doctor);
        }

        private Doctor GetDoctorDBModel(DoctorVm vm)
        {
            Doctor doctor = new Doctor()
            {
                Id = vm.Id,
                Name = vm.Name
            };

            return doctor;
        }

        private DoctorVm GetDoctorVmEntity(Doctor doctor)
        {
            DoctorVm doctorVm = new DoctorVm()
            {
                Id = doctor.Id,
                Name = doctor.Name
            };

            return doctorVm;
        }
    }
}
