namespace Document_Program
{
    internal partial class Program
    {
        static public partial int Print(List<string> arr); // my print




        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t\tDOCUMENT MANAGER\n");
            Console.Write("Enter Your Username: ");
            string? name = Console.ReadLine();
            Console.Write("Enter Your E-mail: ");
            string? email=Console.ReadLine();
            Console.Write("Enter Your Budget: ");
            double.TryParse(Console.ReadLine(), out double budget);
            User user = new(name, email, budget);

            List<string> choices = new() { "Basic", "Pro", "Expert" ,"Exit"};
            List<string> choices2 = new() { "Open", "Edit", "Exit" };

            

            int documentchoice = 0;
            while (choices[documentchoice]!="Exit")
            {
                Console.Title=$"Budget: {user.Budget}";
                Document document1 = new("Hesen", "Hesen Ehsen");
                Document document2 = new("Rustem", "Rustem Hesenli");
                DocumentProgram currentdocumentProgram;
                documentchoice = Print(choices);
                if(documentchoice==0)
                {
                    currentdocumentProgram = new DocumentProgram();
                    currentdocumentProgram.CurrentUser = user;
                    currentdocumentProgram.CurrentUser.Create(document1);
                    currentdocumentProgram.CurrentUser.Create(document2);
                    int basic=0;
                    while (choices2[basic]!="Exit")
                    {
                        basic = Print(choices2);
                        if(basic==0)
                        {
                            currentdocumentProgram.CurrentUser.Documents.ForEach(new Action<Document>(currentdocumentProgram.CurrentUser.ShowDocument));
                            Console.Write("Enter id; ");
                            currentdocumentProgram.OpenDocument(Console.ReadLine());
                            
                            Console.ReadKey(true);
                        }
                        else if(basic==1)
                        {
                            Document edited = currentdocumentProgram.EditDocument(document1.Id.ToString());
                            Console.ReadKey(true);
                            Console.Write("Enter S to save document: ");
                            var key = Console.ReadKey(true);
                            if(key.Key==ConsoleKey.S)
                            {
                                currentdocumentProgram.SaveDocument(edited);
                            }
                        }
                        
                        
                    }
                }
                else if(documentchoice==1)
                {
                    currentdocumentProgram = new ProDocumentProgram();
                    ProDocumentProgram pdp = currentdocumentProgram as ProDocumentProgram;
                    currentdocumentProgram.CurrentUser = user;
                    try {
                        currentdocumentProgram.CurrentUser.Budget -= pdp.Price;
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey(true);
                        continue;
                    }
                    document1.Extension = "doc";
                    document2.Extension = "doc";
                    currentdocumentProgram.CurrentUser.Create(document1);
                    currentdocumentProgram.CurrentUser.Create(document2);
                    
                    int pro = 0;
                    while (choices2[pro]!="Exit")
                    {
                        pro = Print(choices2);
                        if (pro==0)
                        {
                            currentdocumentProgram.CurrentUser.Documents.ForEach(new Action<Document>(currentdocumentProgram.CurrentUser.ShowDocument));
                            Console.Write("Enter id; ");
                            currentdocumentProgram.OpenDocument(Console.ReadLine());

                            Console.ReadKey(true);
                        }
                        else if(pro==1)
                        {
                            currentdocumentProgram.CurrentUser.Documents.ForEach(new Action<Document>(currentdocumentProgram.CurrentUser.ShowDocument));
                            Console.Write("Enter id; ");
                            Document edited = currentdocumentProgram.EditDocument(Console.ReadLine());
                            Console.Write("Enter S to save document: ");
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.S)
                            {
                                currentdocumentProgram.SaveDocument(edited);
                                Console.ReadKey(true);
                            }
                        }
                    }
                }
                else if(documentchoice==2)
                {
                    currentdocumentProgram = new ExpertDocumentProgram();
                    ExpertDocumentProgram edp = currentdocumentProgram as ExpertDocumentProgram;
                    currentdocumentProgram.CurrentUser = user;
                    try { currentdocumentProgram.CurrentUser.Budget -= edp.Price; }
                    catch (Exception ex) { 
                        Console.WriteLine(ex.Message);
                        Console.ReadKey(true);
                        continue; 
                    }
                    currentdocumentProgram.CurrentUser.Create(document1);
                    currentdocumentProgram.CurrentUser.Create(document2);
                    int expert = 0;
                    while (choices2[expert] !="Exit")
                    {
                        expert = Print(choices2);
                        if (expert == 0)
                        {
                            currentdocumentProgram.CurrentUser.Documents.ForEach(new Action<Document>(currentdocumentProgram.CurrentUser.ShowDocument));
                            Console.Write("Enter id; ");
                            currentdocumentProgram.OpenDocument(Console.ReadLine());
                            Console.ReadKey(true);
                        }
                        else if (expert == 1)
                        {
                            currentdocumentProgram.CurrentUser.Documents.ForEach(new Action<Document>(currentdocumentProgram.CurrentUser.ShowDocument));
                            Console.Write("Enter id; ");
                            Document edited = currentdocumentProgram.EditDocument(Console.ReadLine());
                            Console.Write("Enter S to save document: ");
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.S)
                            {
                                currentdocumentProgram.SaveDocument(edited);
                                Console.ReadKey(true);
                            }
                        }
                    }
                }
            }             
        }
        static public partial int Print(List<string> arr)
        {
            int index = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (i == index) Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(50, i + 10);
                    Console.WriteLine(arr[i]);
                }
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (index == 0) index = arr.Count - 1;
                    else index--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (index == arr.Count - 1) index = 0;
                    else index++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return index;
                }
            }
        }
    }

}