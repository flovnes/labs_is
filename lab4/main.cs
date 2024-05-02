#pragma warning disable IDE1006 // Naming Styles

using System.Reflection.Emit;
using System.Xml.XPath;

namespace lab4 {
	public class lab4 {
		const int LEN = 16;
		private static readonly char[] separator = [' ', '*', '^'];

		static void Main() {
			string input;
			// Console.Write("Enter a floating-point fraction (e.g., -0.101 * 2^101): ");
			// string input = Console.ReadLine();
			
			input = "-0.10101000000 * 2^101";
			parse_input(input, out string a_n, out string a_m);
			input = "0.11001000000 * 2^011";
			parse_input(input, out string b_n, out string b_m);

			string negative_b_m = (b_m[0] == '0') ? '1' + b_m[1..] : '0' + b_m[1..];
			string a_m_supp = signed_to_supplement(a_m.ToCharArray());
			string b_m_supp = signed_to_supplement(negative_b_m.ToCharArray());
			
			// ma + (-mb)
			string z = signed_addition(a_m_supp, b_m_supp);
			Console.WriteLine($"a_m + (-b_m): {z}");
			
			int difference = 0;
			// parse supp
			for (int i = z.Length - 2; i > 0; i--)
				difference += z[1..][i] == '1' ? (int)Math.Pow(2, i) : 0;
			difference -= z[0] == '1' ? (int)Math.Pow(2, z.Length-1) : 0;
				
			difference = Math.Abs(difference);
				
			// debug
			Console.WriteLine($"difference: |{a_m} - {b_m}| = {difference}");
			
			if (difference != 0) {
				if (z[0] == '0') {
					// a_m > b_m
					b_n = b_n[0] + shift_right(b_n[1..], difference);
					a_m = b_m;
				} else {
					// a_m < b_m
					a_n = a_n[0] + shift_right(a_n[1..], difference);
					b_m = a_m;
				}
			}
			
			// debug
			Console.WriteLine($"a_n: {a_n}");
			Console.WriteLine($"b_n: {b_n}");
			Console.WriteLine($"a_m: {a_m}");
			Console.WriteLine($"b_m: {b_m}");

			string a_n_supp = signed_to_supplement(a_m.ToCharArray());
			string b_n_supp = signed_to_supplement(a_n.ToCharArray());
			string res = signed_addition(a_n, b_n);
			Console.WriteLine($"result: {res} (decimal): {double_dec(res)}");
		}

		private static string shift_right(string n, int orderValue) {
			string result = "";
			for (int i = 0; i < orderValue; i++)
				result += '0';
			return result + n[..^orderValue];
		}

		private static string signed_addition(string a, string b) {
			string result = "";
			int carry = 0;
			for (int i = a.Length - 1; i >= 0; i--) {
				int sum = (a[i] - '0') + (b[i] - '0') + carry;
				result = (sum % 2) + result;
				carry = sum / 2;
			}
			
			// числа у додатковому коді -> не враховуємо переповнення
			return result;
		}

		private static void parse_input(string input, out string mantissa, out string order)
        {
            string[] parts = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            string part1 = parts[0];
            string sign_symbol = "";
            if (part1[0] == '-')
            {
                sign_symbol = "-";
                mantissa = '1' + parts[0][3..];
            }
            else
            {
                mantissa = '0' + parts[0][2..];
            }

            string part2 = parts[2];
            string order_sign_symbol = "";
            if (part2[0] == '-')
            {
                order_sign_symbol = "-";
                order = '1' + parts[2][1..];
            }
            else
            {
                order = '0' + parts[2];
            }

            double mantissaValue = double_dec(mantissa);

            int orderValue = 0, len = order.Length - 1;
            for (int i = 1; i <= len; i++)
                orderValue += order[i] == '1' ? (int)Math.Pow(2, len - i) : 0;

            // debug
            Console.WriteLine($"Mantissa (binary): {mantissa} (decimal): {sign_symbol}{mantissaValue}");
            Console.WriteLine($"Order (binary): {order} (decimal): {order_sign_symbol}{orderValue}");
        }

        private static double double_dec(string mantissa)
        {
            double mantissaValue = 0.0;
            for (int i = mantissa.Length - 1; i > 0; i--)
                mantissaValue += mantissa[i] == '1' ? Math.Pow(2, -i) : 0.0;
            return mantissaValue;
        }

        static string signed_to_supplement(char[] num_binary) {
			if (num_binary[0] == '1') {
				int i = num_binary.Length - 1;
				while (i > 1) { i -= 1; if (num_binary[i] == '0') break; } 
				for (;i > 0; i -= 1) num_binary[i] = num_binary[i] == '1' ? '0' : '1';
			}
			return new string(num_binary);
		}
	}
}

#pragma warning restore IDE1006 // Naming Styles