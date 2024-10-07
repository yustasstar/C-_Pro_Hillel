namespace HW_4._Operator_overload
{
    public class Matrix
    {
        private readonly int[,] _matrix;

        public int Rows { get; }
        public int Columns { get; }

        public int this[int row, int col]
        {
            get => _matrix[row, col];
            set => _matrix[row, col] = value; 
        }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _matrix = new int[rows, columns];
        }


        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new ArgumentException("Matrices must be of the same size for addition");

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new ArgumentException("Matrices must be of the same size for subtraction");

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new ArgumentException("Number of columns in first matrix must match number of rows in second matrix");

            Matrix result = new Matrix(m1.Rows, m2.Columns);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    for (int k = 0; k < m1.Columns; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m, int scalar)
        {
            Matrix result = new Matrix(m.Rows, m.Columns);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    result[i, j] = m[i, j] * scalar;
                }
            }
            return result;
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                return false;

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return false;
                }
            }
            return true;
        }

        public static bool operator !=(Matrix m1, Matrix m2) => !(m1 == m2);
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Matrix))
                return false;

            Matrix other = (Matrix)obj;
            return this == other;
        }

        public override int GetHashCode() => HashCode.Combine(_matrix);
    }
}
