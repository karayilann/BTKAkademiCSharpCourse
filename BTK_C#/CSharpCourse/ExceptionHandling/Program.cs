#region Try-Catch

//try
//{
//    string[] students = new string[2] { "Defne", "Efe" };

//    students[2] = "Berivan";

//    Console.WriteLine(students);

//}// Eğer almayı beklediğimiz bir hata varsa bu şekilde yazarak doğrudan hata mesajını yazdırabiliriz.
//catch (IndexOutOfRangeException e)
//{
//    Console.WriteLine(e.Message);

//}
//catch
//{
//    Console.WriteLine("Hata");
//    throw;
//} 
#endregion


using System.Runtime.CompilerServices;
using ExceptionHandling;

List<String> studentList = new List<string> { "Engin", "Mert", "Efe" };

try
{
    Find();
}
catch (RecordNotFoundException e)
{
    Console.WriteLine(e.Message);
    throw;
}

Console.ReadKey();

void Find()
{
    if (!studentList.Contains("Ahmet"))
    {
        throw new RecordNotFoundException("Record Not Found");
    }
    else
    {
        Console.WriteLine("Record Found");
    }
}


HandleException(() =>
{
    Find();
});


void HandleException(Action action)
{
    try
    {
        action?.Invoke();
    }
    catch(RecordNotFoundException e) { Console.WriteLine(e.Message); }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }

}




