using System;
namespace Matrix
{
    class Matrix
    {
        
        double[,] a;
   
        public Matrix(int rows, int cols)
        {
            a = new double[rows, cols];
        }
    
        public void InputMatrix()
        {
            Random r = new Random();
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = (double)r.Next(100);
        }
        
        public override string ToString()
        {
            string s = null;
            for (int i = 0; i < a.GetLength(0); i++, s += "\n")
                for (int j = 0; j < a.GetLength(1); j++)
                    s += a[i, j] + " ";
            return s;
        }
        
        public void OutputMatrix()
        {
            string s = this.ToString();
            Console.WriteLine(s);
        }
        
        static public Matrix operator ~(Matrix m)
        {
            Matrix newM = new Matrix(m.a.GetLength(1), m.a.GetLength(0));
            for (int i = 0; i < m.a.GetLength(0); i++)
                for (int j = 0; j < m.a.GetLength(1); j++)
                    newM.a[j, i] = m.a[i, j];
            return newM;
        }
       
        static public Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.a.GetLength(1) == m2.a.GetLength(0))
            {
                
                Matrix newM = new Matrix(m1.a.GetLength(0), m2.a.GetLength(1));

               
                for (int i = 0; i < m1.a.GetLength(0); i++)
                    for (int j = 0; j < m2.a.GetLength(1); j++)
                        for (int k = 0; k < m1.a.GetLength(1); k++)
                            newM.a[i, j] += m1.a[i, k] * m2.a[k, j];
                return newM;
            }
            else
            {
                
                throw new Exception("Матрицы таких размеров перемножать нельзя");
            }
        }
        
        static public Matrix operator *(Matrix m, double d)
        {
            
            Matrix newM = new Matrix(m.a.GetLength(0), m.a.GetLength(1));
      
            for (int i = 0; i < m.a.GetLength(0); i++)
                for (int j = 0; j < m.a.GetLength(1); j++)
                    newM.a[i, j] = m.a[i, j] * d;
            return newM;
        }
    
        static public Matrix operator *(double d, Matrix m)
        {
          
            Matrix newM = new Matrix(m.a.GetLength(0), m.a.GetLength(1));
           
            newM = m * d;
            return newM;
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix x, y, z;
            x = new Matrix(2, 3);
            y = new Matrix(3, 4);
            x.InputMatrix();
            y.InputMatrix();
            Console.WriteLine("Matrix X=");
            x.OutputMatrix();
            Console.WriteLine("Matrix Y=");
            y.OutputMatrix();
            z = ~x;
            Console.WriteLine("Matrix X transposed=");
            z.OutputMatrix();
            Console.WriteLine("Matrix X*5 =");
            z = x * 5.0; 
            z.OutputMatrix();
            Console.WriteLine("Matrix X*2.5 =");
            z = 2.5 * y; 
            z.OutputMatrix();

            try
            {
                z = x * y; 
                Console.WriteLine("X*Y =");
                z.OutputMatrix();
            }
            catch (Exception ex)
            {
     
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}