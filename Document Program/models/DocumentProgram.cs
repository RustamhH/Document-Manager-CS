using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Program
{
    internal class DocumentProgram
    {
        // Property
        public User CurrentUser { get; set; }

        // Functions
        public void OpenDocument(string id)
        {
            CurrentUser.Open(id);
        }

        public virtual void SaveDocument(Document document)
        {
            Console.WriteLine("Saving is only availible in our Pro and Expert packages");
        }
        public virtual Document EditDocument(string id)
        {
            Console.WriteLine("Editing is only availible in our Pro and Expert packages");
            return new Document();
        }


        // Default c-tor
        public DocumentProgram() { CurrentUser = new(); }
    }
}
