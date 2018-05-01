// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Parser" file=" UriLine.cs">
//  Creator name: 
//  Solution: Parser
//  Project: Parser    
// </copyright>
// <summary>
//  Filename: UriLine.cs
//  Created day: 01.05.2018    18:45
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Parser
{
    using System.Collections.Generic;

    public class UriLine
    {
        public string Host { get; set; }

        public string Scheme { get; set; }

        public List<string> UrlPaths { get; set; } = new List<string>();

        public string ParametrKey { get; set; }

        public string ParametrValue { get; set; }
    }
}