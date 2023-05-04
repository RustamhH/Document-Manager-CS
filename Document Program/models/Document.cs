using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Document_Program
{
    internal sealed class Document:IEquatable<Document>,ICloneable
    {
        // Fields & Properties

        private string _extension;
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeEdited { get; set; }
    
        public string Extension { 
            get=>_extension;
            set
            {
                if (value == "pdf" || value == "doc") _extension = value;
                else throw new Exception("Invalid File Format");
            } 
        }


        // Constructors

        public Document() { 
            Id = Guid.NewGuid(); 
            TimeCreated = DateTime.Now;
        }

        
        public Document(string name,string content) : this() { 
            Name = name; 
            Content = content;
        }
        public Document(string name,string extension,string content) : this(name,content) { 
            Extension = extension;
        }



        public string Short()
        {
            return $"Document Id: {Id}\nDocument Name: {Name+"."+Extension}\n";
        }

        public override string ToString()
        {
            return $"Document Name: {Name+"."+Extension}\nTime Created: {TimeCreated}\nTime Edited: {TimeEdited}\nContent:\n{Content}\n";
        }

        

        public bool Equals(Document? other)
        {
            if(other==null)return false;
            return other.Id == Id;
        }

       

        public object Clone() => new Document(Name,Extension,Content);

    }
}
