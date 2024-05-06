using System.Text;
namespace lab4 {
  public static partial class Lab4 {
    public static void ParseInput(string i, out string m_str, out string o_str) {
      string[] parts = i.Split(separator, StringSplitOptions.RemoveEmptyEntries);

      string part1 = parts[0];
      string part2 = parts[2];
      
      if (part1[0] == '-')
        m_str = '1' + parts[0][3..];
      else
        m_str = '0' + parts[0][2..];
      
      if (part2[0] == '-')
        o_str = '1' + parts[2][1..];
      else
        o_str = '0' + parts[2];
    }

    public static string ShiftRight(string n, int order) {
      string result = "";
      for (int i = 0; i < order; i++)
      result += '0';
      return result + n[..^order];
    }

    public static string Addition(string a, string b) {
      int len = Math.Min(a.Length-1, b.Length-1);
      string result = "";
      int carry = 0;
      
      for (int i = len; i >= 0; i--) {
        int sum = a[i] - '0' + (b[i] - '0') + carry;
        result = (sum % 2) + result;
        carry = sum / 2;
      }
      
      // числа у додатковому коді => не враховуємо переповнення
      
      return result;
    }

    public static int intDecimalSigned(string bin) {
      int dec = 0, len = bin.Length - 1;
      for (int i = 1; i <= len; i++)
        dec += bin[i] == '1' ? (int)Math.Pow(2, len - i) : 0;
      return dec;
    }

    public static double doubleDecimalSigned(string bin) {
      double dec = 0.0;
      for (int i = 1; i < bin.Length; i++) 
        dec += bin[i] == '1' ?  Math.Pow(2, -i) : 0; 
      return dec;
    }

    public static int intDecimalSupp(string bin) {
      int len = bin.Length - 1;
      int dec = 0;
        for (int i = 1; i <= len; i++) 
          dec += bin[i] == '1' ? (int)Math.Pow(2, len - i) : 0; 
        dec -= bin[0] == '1' ? (int)Math.Pow(2, len) : 0;
      return dec;
    }

    public static double doubleDecimalSupp(string bin) {
      int len = bin.Length - 1;
      double dec = 0;
      for (int i = 1; i <= len; i++) 
        dec += bin[i] == '1' ?  Math.Pow(2, -(i+1)) : 0; 
      dec -= bin[0] == '1' ? Math.Pow(2, -1) : 0;
      return dec;
    }

    public static string intToSupp(string num_bin) {
      if (num_bin[0] == '0') return num_bin;
      char[] bin = num_bin.ToCharArray();
      int i = bin.Length - 1;
      while (i > 0)
        if (bin[i--] == '1')
          break;
      while (i > 0)
        bin[i] = bin[i--] == '1' ? '0' : '1';

      return new string(bin);
    }

    public static string floatToSupp(string num_bin) {
      char[] bin = num_bin.ToCharArray();
      if (bin[0] == '0') {
        for (int j = 0; j < bin.Length - 1; j++)
            bin[j] = bin[j + 1];
        bin[^1] = '0';
        return new string(bin);
      }
      
      int i = bin.Length - 1;
      while (i >= 0)
        if (bin[i--] == '1')
          break;
      while (i >= 0)
        bin[i] = bin[i--] == '1' ? '0' : '1';
      for (int j = 0; j < bin.Length - 1; j++)
        bin[j] = bin[j + 1];
      bin[^1] = '0';

      return new string(bin);
    }

    public static string toSigned(string num_bin) {
      char[] bin = num_bin.ToCharArray();
      if (bin[0] == '1') {
        int i = bin.Length-1;
        while(i >= 0 && bin[i--] != '1')
        for (; i-- > 0 ;)  
          bin[i] = bin[i] == '1' ? '0' : '1';
      }
      return new string(bin);
    }

    public static string InvertSign(string bin) {
      return (bin[0] == '0') ? '1' + bin[1..] : '0' + bin[1..];
    }

    public static string bitToSign(string bin) {
      return bin[0] == '1' ? "-" : "";
    }

    public static string intToBinary(int value) {
      if (value == 0) return "0";

      StringBuilder binary = new();
      bool isNegative = value < 0;

      value = Math.Abs(value);

      while (value > 0) {
        binary.Insert(0, value % 2);
        value /= 2;
      }

      if (isNegative) {
        binary.Insert(0, '1');
        return floatToSupp(binary.ToString());
      }

      return binary.ToString();
    }
  }
}