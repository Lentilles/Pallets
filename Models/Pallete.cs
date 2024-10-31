using Pallets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallets.Models
{
    public class Pallete : IVolumeable
    {
        public Guid Id { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public decimal Weight { get { return 30 + Boxes.Sum(x => x.Weight); } }
        public DateOnly ShelfLife { 
            get 
            {
                return Boxes.Min(x => x.ShelfLife); 
            }
        }
        public List<Box> Boxes = new List<Box>();

        public long GetVolume()
        {
            try
            {
                long volume = 0;
                foreach (var box in Boxes)
                {
                    volume += box.GetVolume();
                }

                return volume + (long)(Width * Height * Depth);
            }
            catch
            {
                Console.WriteLine("Введены некорректные размеры");
            }
        
            return 0;
        }

        public bool TryAddBox(Box box)
        {
            if(box.Width <= Width && box.Depth <= Depth)
            {
                Boxes.Add(box);
                return true;
            }

            return false;
        }
    }
}
