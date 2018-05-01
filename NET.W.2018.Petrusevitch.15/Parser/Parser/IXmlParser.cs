// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Parser" file=" IXmlParser.cs">
//  Creator name: 
//  Solution: Parser
//  Project: Parser    
// </copyright>
// <summary>
//  Filename: IXmlParser.cs
//  Created day: 01.05.2018    19:01
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Parser
{
    using System.Collections.Generic;

    public interface IXmlParser
    {
        bool AddLineToXml(List<UriLine> uriLine);
    }
}