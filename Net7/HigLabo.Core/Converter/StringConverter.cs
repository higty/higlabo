using System;

namespace HigLabo.Core
{
    public class StringConverter
    {
        private const Int32 FullHalfDifference = 65248;
        public Boolean FullWidthNumber { get; set; }
        public Boolean HalfWidthNumber { get; set; }
        public Boolean FullWidthAlphabet { get; set; }
        public Boolean HalfWidthAlphabet { get; set; }

        public String ToFullWidth(String value)
        {
            var cc = new Char[value.Length];

            for (Int32 i = 0; i < value.Length; i++)
            {
                var c = value[i];
                var isConvert = false;
                if (isConvert == false && this.HalfWidthNumber && 48 <= c && c <= 58) { isConvert = true; }
                if (isConvert == false && this.HalfWidthAlphabet && 65 <= c && c <= 90) { isConvert = true; }
                if (isConvert == false && this.HalfWidthAlphabet && 97 <= c && c <= 122) { isConvert = true; }

                if (isConvert == true)
                {
                    cc[i] = (char)(value[i] + FullHalfDifference);
                }
                else
                {
                    cc[i] = value[i];
                }
            }
            return new String(cc);
        }
        public String ToHalfWidth(String value)
        {
            var cc = new Char[value.Length];

            for (Int32 i = 0; i < value.Length; i++)
            {
                var c = value[i];
                var isConvert = false;
                if (isConvert == false && this.FullWidthNumber && 65296 <= c && c <= 65306) { isConvert = true; }
                if (isConvert == false && this.FullWidthAlphabet && 65313 <= c && c <= 65338) { isConvert = true; }
                if (isConvert == false && this.FullWidthAlphabet && 65345 <= c && c <= 65370) { isConvert = true; }

                if (isConvert == true)
                {
                    cc[i] = (char)(value[i] - FullHalfDifference);
                }
                else
                {
                    cc[i] = value[i];
                }
            }
            return new String(cc);
        }
    }
}
