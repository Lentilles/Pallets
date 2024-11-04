using Pallets.Models;
using Pallets.Repositories;

namespace Pallets.Services
{
    public interface IPalletService
    {
        public IEnumerable<IGrouping<DateOnly, Pallet>> GetAllPalletsGroupedByShelfLife();
    }
    public class PalletService : IPalletService
    {
        private readonly IPalletRepository _palletRepository;

        public PalletService(IPalletRepository palletRepository) {
            _palletRepository = palletRepository;
        }

        public IEnumerable<IGrouping<DateOnly, Pallet>> GetAllPalletsGroupedByShelfLife()
        {
            return _palletRepository.GetAllPalletsGroupedByShelfLife();
        }
    }
}
