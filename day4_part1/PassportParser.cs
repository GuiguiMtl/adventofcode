using System.Collections.Generic;
using System.IO;

namespace day4_part1
{
    public class PassportParser
    {
        private readonly string _path;
        private const string EOL = "\r\n";
        public PassportParser(string path)
        {
            _path = path;
        }

        public List<Passport> Parse()
        {
            var passports = new List<Passport>();
            using var streamReader = new StreamReader(_path);
            var fullFile = streamReader.ReadToEnd();

            var passportsString = fullFile.Split($"{EOL}{EOL}");

            foreach (var passportToParse in passportsString)
            {
                var passport = new Passport
                {
                    RawValue = passportToParse
                };
                var lineInfos = passportToParse.Split(EOL);
                foreach (var allInfosOnLine in lineInfos)
                {
                    var allInfosOnLineTab = allInfosOnLine.Split(" ");
                    foreach (var info in allInfosOnLineTab)
                    {
                        var infos = info.Split(':');
                        if(infos.Length == 2)
                        {
                            passport.PassportInformation.Add(infos[0], infos[1]);
                        }
                    }
                    
                }
                passports.Add(passport);
            }

            return passports;
        }
        
    }
}