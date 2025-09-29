using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ism_core
{
    public static class Config
    {
        public static readonly char CsvSeparator =';';
        public static readonly string UserFile = "users.csv";
        public static readonly string CsvFolder = Path.Combine(GetSolutionRoot(),"data");
        public static readonly string UserFilePath = Path.Combine(CsvFolder, UserFile);
        public static string GetSolutionRoot()
        {
            string dir=AppDomain.CurrentDomain.BaseDirectory;
            string solutionRoot = Directory.GetParent(dir).Parent.Parent.Parent.Parent.FullName;
            return solutionRoot;
        }
    }
}
