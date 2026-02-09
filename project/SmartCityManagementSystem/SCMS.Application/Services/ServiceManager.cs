using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Domain.Entities;
using SCMS.Domain.Interfaces;
using SCMS.Infrastructure.Repositories;

namespace SCMS.Application.Services
{
    public class ServiceManager
    {
        private readonly ServiceRepository serviceRepository;
        private readonly CitizenRepository citizenRepository;

        public ServiceManager()
        {
            serviceRepository = new ServiceRepository();
            citizenRepository = new CitizenRepository();
        }

        public void BookHealthcareService(string citizenId, string serviceType)
        {
            Citizen citizen = citizenRepository.FindById(citizenId)
                ?? throw new ArgumentException("Citizen not found");

            HealthcareService service = new HealthcareService(citizenId, serviceType);
            serviceRepository.Save(service);
        }

        public void BookEducationService(string citizenId, string courseLevel)
        {
            Citizen citizen = citizenRepository.FindById(citizenId)
                ?? throw new ArgumentException("Citizen not found");

            EducationService service = new EducationService(citizenId, courseLevel);
            serviceRepository.Save(service);
        }

        public void CancelService(string serviceId)
        {
            Service service = serviceRepository.FindById(serviceId)
                ?? throw new ArgumentException("Service not found");
            serviceRepository.Delete(service.Id);
        }

        public List<Service> GetAllServices()
        {
            return serviceRepository.GetAll();
        }
    }
}
