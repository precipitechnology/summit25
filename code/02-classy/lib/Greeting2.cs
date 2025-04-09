namespace Classy;

public class Greeting2 : IGreeting
{
    public string Salutation { get; set; } = "Hey";
    public string Audience { get; set; }

    public Greeting2()
    {
    }
    public Greeting2(string aud)
    {
        Audience = aud;
    }
    
    public Greeting2(string sal, string aud)
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