﻿namespace Pallets.Models
{
    public class Pallet
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public decimal Weight { get { return 30 + Boxes.Sum(x => x.Weight); } }
        public long Volume { get { return Size.GetVolume() + Boxes.Sum(box=>box.Size.GetVolume()); } }
        public DateOnly? ShelfLife { 
            get 
            {
                if(Boxes.Count != 0)
                {
                    return Boxes.Min(x => x.ShelfLife); 
                }
                else
                {
                    return null;
                }
            }
        }
        public List<Box> Boxes = new List<Box>();

        public ILoadPalletResult AddBox(Box box)
        {
            var isBoxFitOnPallet = box.Size.Width <= Size.Width && box.Size.Depth <= Size.Depth;
            
            if (isBoxFitOnPallet)
            {
                Boxes.Add(box);
            }

            return new LoadPalletResult()
            {
                PalletId = Id,
                LoadedCount = isBoxFitOnPallet ? 1 : 0,
                SkipedCount = isBoxFitOnPallet ? 0 : 1
            };
        }

        public ILoadPalletResult AddBoxRange(IEnumerable<Box> boxes)
        {
            var suitableBoxes = boxes
                .Where(box => box.Size.Width <= Size.Width && box.Size.Depth <= Size.Depth);
            
            Boxes.AddRange(suitableBoxes);

            var countOfSuitableBoxes = suitableBoxes.Count();

            return new LoadPalletResult()
            {
                PalletId = Id,
                LoadedCount = countOfSuitableBoxes,
                SkipedCount = boxes.Count() - countOfSuitableBoxes
            };
        }
    }


}
