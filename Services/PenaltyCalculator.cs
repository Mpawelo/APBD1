using System;

namespace APBD1.Services
{
    public class PenaltyCalculator
    {
        private const decimal PenaltyPerDay = 10.0m;

        public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
        {
            if (returnDate <= dueDate)
                return 0m;

            int daysLate = (returnDate - dueDate).Days;
            return daysLate * PenaltyPerDay;
        }
    }
}