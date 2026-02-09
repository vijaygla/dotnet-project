using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Domain.Entities;
using SCMS.Infrastructure.IO;
using SCMS.Domain.Interfaces;

namespace SCMS.Infrastructure.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private List<Service> services;

        public ServiceRepository()
        {
            services = new List<Service>(); // Load from file later
        }

        public void Save(Service service)
        {
            var existingIndex = services.FindIndex(s => s.Id == service.Id);
            if (existingIndex >= 0)
            {
                services[existingIndex] = service;
            }
            else
            {
                services.Add(service);
            }
            // Save to file later
        }

        public List<Service> GetAll()
        {
            return services;
        }

        public Service FindById(string id)
        {
            return services.FirstOrDefault(s => s.Id == id);
        }

        public bool Exists(string id)
        {
            return services.Any(s => s.Id == id);
        }

        public void Delete(string id)
        {
            services.RemoveAll(s => s.Id == id);
            // Save to file later
        }
    }
}