

abstract class CourseMember
{
    protected Mediator Mediator;
    public CourseMember(Mediator mediator)
    {
        Mediator = mediator;
    }
}

class Teacher : CourseMember
{
    public Teacher(Mediator mediator) : base(mediator)
    {

    }

    public void ReceiveQuestion(string question, Student student)
    {
        Console.WriteLine($"Teacher received a question from {student.Name}");
    }

    public void SendImage(string url)
    {
        Console.WriteLine($"Teacher sent an image {url}");
        Mediator.UpdateImage(url);
    }

    public void AnswerQuestion(string answer, Student student)
    {
        Console.WriteLine($"Teacher sent an answer to {student.Name}");
        Mediator.SendAnswer(answer, student);
    }

}

class Student : CourseMember
{
    public Student(Mediator mediator) : base(mediator)
    {

    }

    public string Name { get; set; }
    public void ReceiveImage(string url)
    {
        
    }

    public void ReceiveAnswer(string answer)
    {
        
    }

    
}

class Mediator
{
    public List<Student> Students { get; set; }
    public Teacher Teacher { get; set; }

    public void UpdateImage(string url)
    {
        foreach (var student in Students)
        {
            student.ReceiveImage(url);
        }
    }

    public void SendQuestion(string question, Student student)
    {
        Teacher.ReceiveQuestion(question, student);
    }

    public void SendAnswer(string answer, Student student)
    {
        student.ReceiveAnswer(answer);
    }

}