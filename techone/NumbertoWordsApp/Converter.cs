public static class NumberToWordsConverter
{
    // Words for numbers 0 to 19
    private static readonly string[] Ones = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE",
        "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE",
        "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };

    // Words for tens multiples from 20 upwards
    private static readonly string[] Tens = { "", "", "TWENTY", "THIRTY", "FORTY",
        "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

    /// <summary>
    /// Converts a decimal number into words representing dollars and cents.
    /// </summary>
    /// <param name="number">Input number, e.g. 123.45</param>
    /// <returns>Number in words, e.g. "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"</returns>
    public static string Convert(decimal number)
    {
        if (number < 0)
            return "NEGATIVE " + Convert(-number);

        var dollars = (long)Math.Floor(number);  // Extract whole dollar amount
        var cents = (long)Math.Round((number - dollars) * 100); // Extract cents portion

        string dollarWords = dollars == 0 ? "ZERO DOLLARS" : $"{NumberToWords(dollars)} DOLLARS";
        string centWords = cents == 0 ? "" : $" AND {NumberToWords(cents)} CENTS";

        return dollarWords + centWords;
    }

    // Recursive helper method to convert a long number into words
    private static string NumberToWords(long number)
    {
        if (number < 20)
            return Ones[number];

        if (number < 100)
            return Tens[number / 10] + (number % 10 > 0 ? "-" + Ones[number % 10] : "");

        if (number < 1000)
            return Ones[number / 100] + " HUNDRED" + (number % 100 > 0 ? " AND " + NumberToWords(number % 100) : "");

        if (number < 1_000_000)
            return NumberToWords(number / 1000) + " THOUSAND" + (number % 1000 > 0 ? " " + NumberToWords(number % 1000) : "");

        if (number < 1_000_000_000)
            return NumberToWords(number / 1_000_000) + " MILLION" + (number % 1_000_000 > 0 ? " " + NumberToWords(number % 1_000_000) : "");

        // For billions and above
        return NumberToWords(number / 1_000_000_000) + " BILLION" + (number % 1_000_000_000 > 0 ? " " + NumberToWords(number % 1_000_000_000) : "");
    }
}
