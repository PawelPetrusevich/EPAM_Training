// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Parser" file=" XmlParser.cs">
//  Creator name: 
//  Solution: Parser
//  Project: Parser    
// </copyright>
// <summary>
//  Filename: XmlParser.cs
//  Created day: 01.05.2018    19:01
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Parser
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;

    using Parser.Common.Interfaces;
    using Parser.Common.Model;

    public class XmlParser : IXmlParser
    {
        private readonly string path;

        public XmlParser(string path)
        {
            this.path = path;
        }

        public bool AddLineToXml(List<UriLine> uriLine)
        {
            if (!File.Exists(this.path))
            {
                XDocument xDco = new XDocument();

                XElement uris = new XElement("urlAdresess");

                foreach (var item in uriLine)
                {
                    XElement uriSegments = new XElement("uri");

                    foreach (var itemUrlPath in item.UrlPaths)
                    {
                        uriSegments.Add(new XElement("segment", itemUrlPath));
                    }

                    XElement root = new XElement(
                        "urlAdress",
                        new XElement("host", new XAttribute("name", item.Host)),
                        uriSegments);

                    if (item.ParametrValue != null || item.ParametrKey != null)
                    {
                        root.Add(new XElement(
                            "parametrs",
                            new XElement(
                                "Parametr",
                                new XAttribute("value", item.ParametrValue),
                                new XAttribute("key", item.ParametrKey))));
                    }

                    uris.Add(root);
                }

                xDco.Add(uris);
                xDco.Save(this.path);
            }

            return true;
        }
    }
}