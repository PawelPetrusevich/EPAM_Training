// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" ILogger.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: BookService
//  Project: Logger
//  Filename: ILogger.cs
//  Created day: 15.04.2018    14:02
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Logger
{
    using System;

    public interface ILogger
    {
        void Debug(string message);

        void Information(string message);

        void Error(Exception ex, string message);

        void Warning(string message);

        void Fatal(string message);

        void SaveLog();
    }
}