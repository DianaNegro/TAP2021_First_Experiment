using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAP2021_First_Experiment
{
    public class SnailSolution
    { /*
       * ciclo sulle cornici da 0 a (N+1)/2
       * per ciascun giro k-esimo:
       * -disegno prima riga i=k e j da k a n-1-k
       * -disegno colonna destra j=n-1-k e i da k+1 a n-1-(k+1)
       * -disegno ultima riga i=n-1-k e j da n-1-k scende a k
       * -disegno colonna sinistra da n-1-(k-1) e scende fino a k+1 e j=k
       * */
        public static int[] Snail(int[][] array)
        { //TODO assumo che array sia una matrice quadrata e non vuota. In questo momento dovremmo fare tutti i controlli del caso, ma adesso possiamo lasciare stare 
            int matrixRank = array[0].Length; //N
            int[] result=new int[array.Length* array.Length];
            int index = 0;
            for (int k = 0; k < (matrixRank+1)/2; k++)
            {
                for (int j = k; j <= matrixRank-1-k; j++)
                    result[index++] = array[k][j];
                for (int i = k+1; i <= matrixRank - 1 - (k + 1); i++)
                    result[index++] = array[i][matrixRank - 1 - k];
                for (int j = matrixRank - 1 - k; j >= k; j--)
                    result[index++] = array[matrixRank - 1 - k][j];
                for (int i = matrixRank - 1 - (k + 1); i >= k + 1; i--)
                    result[index++] = array[i][k];
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[][] correct = new[] 
            { new[] { 0, 1, 2, 3 }, new[] { 10, 11, 12, 13 }, new[] { 20, 21, 22, 23 }, new[] { 30, 31, 32, 33 } };
            int[] a = SnailSolution.Snail(correct);
            foreach (var i in a)
            {
                Console.Write(i);
                Console.Write(", ");
            }
            Console.WriteLine();
            
        }
    }
}
