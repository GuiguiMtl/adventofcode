namespace day4_part1
{
    public class HeightIn : Height
    {
        public override bool Validate()
        {
            return Value >= 59 && Value <= 76;
        }

        public HeightIn(int value) : base(value)
        {
        }
    }
}