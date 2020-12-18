namespace day4_part1
{
    public abstract class Height
    {
        public Height(int value)
        {
            Value = value;
        }
        public int Value { get; set; }

        public abstract bool Validate();
    }
}