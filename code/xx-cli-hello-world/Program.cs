using SampleLibrary;

var Processes = ProcessLister.ListProcesses();

foreach (var process in Processes)
{
    Console.WriteLine("Process: {0} - PID: {1} - PATH: {2}", process.Name, process.ProcessId, process.Path);
}

