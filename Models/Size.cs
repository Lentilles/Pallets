using Pallets.Interfaces;

namespace Pallets.Models
{
    public class Size : IVolumeable
    {
        public static Size DefaultMinSize = new Size() { Width = 100, Depth = 100, Height = 10};
        public static Size DefaultMaxSize = new Size() { Width = 400, Depth = 400, Height = 20};

        public int Width;
        public int Height;
        public int Depth;

        public long GetVolume()
        {
            try
            {
                return Width * Height * Depth;
            }
            catch
            {
                Console.WriteLine("Введены некорректные размеры");
            }

            return 0;
        }
    }
}
