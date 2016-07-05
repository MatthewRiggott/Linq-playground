using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Xml.Linq;

namespace GroupingOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Document> documents = new List<Document>();
            documents = Generator.DocumentList(50);
            PrintDocs(documents);

            IEnumerable<Document> query = 
                from Document doc in documents
                where doc.Day > 20
                select doc;

            PrintDocs(query);
            Console.Read();                        
        }
        private static void PrintDocs(List<Document> documents)
        {
            var i = 0;
            foreach (Document doc in documents)
            {
                i++;
                System.Console.Write("Doc #{0} ",i);
                System.Console.Write("Date: {0} ", doc.Day);
                System.Console.Write("Title: {0} ", doc.Title);
                System.Console.Write("Extension: {0}", doc.Extension);
                System.Console.Write("\n");
            }
        }

        private static void PrintDocs(IEnumerable<Document> query)
        {
            {
                var i = 0;
                foreach (Document doc in query)
                {
                    i++;
                    System.Console.Write("Doc #{0} ", i);
                    System.Console.Write("Date: {0} ", doc.Day);
                    System.Console.Write("Title: {0} ", doc.Title);
                    System.Console.Write("Extension: {0}", doc.Extension);
                    System.Console.Write("\n");
                }
            }
        }
    }

    public class Document
    {
        public int Day { get; set; }
        public string Extension { get; set; }
        public string Title { get; set; }
        
        public Document(int day, string extension, string title)
        {
            this.Day = day;
            this.Extension = extension;
            this.Title = title;
        }

    }
    public static class Generator
    {
        private static Random r = new Random();
        private static string[] titles = new string[]
        {
            "Crazy Snowman",
            "JabbaWocky",
            "Tomato Attack",
            "Slammin Salmon",
            "Attack on the Tithes",
            "Banana Rampage",
            "Ramens Revenge",
            "Icecream is Fucking Good",
            "Crazy Snowflakes",
            "JabbaWooky"
        };
        public static List<Document> DocumentList(int amount)
        {
            List<Document> doclist = new List<Document>();
            for (int i = 0; i < amount; i++)
            {
                Document doc = new Document(Randomint(1,31), Randomext(), Randomtitle());
                doclist.Add(doc);
            }
            return doclist;

        }

        private static int Randomint(int min,int max)
        {
            return r.Next(min, max);
        }

        private static string Randomext()
        {
            string[] extensions= new string[] {".jpg", ".html", ".scss", ".rb", ".net"};
            return extensions[r.Next(0, extensions.Length)];
        }

        private static string Randomtitle()
        {
            return titles[r.Next(0, titles.Length)];
        }
        
    }

}
    