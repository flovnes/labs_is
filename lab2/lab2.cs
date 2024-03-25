namespace Lab2 {
  public class Lab2 {
    const int LEN = 9;

    private static void SumBinary(ref int i, ref int []sum, int num_one, int num_two) {
      int carry = 0;
      while (num_one != 0 || num_two != 0) {
        sum[i++] = (num_one % 10 + num_two % 10 + carry) % 2;
        carry = (num_one % 10 + num_two % 10 + carry) / 2;
        num_one = num_one/10;
        num_two = num_two/10;
      }
      if (carry == 1) sum[i++] = carry;
    }

    private static void PrintResult(int []sum, int i) {
      int result = 0;
      System.Console.WriteLine("\nOutput (binary):");
      for (;i --> 0;) {
        System.Console.Write(sum[i]);
        result += (int)System.Math.Pow(2, i) * sum[i];
      }
      System.Console.WriteLine($"\nOutput (decimal): \n{result}");
    }

    public static void Main() {
      int[] sum = new int[LEN + 1];
      string num_bin;
      double result = 0.0;
      
      System.Console.Write("\nДробове число в 2-й сч: ");
      num_bin = System.Console.ReadLine();
      for (int i = 1; i <= num_bin.Length; i++) 
        result += num_bin[i-1] == '1' ? System.Math.Pow(2, -i) : 0;
      
      System.Console.Write($"Result: {result}");
      // System.Console.Write("\nПрямий код: ");
      // num_bin = ReadNum();
      // for (int i = 0; i < LEN; i++) {
      //   num_bin[i] = int.Parse(input[i]); 
      // }
    }
  }
}
