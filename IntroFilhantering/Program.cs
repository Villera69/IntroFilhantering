using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
MainMenu();
static void MainMenu(){
    while(true){
        Console.WriteLine("What do you wish to do?");
        Console.WriteLine("(1) Write text in the file");
        Console.WriteLine("(2) Print the file");
        Console.WriteLine("(3) Save a list of people in a document");
        switch(Console.ReadLine()){
            case "1":
                TextMenu();
                break;
            case"2":
                ReadMenu();
                break;
            case "3":
                PersonRegistryMenu();
                break;
            default:
                Console.Clear();
                Console.WriteLine("You need to type 1, 2 or 3 in the menu. Press enter to try again.");
                Console.ReadLine();
                Console.Clear();
                break;
        }
    }
}

static void TextMenu(){
    Console.Clear();
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("(1) Write text to the bottom of the file");
    Console.WriteLine("(2) Write text to replace everything in the file");
    switch(Console.ReadLine()){
        case "1":
            Append();
            break;
        case "2":
            ReplaceAllText();
            break;
        default:
            Console.Clear();
            Console.WriteLine("You need to type 1 or 2 in the menu. Press enter to try again.");
            TextMenu();
            break;
    }
}
static void ReadMenu(){
    while(true){
        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("(1) Print all of the text from the file.");
        Console.WriteLine("(2) Print a specific line from the file.");
            switch(Console.ReadLine()){
            case "1":
                PrintAllText();
                break;
            case "2":
                PrintALine();
                break;
            default:
                Console.Clear();
                Console.WriteLine("You need to type 1 or 2 in the menu. Press enter to try again.");
                Console.ReadLine();
                break;
        }
    }
}

static void Append(){
    Console.Clear();
    Console.Write("Write the text that you want to add: ");
    string textToAppend = Console.ReadLine();
    File.AppendAllText("words.txt", textToAppend);
    Console.WriteLine("Done! You will now go back to the main menu. Press enter to continue");
    Console.ReadLine();
    MainMenu();
}
static void ReplaceAllText(){
    Console.Clear();
    Console.Write("Write the text you want to overwrite the text with: ");
    string replaceTextWith = Console.ReadLine();
    File.WriteAllText("words.txt", replaceTextWith);
    Console.WriteLine("Done! You will now go back to the main menu. Press enter to continue");
    Console.ReadLine();
    MainMenu();
}
static void PrintAllText(){
    Console.Clear();
    string[] lines = File.ReadAllLines("words.txt");
    foreach(string line in lines){
        Console.WriteLine(line);
    }
    Console.WriteLine("Done! You will now go back to the main menu. Press enter to continue");
    Console.ReadLine();
    MainMenu();
}
static void PrintALine(){
    string[] lines = File.ReadAllLines("words.txt");
    int linechoice;
    while(true){
        try{
            Console.Clear();
            Console.WriteLine($"There are {lines.Length} lines in the text file.");
            Console.WriteLine("Type the number of the line you want to print: ");
            linechoice = int.Parse(Console.ReadLine());
            if(linechoice > lines.Length || linechoice < 0){
                Console.WriteLine("That number does not correspond to a line in the document. Please, press enter to try again.");
                Console.ReadLine();
                continue;
            }
            break;
        }
        catch
        {
            Console.WriteLine("That is not a valid number, you need to enter a number less or equal to the number of lines. Please, press enter to try again.");
            Console.ReadLine();
        }
    }

    Console.Clear();
    Console.WriteLine("Line " + linechoice + " out of " + lines.Length + "\n\n" + lines[linechoice-1] + "\n");

    Console.WriteLine("\nDone! You will now go back to the main menu. Press enter to continue");
    Console.ReadLine();
    Console.Clear();
    MainMenu();
}

static void PersonRegistryMenu(){
    Console.Clear();
    using (FileStream file = File.Open(@"PersonRegistry.txt", FileMode.OpenOrCreate)){
        Console.WriteLine("A registry for people has been created. Do you wish to add a person or go back to the main menu?");
        Console.WriteLine("(1) Enter a new person");
        Console.WriteLine("(2) Exit to main menu");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Clear();
                Console.Write("Type the first name of the person you want to add: ");
                string firstName = Console.ReadLine();
                if(!Regex.IsMatch(firstName, "^[a-zA-Z]*$")){
                    
                    Console.WriteLine("the name needs to only contain letters from the english alphabet, please press enter to try again.");
                    Console.ReadLine();

                }
                Console.Write("Type the last name of the person you want to add: ");
                string lastName = Console.ReadLine();
                if(Regex.IsMatch(lastName, "^[a-zA-Z0-9]*$"))
                {

                }
                break;
            case "2":
                break;
            default:
                Console.WriteLine("You need to type 1 or 2 in the menu. Press enter to try again");
                PersonRegistryMenu();
            break;
        }
    }
}