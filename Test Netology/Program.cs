using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Netology
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, -9 } };            
            double b;
            b = Det(a);
            Console.WriteLine(b);
        }

        //Метод возвращает детерминант матрицы путем разложения по строке, принимая квадратную матрицу как параметр
        static double Det(double[,] a)
        {
            double D = 0;
            //ищем размерность матрицы
            int NumCol = a.GetLength(0);  
            //вычисления простейшего детерминанта
            if (NumCol == 1)
            {
                return a[0, 0];
            }
            //применение рекурсивного алгоритма с циклом по номеру столбца
            else
            {
                for (int a0 = 0; a0 < NumCol; a0++)
                {
                    //собственно, рекурсивная формула
                    D += Math.Pow(-1, 1 + a0 + 1) * a[0, a0] * Det(Reduced(a, a0, NumCol));
                }
                return D;
            }            
        }
        

        //дополнительный метод для получения уменьшенной матрицы из начальной вырезанием первой строки и нужного столбца
        //получается присвоением элементов новой матрицы значений элементов исходной со сдвигом
        static double[,] Reduced(double[,] a, int CurrentCol, int NumCol)
        {
            double[,] NewMatrix = new double[NumCol - 1, NumCol - 1];
            int tempR = 0;
            int tempC = 0;
            for (int b0 = 0; b0 < NumCol-1; b0++)
            {
                if (b0 >= 0)
                {
                    tempR = 1;
                }
                else tempR = 0;
                for (int b1 = 0; b1 < NumCol - 1; b1 ++)
                {
                    if (b1 >= CurrentCol)
                    {
                        tempC = 1;
                    }
                    else tempC = 0;
                    NewMatrix[b0, b1] = a[b0 + tempR, b1 + tempC];
                    
                }                
            }
            return NewMatrix;
        }
    }
}
