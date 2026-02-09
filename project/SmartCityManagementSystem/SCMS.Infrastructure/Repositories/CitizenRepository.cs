using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Domain.Entities;
using SCMS.Infrastructure.IO;
using System.Text.Json;
using SCMS.Domain.Interfaces;

namespace SCMS.Infrastructure.Repositories
{
    public class CitizenRepository : IRepository<Citizen>
    {
        private List<Citizen> citizens;

        public CitizenRepository()
        {
            citizens = FileManager.LoadCitizens() ?? new List<Citizen>();
        }

        public void Save(Citizen citizen)
        {
            var existingIndex = citizens.FindIndex(c => c.Id == citizen.Id);
            if (existingIndex >= 0)
            {
                citizens[existingIndex] = citizen;
            }
            else
            {
                citizens.Add(citizen);
            }
            FileManager.SaveCitizens(citizens);
        }

        public List<Citizen> GetAll()
        {
            return citizens;
        }

        public Citizen FindById(string id)
        {
            return citizens.FirstOrDefault(c => c.Id == id);
        }

        public bool Exists(string id)
        {
            return citizens.Any(c => c.Id == id);
        }

        public void Delete(string id)
        {
            citizens.RemoveAll(c => c.Id == id);
            FileManager.SaveCitizens(citizens);
        }
    }
}
