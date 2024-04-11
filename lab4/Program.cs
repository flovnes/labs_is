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
