﻿static void RunCardinalToOrdinal()
{
  for (int number = 1; number <= 40; number++)
  {
    Console.Write($"{CardinalToOrdinal(number)} ");
  }
  Console.WriteLine();
}

/// <summary>
/// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
/// </summary>
/// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
/// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
static string CardinalToOrdinal(int number)
{
  switch (number)
  {
    case 11: // special cases for 11th to 13th
    case 12:
    case 13:
      return $"{number}th";
    default:
      int lastDigit = number % 10;
      string suffix = lastDigit switch
      {
        1 => "st",
        2 => "nd",
        3 => "rd",
        _ => "th"
      };
      return $"{number}{suffix}";
  }
}

RunCardinalToOrdinal();
