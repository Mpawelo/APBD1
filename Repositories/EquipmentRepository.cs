using System.Collections.Generic;
using APBD1.Domain.Equipment;

namespace APBD1.Repositories
{
    public class EquipmentRepository
    {
        private readonly List<Equipment> _equipment = new List<Equipment>();

        public void Add(Equipment item)
        {
            _equipment.Add(item);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _equipment;
        }
    }
}