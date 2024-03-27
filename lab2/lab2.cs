using System;
namespace Lab2 {
  public class Lab2 {
    const int LEN = 8;
    public static void Main() {
        bin_to_frac();
        signed_to_supplement();
    }
    static void signed_to_supplement() {
      Console.Write("\nПрямий код: ");
      char[] num_binary = Console.ReadLine().ToCharArray();

      if (num_binary[0] == '1') {
        int i = LEN - 1;
        while (i --> 1 && num_binary[i] == '0');
        for (;i --> 1;) num_binary[i] = num_binary[i] == '1' ? '0' : '1';
      }

      Console.Write("Додатковий код: ");
      Console.Write(new string(num_binary));
    }

    static void bin_to_frac() {
      double result = 0.0;
      Console.Write("Число (бінарне): ");
      char[] num_binary = Console.ReadLine().ToCharArray();

      for (int i = 1; i <= num_binary.Length; i++)
        result += num_binary[i - 1] == '1' ? Math.Pow(2, -i) : 0;

      Console.Write($"Дріб (десятковий): {result}");
    }
  }
}