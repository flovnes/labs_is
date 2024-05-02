public class lab3 {
    const int LEN = 8;
    const int RESULT_LEN = LEN * 2;

    private static void SumBinary(int[] result, int[] num_two) {
      int carry = 0, i = RESULT_LEN;
      for (; i --> 0 ;) {
        int sum = result[i] + (i >= LEN ? num_two[i - LEN] : 0) + carry;
        carry = sum / 2;
        result[i] = sum % 2;
      }
      if (carry == 1) result[0] = 1;
    }

    private static void ProductBinary(int[] result, int[] num_one, int[] num_two) {
      for (int i = 0; i < LEN; i++) {
        for (int j = 0; j < RESULT_LEN - 1; j++) 
          result[j] = result[j+1];
        result[RESULT_LEN-1] = 0;

        if (num_one[i] == 1) SumBinary(result, num_two);
        
        Console.Write($"[{num_one[i]}] :");
        Print(result);
      }
    }

    private static void Print(int[] arr) {
      for (int i = 0; i < RESULT_LEN; i++)
        Console.Write(arr[i]);
      Console.WriteLine();
    }

    public static void Main() {
      int[] num1 = Console.ReadLine().Select(q => int.Parse(q.ToString())).ToArray();
      int[] num2 = Console.ReadLine().Select(q => int.Parse(q.ToString())).ToArray();
      int[] result = new int[RESULT_LEN];

      ProductBinary(result, num1, num2);

      Console.WriteLine("\nOutput (binary):");
      Print(result);
    }
  }