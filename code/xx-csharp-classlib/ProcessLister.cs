using System.Diagnostics;

namespace SampleLibrary;


public class ProcessInfo
{
    public int ProcessId { get; set; }
    public string Name { get; set; }
    public string? Path { get; set; }
}

public static class ProcessLister
{
    public static List<ProcessInfo> ListProcesses()
    {
        List<ProcessInfo> processes = new();

        foreach (var proc in Process.GetProcesses())
        {
            string? path = null;

            try
            {
                // Accessing MainModule.FileName can throw on some platforms or system processes
                path = proc.MainModule?.FileName;
            }
            catch
            {
                // Just ignore and keep it null
            }

            processes.Add(new ProcessInfo
            {
                ProcessId = proc.Id,
                Name = proc.ProcessName,
                Path = path
            });
        }

        return processes;
    }
}