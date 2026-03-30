using System;

namespace APBD1.Domain.Equipment
{
    public enum EquipmentStatus
    {
        Available,
        Rented,
        InService
    }

    public abstract class Equipment
    {
        public Guid Id { get; private set; } 
        public string Name { get; private set; }
        public EquipmentStatus Status { get; private set; }

        protected Equipment(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nazwa sprzętu nie może być pusta.");

            Id = Guid.NewGuid();
            Name = name;
            Status = EquipmentStatus.Available;
        }

        public void ChangeStatus(EquipmentStatus newStatus)
        {
            Status = newStatus;
        }
    }
}