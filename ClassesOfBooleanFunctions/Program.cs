using System;

namespace ClassesOfBooleanFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            bool P0, P1, S, L, M;

            string dn = "01010100";
            char[] f = dn.ToCharArray();

            if (f[0] == '0')
            {
                P0 = true;
            }
            else
            {
                P0 = false;

            }
            if (f[7] == '1')
            {
                P1 = true;
                
            }
            else
            {
                P1 = false;
                
            }
            int[] invf = new int[8];
            for (int i = 7, j = 0; i >= 0 && j <= 7; i--, j++)
            {
                invf[j] = f[i] == '1' ? 0 : 1;
            }

            int count = 0;

            for (int i = 0; invf[i] == f[i] && i<=8; i++)
            {
                count++;
            }
            if (count == 8)
            {
                S = true;
            }
            else S = false;

            L = BinaryTriangle(dn);
            
            if (f[0] <= f[1] && f[2] <= f[3] && f[4] <= f[5] && f[6] <= f[7]
                && f[0] <= f[2] && f[1] <= f[3] && f[1] <= f[5] && f[2] <= f[6] && f[4] <= f[6] && f[0] <= f[4] && f[3] <= f[7] && f[5] <= f[7])
            {
                M = true;
            }
            else M = false;
            Console.WriteLine("\nТаблица");
            Console.WriteLine("   P0 P1 S M L");
            Console.WriteLine("f  "+(P0 == true?"+  ": "-  ") + (P1 == true ? "+  " : "-  ") + (S == true ? "+ " : "- ") + (M == true ? "+ " : "- ") + (L == true ? "+ " : "- "));
            Console.ReadKey();

        }
        static bool BinaryTriangle(string dn)
        {
            char[] dnumber = dn.ToCharArray();
            int count = dnumber.Length;
            bool[] arrbool = new bool[40];
            for (int m = 0; m < dnumber.Length; m++)
            {
                
                arrbool[m] = dnumber[m] == '1' ? true : false;

            }
            string str = null;
            Console.WriteLine("Треугольник Паскаля");
            for (int t = 0; t < dnumber.Length; t++)
            {
                str += (arrbool[t] == true ? "1" : "0") + " ";

            }
            Console.WriteLine(str);
            str = null;
            for (int i = dnumber.Length; i > 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    arrbool[count] = arrbool[count - i] ^ arrbool[count - i + 1];
                    str += (arrbool[count] == true ? "1" : "0") + " ";
                    count++;
                }
                Console.WriteLine(str);
                str = null;
            }
            Console.WriteLine("Коэффициенты полинома Жегалкина:");
            int[] coef = new int[8];
            for (int n = 0, c = 0; n < arrbool.Length && c < dnumber.Length; n += dnumber.Length - c, c++)
            {
                coef[c] = arrbool[n] == true ? 1 : 0;
                Console.WriteLine(arrbool[n] == true ? "1" : "0");
            }
            if (coef[3] == 1 || coef[5] == 1 || coef[6] == 1 || coef[7] == 1)
            {
                return false;
            }
            else return true;
        }
    }
}
