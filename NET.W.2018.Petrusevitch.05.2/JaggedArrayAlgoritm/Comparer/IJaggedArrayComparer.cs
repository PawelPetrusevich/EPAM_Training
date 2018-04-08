namespace JaggedArrayAlgoritm.Comparer
{
    using System.Collections.Generic;
    public interface IJaggedArrayComparer : IComparer<int[]>
    {
        int Compare(int[] x, int[] y);

        int BySumDescending(int[] lhs, int[] rhs);

        int ByMinDescending(int[] lhs, int[] rhs);

        int ByMaxDescending(int[] lhs, int[] rhs);

        int BySumAscending(int[] lhs, int[] rhs);

        int ByMinAscending(int[] lhs, int[] rhs);

        int ByMaxAscending(int[] lhs, int[] rhs);
    }
}