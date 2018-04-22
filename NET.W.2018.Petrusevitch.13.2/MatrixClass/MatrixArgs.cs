namespace MatrixClass
{
    using System;

    /// <summary>
    /// The info for event
    /// </summary>
    /// <typeparam name="T">generick type
    /// </typeparam>
    public class MatrixArgs<T> : EventArgs
    {
        public int PositionI { get; set; }

        public int PositionJ { get; set; }

        public T Value { get; set; }

        public MatrixArgs(int positionI, int positionJ, T value)
        {
            this.PositionI = positionI;
            this.PositionJ = positionJ;
            this.Value = value;
        }
    }
}