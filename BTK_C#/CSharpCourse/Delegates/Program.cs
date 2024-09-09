

CustomerManager customerManager = new CustomerManager();

MyDelegate myDelegate = customerManager.SendMessage;
MyDelegate2 myDelegate3 = customerManager.SendPrivateMessage;
MyDelegate3 myDelegate4 = customerManager.AddMethod; 

myDelegate4 += customerManager.CarpMethod; // Eğer delegateler return type sahipse son eklenen delegate çalıştırılır

myDelegate += customerManager.ShowAlert; // Aynı delegateye birden fazla işlem ataması yapabiliriz
myDelegate -= customerManager.SendMessage; // Aynı zamanda çıkarma işlemini de bu şekilde yapabiliriz.

myDelegate();

MyDelegate myDelegate2 = customerManager.ShowAlert;

myDelegate2();

myDelegate3("Ananı ariyorum :D");
Console.WriteLine(myDelegate4(2,4));
Console.ReadLine();

// aynı delegate türünden birden fazla delegate türetilebilir.
public delegate void MyDelegate();
public delegate void MyDelegate2(string text);
public delegate int MyDelegate3(int number1,int number2);

public class CustomerManager
{
    public void SendMessage()
    {
        Console.WriteLine("Hello!");
    }
    public void ShowAlert()
    {
        Console.WriteLine("Be Careful!");
    }

    public void SendPrivateMessage(string text)
    {
        Console.WriteLine( "Size yollanan mesaj : " + text); 

    }

    public int AddMethod(int number1, int number2)
    {
        int totalValue;
        return totalValue = number1 + number2;
    } 
    
    public int CarpMethod(int number1, int number2)
    {
        int totalValue;
        return totalValue = number1 * number2;
    }

}

