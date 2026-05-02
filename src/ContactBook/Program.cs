namespace ContactBook;

public class Program
{
    public static void Main()
    {
        Contact c1 = new Contact();
        Contact c2 = new Contact("John");
        Contact c3 = new Contact("John", "Smith");
        Contact c4 = new Contact("John", "Smith", "123-456-7890");
        Contact c5 = new Contact("John", "Smith", "123-456-7890", "john.smith@example.com");
        Contact c6 = new Contact(lname: "Smith", email: "john.smith@example.com");
    }
}