namespace Parser
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FileParser
    {
        private readonly IXmlParser xmlParser;

        private readonly string filePath;

        public FileParser(IXmlParser xmlParser, string filePath)
        {
            this.xmlParser = xmlParser;
            this.filePath = filePath;
        }

        public void ReadTxtFile()
        {
            using (TextReader reader = new StreamReader(this.filePath))
            {
                string line;
                var uris = new List<UriLine>();
                while ((line = reader.ReadLine()) != null)
                {
                    uris.Add(this.ReadTxtLine(line));
                }

                this.xmlParser.AddLineToXml(uris);
            }
        }

        private UriLine ReadTxtLine(string line)
        {
            List<string> block = new List<string>();

            var uriInXml = new UriLine();

            foreach (var item in line.Split('/'))
            {
                if (item.Length > 0)
                {
                    block.Add(item);
                }
            }

            uriInXml.Scheme = block[0];
            uriInXml.Host = block[1];

            for (int i = 2; i < block.Count; i++)
            {
                if (!block[i].Contains("?"))
                {
                    uriInXml.UrlPaths.Add(block[i]);
                }
                else
                {
                    var temp = block[i].Split('?');
                    uriInXml.UrlPaths.Add(temp[0]);
                    if (temp[1].Length > 0)
                    {
                        var parametr = temp[1].Split('=');
                        uriInXml.ParametrKey = parametr[0];
                        uriInXml.ParametrValue = parametr[1];
                    }
                }
            }


            return uriInXml;
        }
    }
}
