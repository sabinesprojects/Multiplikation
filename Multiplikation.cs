using System;

namespace Aufnahmepruefung
{
    /// <summary>
    /// Russischen Bauernmultiplikation in drei Varianten
    /// </summary>
    public class Multiplikation
    {
        public static void Main(string[] args)
        {
            int x, y;

            Console.WriteLine("Bitte geben Sie den ersten Faktor ein.");
            while (!int.TryParse(Console.ReadLine(), out x))
                Console.WriteLine("Bitte geben sie den ersten Faktor als natürliche Zahl ein.");

            Console.WriteLine("Bitte geben Sie den zweiten Faktor ein.");
            while (!int.TryParse(Console.ReadLine(), out y))
                Console.WriteLine("Bitte geben sie den zweiten Faktor als natürliche Zahl ein.");

            Console.WriteLine("{0} * {1} = {2}", x, y, Mul(x, y));
            Console.Read();
        }


        /// <summary>
        /// Dieser Algorithmus multipliziert zwei Zahlen anhand der Russischen Bauernmultiplikation
        /// Kurze und schnelle Variante
        /// </summary>
        /// <param name="x">Erster Faktor</param>
        /// <param name="y">Zweiter Faktor</param>
        /// <returns>Das Produkt aus x und y</returns>
        public static int Mul(int x, int y)
        {
            int r = 0;

            while (x > 0)
            {
                r += (x % 2 == 0) ? 0 : y;
                x >>= 1;
                y <<= 1;
            }

            return r;
        }


        /// <summary>
        /// Dieser Algorithmus multipliziert zwei Zahlen anhand der Russischen Bauernmultiplikation
        /// Leicht lesbare Variante
        /// Die Zahlen werden ggf. getauscht, um die Zahl der Schritte zu minimieren
        /// </summary>
        /// <param name="x">Erster Faktor</param>
        /// <param name="y">Zweiter Faktor</param>
        /// <returns>Das Produkt aus x und y</returns>
        public static int MulVerbatim(int x, int y)
        {
            int r = 0;

            if (x > y)
            {
                Swap(ref x, ref y);
            }

            while (x > 0)
            {
                Console.WriteLine("{0}   {1}   {2}", x, y, r);

                if (x % 2 == 0)
                {
                    x /= 2;
                    y *= 2;
                }
                else
                {
                    r += y;
                    x /= 2;
                    y *= 2;
                }

            }

            return r;
        }


        /// <summary>
        /// Zwei Zahlen werden ausgetauscht
        /// </summary>
        /// <param name="a">Erste Zahl</param>
        /// <param name="b">Zweite Zahl</param>
        /// <returns>void</returns>

        private static void Swap(ref int a, ref int b)
        {
            int z = a;
            a = b;
            b = z;
        }


        /// <summary>
        /// Dieser Algorithmus multipliziert zwei Zahlen anhand der Russischen Bauernmultiplikation
        /// Rekursive Variante (bringt keinen Vorteil; nur der Gaudi halber)
        /// </summary>
        /// <param name="x">Erster Faktor</param>
        /// <param name="y">Zweiter Faktor</param>
        /// <returns>Das Produkt aus x und y</returns>
        public static int MulRecursive(int x, int y)
        {
            return MulRec(x, y, 0).Item3;
        }


        /// <summary>
        /// Rekursionsbody von MulRecursive
        /// </summary>
        /// <param name="a">Erster Faktor</param>
        /// <param name="b">Zweiter Faktor</param>
        /// <param name="r">Restsumme</param>
        /// <returns></returns>
        private static (int, int, int) MulRec(int a, int b, int r)
        {
            if (a > 0)
            {
                if (a % 2 == 0)
                {
                    a /= 2;
                    b *= 2;
                }
                else
                {
                    r += b;
                    a /= 2;
                    b *= 2;
                }
            }
            else
            {
                return (0, 0, r);
            }

            return MulRec(a, b, r);
        }
    }
}
