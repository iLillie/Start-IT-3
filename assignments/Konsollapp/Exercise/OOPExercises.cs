namespace Konsollapp.Exercise;

public class OOPExercises
{
    public static void Run()
    {
        var textPrinter = new TextPrinter("Lillie");
        textPrinter.PrintName();
        textPrinter.PrintText();

        var person = new Person("Lillie");
        person.PrintWelcomeMessage(person.Name);
        person.PrintWelcomeMessage();
    }
}

public class TextPrinter
{
    public TextPrinter(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public void PrintName()
    {
        Console.WriteLine(Name);
    }

    public void PrintText()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Runde nr {i}");
        }
    }
}

public class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Person(string name, int age, string address)
    {
        Name = name;
        Age = age;
        Address = address;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    
    public void PrintWelcomeMessage(string name = "Terje")
    {
        Console.WriteLine($"Hei {name} og velkommen!");
    }
}