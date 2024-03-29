﻿// three variables that store the number 2 million
// int decimalNotation = 2_000_000;
// int binaryNotation = 0b_0001_1110_1000_0100_1000_0000; 
// int hexadecimalNotation = 0x_001E_8480;
// check the three variables have the same value
// both statements output true 
// Console.WriteLine($"{decimalNotation == binaryNotation}"); 
// Console.WriteLine(
//   $"{decimalNotation == hexadecimalNotation}");

Console.WriteLine($"int uses {sizeof(int)} in the range {int.MinValue:N0} to {int.MaxValue:N0}");
Console.WriteLine($"int uses {sizeof(double)} in the range {double.MinValue:N0} to {double.MaxValue:N0}");
Console.WriteLine($"int uses {sizeof(decimal)} in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}");