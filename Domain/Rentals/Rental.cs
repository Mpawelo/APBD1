using System;

namespace APBD1.Domain.Rentals
{
    public class Rental
    {
        public Guid Id { get; private set; }
        public Guid EquipmentId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime RentalDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public decimal PenaltyFee { get; private set; }
        public bool IsActive => ReturnDate == null;

        public Rental(Guid equipmentId, Guid userId, int durationInDays)
        {
            if (durationInDays <= 0)
                throw new ArgumentException("Czas wypożyczenia musi być dłuższy niż 0 dni.");

            Id = Guid.NewGuid();
            EquipmentId = equipmentId;
            UserId = userId;
            RentalDate = DateTime.Now;
            DueDate = RentalDate.AddDays(durationInDays);
            PenaltyFee = 0;
        }

        public void FinishRental(DateTime returnDate, decimal penalty)
        {
            if (!IsActive)
                throw new InvalidOperationException("To wypożyczenie zostało już zakończone.");

            ReturnDate = returnDate;
            PenaltyFee = penalty;
        }
    }
}