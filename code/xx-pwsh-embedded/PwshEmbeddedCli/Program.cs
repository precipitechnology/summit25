using System.Management.Automation;
using System.Management.Automation.Runspaces;

using (var runspace = RunspaceFactory.CreateRunspace())
{
    runspace.Open();
    using var ps = PowerShell.Create();
    
    ps.Runspace = runspace;
    ps.AddScript("Get-Process | Select Name,Id | ConvertTo-Json");

    var results = ps.Invoke();

    if (results.Count > 0)
    {
        Console.WriteLine(results[0].ToString());
    }
    else if (ps.HadErrors)
    {
        foreach (var error in ps.Streams.Error)
        {
            Console.WriteLine($"PowerShell Error: {error}");
        }
    }
}