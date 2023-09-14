using MudBlazor;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace NumbersToText
{
    public abstract class Translator
    {
        public abstract string Translate(double value);
    }

    public class FrenchTranslator : Translator
    {
        // 1 000 000 000 000
        private static (long, long, string, bool)[] Factors = new (long, long, string, bool)[] { (1, 100, "", false), (100, 1_000, "cent", false),(1_000, 1_000_000, "mille", false), (1_000_000, 1_000_000_000, "million", true), (1_000_000_000, 1_000_000_000_000, "milliard", true) };

        private string TranslateNumber(long value)
        {
            if (FunOnes(value) is string early)
                return early;

            StringBuilder sb = new StringBuilder();

            if (value < 100)
            {
                sb.Append(TranslateNumber((value / 10) * 10));
                sb.Append('-');
                sb.Append(TranslateNumber(value % 10));
                return sb.ToString();
            }

            //if (value < 1_000)
            //{
            //    long c = value / 100;
            //    if (c > 0)
            //    {
            //        if (c > 1)
            //        {
            //            sb.Append(TranslateNumber(c));
            //            sb.Append(' ');
            //        }
                    
            //        sb.Append(Hundred);
            //        sb.Append(' ');
            //    }

            //    long rem = value % 100;
            //    sb.Append(TranslateNumber(rem));
            //    return sb.ToString();
            //}

            //if (value >= Factors.Last().Item2)
            //{
            //    var r = TranslateNumber(value / Factors.Last().Item2);
            //    sb.Append(r);
            //    sb.Append(" ");
            //    sb.Append(Factors.Last().Item3);
            //}

            foreach (var (min, max, name, explicitOne) in Factors.Reverse())
            {
                if (value < min)
                    continue;

                var scope = (value / min) % max;
                if (scope == 0)
                    continue;
                if (scope > 1 || explicitOne)
                {
                    var r = TranslateNumber(scope);
                    sb.Append(r);
                    sb.Append(" ");
                }
                sb.Append(name);
                long rem = value % min;
                if (rem > 0)
                {
                    sb.Append(" ");
                    sb.Append(TranslateNumber(rem));
                }
                break;
            }

            return sb.ToString();
        }

        private string? FunOnes(long value) => value switch
        {
            0 => "zero",
            1 => "un",
            2 => "deux",
            3 => "trois",
            4 => "quatre",
            5 => "cinq",
            6 => "six",
            7 => "sept",
            8 => "huigt",
            9 => "neuf",
            10 => "dix",
            11 => "onze",
            12 => "douze",
            13 => "treize",
            14 => "quatorze",
            15 => "quinze",
            16 => "seize",
            17 => "dix-sept",
            18 => "dix-huigt",
            19 => "dix-neuf",

            20 => "vingt",
            30 => "trente",
            40 => "quarante",
            50 => "cinquante",
            60 => "soixante",
            70 => "soixante-dix",
            80 => "quatre-vingt",
            90 => "quatre-vingt-dix",

            21 => "vingt-et-un",
            31 => "trente-et-un",
            41 => "quarante-et-un",
            51 => "cinquante-et-un",
            61 => "soixante-et-un",
            71 => "soixante-onze",
            81 => "quatre-vingt-un",
            91 => "quatre-vingt-onze",

            _ => null
        };

        public override string Translate(double value)
        {
            long ints = (long)value;
            long cents = (long)(value * 100f) % 100;

            var r = TranslateNumber(ints).Trim();
            if (cents > 0)
            {
                var rc = TranslateNumber(cents).Trim();
                r += $" dollards et {rc} cents";
            }

            return r;
        }
    }

    public class EnglishTranslator : Translator
    {
        // 1 000 000 000 000
        private static (long, long, string, bool)[] Factors = new (long, long, string, bool)[] { (1, 100, "", false), (100, 1_000, "hundred", true), (1_000, 1_000_000, "thousand", true), (1_000_000, 1_000_000_000, "million", true), (1_000_000_000, 1_000_000_000_000, "billion", true) };

        private string TranslateNumber(long value)
        {
            if (FunOnes(value) is string early)
                return early;

            StringBuilder sb = new StringBuilder();

            if (value < 100)
            {
                sb.Append(TranslateNumber((value / 10) * 10));
                sb.Append('-');
                sb.Append(TranslateNumber(value % 10));
                return sb.ToString();
            }

            foreach (var (min, max, name, explicitOne) in Factors.Reverse())
            {
                if (value < min)
                    continue;

                var scope = (value / min) % max;
                if (scope == 0)
                    continue;
                if (scope > 1 || explicitOne)
                {
                    var r = TranslateNumber(scope);
                    sb.Append(r);
                    sb.Append(" ");
                }
                sb.Append(name);
                long rem = value % min;
                if (rem > 0)
                {
                    sb.Append(" ");
                    sb.Append(TranslateNumber(rem));
                }
                break;
            }

            return sb.ToString();
        }

        private string? FunOnes(long value) => value switch
        {
            0 => "zero",
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            6 => "six",
            7 => "seven",
            8 => "eight",
            9 => "nine",
            10 => "ten",
            11 => "eleven",
            12 => "twelve",
            13 => "thirteen",
            14 => "fourteen",
            15 => "fifteen",
            16 => "sixteen",
            17 => "seventeen",
            18 => "eighteen",
            19 => "nineteen",

            20 => "twenty",
            30 => "thirty",
            40 => "fourty",
            50 => "fifty",
            60 => "sixty",
            70 => "seventy",
            80 => "eighty",
            90 => "ninety",

            _ => null
        };

        public override string Translate(double value)
        {
            long ints = (long)value;
            long cents = (long)(value * 100f) % 100;

            var r = TranslateNumber(ints).Trim();
            if (cents > 0)
            {
                var rc = TranslateNumber(cents).Trim();
                r += $" dollards and {rc} cents";
            }

            return r;
        }
    }
}
