using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void Parser()
        {
            string filePath =
                @"C:\Users\Администратор\Documents\EPAM_Training\NET.W.2018.Petrusevitch.15\Parser\Parser\UriFile.txt";
            string xmlPath =
                @"C:\Users\Администратор\Documents\EPAM_Training\NET.W.2018.Petrusevitch.15\Parser\Parser\Uri.xml";
            FileParser fileParser = new FileParser(new XmlParser(xmlPath), filePath);
            fileParser.ReadTxtFile();
            Assert.IsTrue(true);
        }
    }
}
