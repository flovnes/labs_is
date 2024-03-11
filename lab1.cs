namespace Lab1 {
  public class Lab1 {
    public static void Main() {
      const int LEN = 9;
      int i = 0, carry = 0;
      int[] sum = new int[LEN + 1];

      Input(out int num_one, out int num_two);

      Add_binaries(sum, ref i, carry, num_one, num_two);

      System.Console.WriteLine("out:");
      while (i >= 0) System.Console.Write(sum[i--]);
    }

    private static void Add_binaries(int[] sum, ref int i, int carry, int num_one, int num_two) {
      while (num_one != 0 || num_two != 0) {
        sum[i++] = (num_one % 10 + num_two % 10 + carry) % 2;
        carry = (num_one % 10 + num_two % 10 + carry) / 2;
        num_one /= 10;
        num_two /= 10;
      }
      if (carry != 0) sum[i++] = carry;
      i--;
    }

    private static void Input(out int num_one, out int num_two) {
      System.Console.WriteLine("input1:");
      num_one = int.Parse(System.Console.ReadLine());
      System.Console.WriteLine("input2:");
      num_two = int.Parse(System.Console.ReadLine());
    }
  }
}