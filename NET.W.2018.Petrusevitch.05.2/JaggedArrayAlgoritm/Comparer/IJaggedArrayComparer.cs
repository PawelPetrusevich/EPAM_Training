namespace JaggedArrayAlgoritm.Comparer
{
    using System.Collections.Generic;

    /// <summary>
    /// The JaggedArrayComparer interface.
    /// </summary>
    public interface IJaggedArrayComparer
    {
        /// <summary>
        /// by summ element descending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
        int BySumDescending(int[] lhs, int[] rhs);

        /// <summary>
        /// by min element descending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
        int ByMinDescending(int[] lhs, int[] rhs);

        /// <summary>
        /// by max element descending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
        int ByMaxDescending(int[] lhs, int[] rhs);

        /// <summary>
        /// by summ element ascending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
        int BySumAscending(int[] lhs, int[] rhs);

        /// <summary>
        /// by min element ascending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
        int ByMinAscending(int[] lhs, int[] rhs);

        /// <summary>
        /// by max element ascending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
        int ByMaxAscending(int[] lhs, int[] rhs);
    }
}