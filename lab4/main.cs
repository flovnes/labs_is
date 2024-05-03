using System.Text;
namespace lab4 {
  public static partial class Program {
    private static readonly char[] separator = [' ', '*', '^'];

    static void Main() {
      Console.OutputEncoding = UTF8Encoding.UTF8; 
      Console.Write("\n1. Введіть дріб з плаваючою крапкою (наприклад, -0.101 * 2^101):  ");
      string input = Console.ReadLine();
      ParseInput(input, out string a_mnt_sign, out string a_ord_sign);

      Console.Write("\n2. Введіть дріб з плаваючою крапкою (наприклад, -0.101 * 2^101):  ");
      input = Console.ReadLine();
      ParseInput(input, out string b_mnt_sign, out string b_ord_sign);

      Console.WriteLine($"\nA мантиса (двійкова): {a_mnt_sign} = {bitToSign(a_mnt_sign)}{doubleDecimalSigned(a_mnt_sign)}");
      Console.WriteLine($"A період (двійкова): {a_ord_sign} = {bitToSign(a_ord_sign)}{intDecimalSigned(a_ord_sign)}");
      Console.WriteLine($"B мантиса (двійкова): {b_mnt_sign} = {bitToSign(b_mnt_sign)}{doubleDecimalSigned(b_mnt_sign)}");
      Console.WriteLine($"B період (двійкова): {b_ord_sign} = {bitToSign(b_ord_sign)}{intDecimalSigned(b_ord_sign)}");

      Console.WriteLine($"\nA = {a_mnt_sign}{a_ord_sign}\nB = {b_mnt_sign}{b_ord_sign}");
      
      string ngtv_b_ord = InvertSign(b_ord_sign);
      string a_ord_supp = intToSupp(a_ord_sign);
      string ngtv_b_ord_supp = intToSupp(ngtv_b_ord);

      Console.WriteLine($"\nA період (додатковий код): {a_ord_supp} = {intDecimalSupp(a_ord_supp)}");
      Console.WriteLine($"від'ємний B період (прямий код): {ngtv_b_ord}");
      Console.WriteLine($"від'ємний B період (додатковий код): {ngtv_b_ord_supp} = {intDecimalSupp(ngtv_b_ord_supp)}");

      string ord_diff_supp = Addition(a_ord_supp, ngtv_b_ord_supp);
      int ord_diff_dec = Math.Abs(intDecimalSupp(ord_diff_supp));

      Console.WriteLine($"\nРізниця періодів: |{a_ord_sign} - {b_ord_sign}| = |{a_ord_supp} + {ngtv_b_ord_supp}| = {ord_diff_supp} ({ord_diff_dec})");

      string ord_sign = a_ord_sign;
      if (ord_diff_dec != 0) {
        if (ord_diff_supp[0] == '0') {
          b_mnt_sign = b_mnt_sign[0] + ShiftRight(b_mnt_sign[1..], ord_diff_dec);
          ord_sign = b_ord_sign;
        } else {
          a_mnt_sign = a_mnt_sign[0] + ShiftRight(a_mnt_sign[1..], ord_diff_dec);
          ord_sign = a_ord_sign;
        }
      }

      Console.WriteLine($"\nЗсунуті значення:\nA мантиса (прямий код): {a_mnt_sign} = {bitToSign(a_mnt_sign)}{doubleDecimalSigned(a_mnt_sign)}");
      Console.WriteLine($"B мантиса (прямий код): {b_mnt_sign} = {bitToSign(b_mnt_sign)}{doubleDecimalSigned(b_mnt_sign)}");
      
      string ngtv_b_mnt_sign = InvertSign(b_mnt_sign);
      string a_mnt_supp = floatToSupp(a_mnt_sign);
      string ngtv_b_mnt_supp = floatToSupp(ngtv_b_mnt_sign);
      
      Console.WriteLine($"\nA - B = A_дод + (-B)_дод:\nA мантиса (додатковий код): {a_mnt_supp} = {doubleDecimalSupp(a_mnt_supp)}");
      Console.WriteLine($"від'ємна B мантиса (прямий код): {ngtv_b_mnt_sign} = {(ngtv_b_mnt_sign[0] == '1' ? "-" : "")}{doubleDecimalSigned(ngtv_b_mnt_sign)}");
      Console.WriteLine($"від'ємна B мантиса (додатковий код): {ngtv_b_mnt_supp}  = {doubleDecimalSupp(ngtv_b_mnt_supp)}");

      string res = Addition(a_mnt_supp, ngtv_b_mnt_supp);

      Console.WriteLine($"\nA_n + (-B_n) = {res} (додатковий код)");

      res = toSigned(res);

      Console.WriteLine($"\nA - B = {res[0]}|{res[1..]} {ord_sign[0]}|{ord_sign[1..]} (прямий код) = {doubleDecimalSupp(res)}");
      Console.WriteLine($"\nC = {res}{a_ord_sign}");
      int leadingZeros = 0;
      for (int i = 1; i < res.Length - 1 && res[i] == '0'; i++)
          leadingZeros++;

      int exponent = intDecimalSigned(ord_sign) - leadingZeros;
      string adjustedExponent = intToSupp(intToBinary(exponent));

      string trimmedMantissa = res[..1] + res[(1 + leadingZeros)..];

      Console.WriteLine($"\nC = {trimmedMantissa[0]}|{trimmedMantissa[1..]} {adjustedExponent[0]}|{adjustedExponent[1..]} (прямий код) = {doubleDecimalSupp(trimmedMantissa)}");
      Console.WriteLine($"\nC = {trimmedMantissa}{adjustedExponent}");
    }
  }
}
