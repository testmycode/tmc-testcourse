using System.Collections.Generic;

namespace Exercise
{
    public class Abbreviations
    {
        private Dictionary<string, string> abbrevs;

        public Abbreviations() {
            abbrevs = new Dictionary<string, string>();
        }

        public void AddAbbreviation(string abbreviation, string explanation)
        {
            abbrevs.Add(abbreviation, explanation);
        }

        public bool HasAbbreviation(string abbreviation)
        {
            return abbrevs.ContainsKey(abbreviation);
        }

        public string FindExplanationFor(string abbreviation)
        {
            return HasAbbreviation(abbreviation) ? abbrevs[abbreviation] : "not found";
        }
    }
}