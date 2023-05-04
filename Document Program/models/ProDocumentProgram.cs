using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Program
{
    internal class ProDocumentProgram:DocumentProgram
    {
        // Property
        public double Price { get; set; }

        // Functions
        public sealed override Document EditDocument(string id)
        {
            Document document=new();
            try { document=CurrentUser.Edit(id); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return document;
        }
        public override void SaveDocument(Document document)
        {
            document.Extension = "doc";
            CurrentUser.Save(document);
            Console.WriteLine("Saved as Doc , buy Expert package if you want pdf");
        }



        // Default Constructor
        public ProDocumentProgram()
        {
            Price = 500;
        }
    }
}
