using System;
using System.Collections.Generic;
using System.Linq;
using APBD1.Domain.Equipment;
using APBD1.Domain.Users;
using APBD1.Domain.Rentals;

namespace APBD1.Services
{
    public class RentalService
    {
        private readonly PenaltyCalculator _penaltyCalculator;

        public RentalService(PenaltyCalculator penaltyCalculator)
        {
            _penaltyCalculator = penaltyCalculator;
        }

        public Rental RentEquipment(User user, Equipment equipment, int durationInDays, IEnumerable<Rental> allRentals)
        {
            if (equipment.Status != EquipmentStatus.Available)
            {
                throw new InvalidOperationException($"Sprzęt {equipment.Name} jest niedostępny do wypożyczenia.");
            }

            int activeRentalsCount = allRentals.Count(r => r.UserId == user.Id && r.IsActive);
            if (activeRentalsCount >= user.MaxConcurrentRentals)
            {
                throw new InvalidOperationException($"Użytkownik {user.FirstName} przekroczył limit aktywnych wypożyczeń ({user.MaxConcurrentRentals}).");
            }

            equipment.ChangeStatus(EquipmentStatus.Rented);
            return new Rental(equipment.Id, user.Id, durationInDays);
        }

        public void ReturnEquipment(Rental rental, Equipment equipment, DateTime returnDate)
        {
            if (!rental.IsActive)
            {
                throw new InvalidOperationException("To wypożyczenie zostało już zakończone.");
            }

            decimal penalty = _penaltyCalculator.CalculatePenalty(rental.DueDate, returnDate);

            rental.FinishRental(returnDate, penalty);
            equipment.ChangeStatus(EquipmentStatus.Available);
        }
    }
}