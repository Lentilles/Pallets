namespace Pallets.Models
{
    public class Pallet
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public decimal Weight { get { return 30 + Boxes.Sum(x => x.Weight); } }
        public DateOnly ShelfLife { 
            get 
            {
                return Boxes.Min(x => x.ShelfLife); 
            }
        }
        public List<Box> Boxes = new List<Box>();

        public bool TryAddBox(Box box)
        {
            var isBoxFitOnPallet = box.Size.Width <= Size.Width && box.Size.Depth <= Size.Depth;
            
            if (isBoxFitOnPallet)
            {
                Boxes.Add(box);
            }

            return isBoxFitOnPallet;
        }

        public bool TryAddBoxRange(IEnumerable<Box> boxes)
        {
            var isAllBoxesFitOnPallet = boxes
                .Where(box => box.Size.Width <= Size.Width && box.Size.Depth <= Size.Depth)
                .Count() == boxes.Count();

            if (isAllBoxesFitOnPallet)
            {
                Boxes.AddRange(boxes);
            }

            return isAllBoxesFitOnPallet;
        }
    }
}
