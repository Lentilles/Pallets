namespace Pallets.Models
{
    public interface ILoadPalletResult
    {
        public Guid PalletId { get; set; }
        public int LoadedCount { get; set; }
        public int SkipedCount { get; set; }
    }

    public class LoadPalletResult : ILoadPalletResult
    {
        public Guid PalletId { get; set; }
        public int LoadedCount { get; set; }
        public int SkipedCount { get; set; }
    }
}
