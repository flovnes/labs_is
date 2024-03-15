namespace Lab1 {
  public class Lab1 {
    const int LEN = 9;
    private static void ReadNumbers(out int num_one, out int num_two) {
      System.Console.WriteLine("Input 1:");
      num_one = int.Parse(System.Console.ReadLine());
      System.Console.WriteLine("Input 2:");
      num_two = int.Parse(System.Console.ReadLine());
    }

    private static void SumBinary(ref int i, int []sum, int num_one, int num_two) {
      int carry = 0;
      while (num_one != 0 || num_two != 0) {
        sum[i++] = (num_one % 10 + num_two % 10 + carry) % 2;
        carry = (num_one % 10 + num_two % 10 + carry) / 2;
        num_one /= 10;
        num_two /= 10;
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
      int i = 0;

      ReadNumbers(out int num_one, out int num_two);

      SumBinary(ref i, sum, num_one, num_two);

      PrintResult(sum, i);
    }
  }
}
