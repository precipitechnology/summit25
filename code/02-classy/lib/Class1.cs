namespace Classy;

public class Greeting
{
    public string Salutation {get; set;} = "Hello";
    public string Audience {get; set;}


    public Greeting()
    {
    }

    public Greeting(string aud)
    {
        Audience = aud;
    }
    
    public Greeting(string sal, string aud)
    {
        Salutation = sal;
        Audience = aud;
    }

    public string Greet()
    {
        if (!string.IsNullOrWhiteSpace(this.Audience))
        {
            return string.Format("{0}, {1}", this.Salutation, this.Audience);
        }
        return this.Salutation;
    }
}
