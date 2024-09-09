

CustomerManager customerManager = new CustomerManager();
customerManager.MessageSenderBaseType = new EmailMessageSenderBase();
customerManager.UpdateCustomer();

Console.WriteLine("\n");

CustomerManager customerManager2 = new CustomerManager();
customerManager2.MessageSenderBaseType = new SmsMessageSenderBase();
customerManager2.UpdateCustomer();

abstract class MessageSenderBase
{
    public void Save()
    {
        Console.WriteLine("Message saved");
    }

    public abstract void Send(Body body);

}

class Body
{
    public string Title { get; set; }
    public string Content { get; set; }
}



class EmailMessageSenderBase : MessageSenderBase
{
    public override void Send(Body body)
    {
        Console.WriteLine($"Subject: {body.Title} Context: {body.Content}. \n This message sended by SMSSender.");
    }
}

class SmsMessageSenderBase : MessageSenderBase
{
    public override void Send(Body body)
    {
        Console.WriteLine($"Subject: {body.Title} Context: {body.Content}. \n This message sended by SMSSender.");
    }
}

class CustomerManager
{
    public MessageSenderBase MessageSenderBaseType { get; set; }
    public void UpdateCustomer()
    {
        MessageSenderBaseType.Send(new Body { Title = "Customer Updated", Content = "Customer data has been updated" });
        Console.WriteLine("Customer updated");
    }
}
