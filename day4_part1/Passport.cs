using System.Collections.Generic;
using System.Text;

namespace day4_part1
{
    public class Passport
    {
        public Dictionary<string, string> PassportInformation { get; }

        public string RawValue { get; set; }
        
        private readonly PassportValidator _passportValidator;
        public Passport()
        {
            PassportInformation = new Dictionary<string, string>();
            _passportValidator = new PassportValidator(this);
        }

        public bool IsValid()
        {
            return _passportValidator.Validate();
        }

        public string GetValue(string key) => PassportInformation[key];

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var kvp in PassportInformation)
            {
                sb.Append($"{kvp.Key}:{kvp.Value}\n");
            }
            sb.Append("\n");
            return sb.ToString();
        }

        public void PrintInvalidValue() => _passportValidator.PrintInvalidValue();
    }
}