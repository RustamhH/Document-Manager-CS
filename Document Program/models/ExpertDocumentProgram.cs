using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Program
{
    internal class ExpertDocumentProgram:ProDocumentProgram
    {

        // Function
        public override void SaveDocument(Document document)
        {
            document.Extension = "pdf";
            CurrentUser.Save(document);
            Console.WriteLine("Saved as pdf");
        }

        // Default c-tor
        public ExpertDocumentProgram()
        {
            Price = 1000;
        }
        
    }
}
