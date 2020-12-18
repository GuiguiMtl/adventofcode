namespace day4_part1
{
    public class HeightCm : Height
    {
        public override bool Validate()
        {
            return Value >= 150 && Value <= 193;
        }

        public HeightCm(int value) : base(value)
        {
        }
    }

    
}