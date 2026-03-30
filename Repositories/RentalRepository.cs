using System.Collections.Generic;
using APBD1.Domain.Rentals;

namespace APBD1.Repositories
{
    public class RentalRepository
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public void Add(Rental rental)
        {
            _rentals.Add(rental);
        }

        public IEnumerable<Rental> GetAll()
        {
            return _rentals;
        }
    }
}