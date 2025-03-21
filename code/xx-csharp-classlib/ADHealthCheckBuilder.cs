// We must define usings for dependencies, such as other libraries
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.InteropServices;

// Namespace again (File Scoped)
namespace SampleLibrary;

public class ADHealthCheckBuilder
{
    // Properties of the class defined
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Forest ADForest { get; set; }

    // Constructor (same name as class)
    public ADHealthCheckBuilder()
    {
        // Make sure we don't try run a Windows only API call on a non Windows platform
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException("Active Directory health checks are only supported on Windows.");
        }
        
        Id = Guid.NewGuid();
        ADForest = Forest.GetCurrentForest();
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = CreatedAt;
    }
}
