namespace Repository
{
    public enum BooksStringFormat
    {
        /// <summary>
        /// Name
        /// </summary>
        N,

        /// <summary>
        /// Name, Author
        /// </summary>
        NA,

        /// <summary>
        /// Name,Author,Years
        /// </summary>
        NAY,

        /// <summary>
        /// Name,Author,Years,List count
        /// </summary>
        NAYL,

        /// <summary>
        /// Name,Author,Years,List count,ISBN
        /// </summary>
        NAYLI,

        /// <summary>
        /// Name,Author,Years,List count,ISBN,Price
        /// </summary>
        NAYLIP
    }
}