// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" Log.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: BookService
//  Project: Logger
//  Filename: Log.cs
//  Created day: 15.04.2018    14:22
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Logger
{
    public class Log
    {
        private static  ILogger logger;

        static Log()
        {
            logger = new DefaultLogger();
        }
        public static ILogger Logger => logger;
    }
}