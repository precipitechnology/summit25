using SampleLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/localproc", () =>
{
    var proccesses = SampleLibrary.ProcessLister.ListProcesses();
    var envelope = new Envelope<ProcessInfo>()
    {
        Id = Guid.NewGuid(),
        Data = proccesses
    };
    return Results.Ok(envelope);

})
.WithName("GetLocalProcesses");

app.MapGet("/pagedproc", (int page = 1, int pageSize = 10) =>
    {
        var allProcesses = SampleLibrary.ProcessLister.ListProcesses();

        var totalCount = allProcesses.Count;
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var pagedProcesses = allProcesses
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var envelope = new PagedEnvelope<ProcessInfo>
        {
            Id = Guid.NewGuid(),
            Data = pagedProcesses,
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = totalPages
        };

        return Results.Ok(envelope);
    })
    .WithName("GetPagedProcesses");

app.Run();

public class Envelope<T>
{
    public Guid Id { get; set; }
    public List<T> Data { get; set; }
}

public class PagedEnvelope<T>
{
    public Guid Id { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public List<T> Data { get; set; } = new();
}
