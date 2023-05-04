using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Program
{
    internal sealed class User
    {
        // Fields
        private double _budget;
        private string _username;
        private string _email;


        // Properties
        public List<Document> Documents { get; set; }

        public string Username {
            get => _username;
            set
            {
                if (value.Length < 3) throw new Exception("Invalid Username");
                _username = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (!value.EndsWith("@gmail.com")) throw new Exception("Invalid E-Mail");
                _email = value;
            }
        }

        public double Budget
        {
            get => _budget;
            set
            {
                if (value < 0) throw new Exception("Insufficient Budget");
                _budget = value;
            }
        }


        // Constructors

        public User() { Documents = new(); }

        public User(string username, string email, double budget) : this()
        {
            Username = username;
            Email = email;
            Budget = budget;
        }






        // Functions

        public void Open(string id)
        {
            Console.Clear();
            try
            {
                Document document = SearchById(id);
                Console.WriteLine(document);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Create(Document document)
        {
            if (!Documents.Contains(document))
            {
                if (document != null) Documents.Add(document);
                return;
            }
            throw new Exception("Document Already Exist");
        }


        public Document Edit(string id)
        {
            Document document = SearchById(id) as Document;
            Console.Clear();
            Console.WriteLine(document);
            Console.Write("Enter edited content: ");
            string newtext = Console.ReadLine();
            if (newtext != null) document.Content = newtext;
            document.TimeEdited = DateTime.Now;
            return document;
        }

        public void Save(Document document)
        {
            try
            {
                Document d = SearchById(document.Id.ToString());
                d = document;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }





        public Document SearchById(string Id)
        {
            foreach (var item in Documents)
            {
                if (item.Id.ToString() == Id) return item;
            }
            throw new Exception("Document Not Found");
        }



        public void ShowDocument(Document ds) {
            Console.WriteLine(ds.Short());
        
        }






    }
}
