using System.Text;
namespace lab4 {
  public static partial class Lab4 {
    private static readonly char[] separator = [' ', '*', '^'];

    static void Main() {
      Console.OutputEncoding = UTF8Encoding.UTF8; 
      string input = Console.ReadLine();
      ParseInput(input, out string a_mnt_sign, out string a_ord_sign);
      input = Console.ReadLine();
      ParseInput(input, out string b_mnt_sign, out string b_ord_sign);

      string ngtv_b_ord = InvertSign(b_ord_sign);
      string a_ord_supp = intToSupp(a_ord_sign);
      string ngtv_b_ord_supp = intToSupp(ngtv_b_ord);

      string ord_diff_supp = Addition(a_ord_supp, ngtv_b_ord_supp);
      int ord_diff_dec = Math.Abs(intDecimalSupp(ord_diff_supp));

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

      string ngtv_b_mnt_sign = InvertSign(b_mnt_sign);
      string a_mnt_supp = floatToSupp(a_mnt_sign);
      string ngtv_b_mnt_supp = floatToSupp(ngtv_b_mnt_sign);
      string res = toSigned(Addition(a_mnt_supp, ngtv_b_mnt_supp));

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