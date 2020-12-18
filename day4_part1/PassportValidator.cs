using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace day4_part1
{
    public class PassportValidator
    {
        private readonly Passport _passport;

        public const string byr = "byr";
        public const string iyr = "iyr";
        public const string eyr = "eyr";
        public const string hgt = "hgt";
        public const string hcl = "hcl";
        public const string ecl = "ecl";
        public const string pid = "pid";

        public PassportValidator(Passport passport)
        {
            _passport = passport;
        }
        
        public bool Validate()
        {
            return ValidateBirthDate() &&
                   ValidateIssueDate() &&
                   ValidateExpirationDate() &&
                   ValidateHeight() &&
                   ValidateHairColor() &&
                   ValidateEyeColor() &&
                   ValidatePassportNumber();
        }

        private bool ValidateBirthDate() => KeyExists(byr) && ValidateYear(_passport.GetValue(byr), 1920, 2002);
        private bool ValidateIssueDate() => KeyExists(iyr) && ValidateYear(_passport.GetValue(iyr), 2010, 2020);
        private bool ValidateExpirationDate() => KeyExists(eyr) && ValidateYear(_passport.GetValue(eyr), 2020, 2030);
        private bool ValidatePassportNumber() => KeyExists(pid) && MatchRegex(_passport.GetValue(pid), @"\d{9}");
        private bool ValidateEyeColor() =>
            KeyExists(ecl) && MatchRegex(_passport.GetValue(ecl), "^(amb|blu|brn|gry|grn|hzl|oth)$");
        private bool ValidateHeight() => KeyExists(hgt) && HeightParser.TryParse(_passport.GetValue(hgt), out var height) && height.Validate();
        private bool ValidateHairColor() => KeyExists(hcl) && Regex.IsMatch(_passport.GetValue(hcl), "^#[0-9a-f]{6}$");

        private bool KeyExists(string key) => _passport.PassportInformation.ContainsKey(key);
        private bool ValidateYear(string value, int min, int max)
        {
            var yearInt = Convert.ToInt32(value);
            return yearInt >= min && yearInt <= max ;
        }

        private bool MatchRegex(string value, string pattern) => Regex.IsMatch(value, pattern);

        public void PrintInvalidValue()
        {
            if (!ValidateBirthDate()) Console.WriteLine(!KeyExists(byr) ? "Missing byr" : $"Invalid Value byr {_passport.GetValue(byr)}");
            if (!ValidateIssueDate()) Console.WriteLine(!KeyExists(iyr) ? "Missing iyr" : $"Invalid Value iyr {_passport.GetValue(iyr)}");
            if (!ValidateExpirationDate()) Console.WriteLine(!KeyExists(eyr) ? "Missing eyr" : $"Invalid Value eyr {_passport.GetValue(eyr)}");
            if (!ValidatePassportNumber()) Console.WriteLine(!KeyExists(pid) ? "Missing pid" : $"Invalid Value pid {_passport.GetValue(pid)}");
            if (!ValidateEyeColor()) Console.WriteLine(!KeyExists(ecl) ? "Missing ecl" : $"Invalid Value ecl {_passport.GetValue(ecl)}");
            if (!ValidateHeight()) Console.WriteLine(!KeyExists(hgt) ? "Missing hgt" : $"Invalid Value hgt {_passport.GetValue(hgt)}");
            if (!ValidateHairColor()) Console.WriteLine(!KeyExists(hcl) ? "Missing hcl" : $"Invalid Value hcl {_passport.GetValue(hcl)}");
            Console.WriteLine();
        }

    }
}