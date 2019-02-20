using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
namespace SP.Infrastructure
{
  public  class SqlMap
    {   
        public SqlMap(string sqlConnStr)
        {
            this.SqlConnStr =sqlConnStr;
            this.Initialize();
        }

        public string SqlConnStr { get; private set; }
        private  Stream XmlStream { get;  set; }
        public string GetSqlStatment(string name)
        {
            string sql = "";
            XDocument document = XDocument.Load(this.XmlStream);
            var elements = document.Document.Element("SqlStatements").Elements("SqlStatement");
            foreach(var item in elements)
            {
                var attr = item.Attribute("name");
                if (attr != null)
                {
                  sql=  attr.Value==name?item.Value:"";
                }
            }
            return sql;
        }
        public void Initialize()
        {
            var assembly = Assembly.GetAssembly(typeof(SqlMap));
            var space =assembly.GetName().Name + ".SplMap.xml";
            var stream =  assembly.GetManifestResourceStream(space);
            this.XmlStream = stream;
            //var embeddedProvider = new EmbeddedFileProvider(assembly);
            //var compositeProvider = new CompositeFileProvider(embeddedProvider);
            //var fileInfo = embeddedProvider.GetFileInfo("SqlMap.xml");
            //XmlStream = fileInfo.CreateReadStream();
           

        }

    }
}
