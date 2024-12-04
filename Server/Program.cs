var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:3000");



builder.Services.AddOpenApi();

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



var items = new List<Item>();


app.MapPost("/shop", (Item item) =>
{
    if (item == null)
    {
        return Results.BadRequest("Item data is invalid");
    }
    Console.WriteLine(item.ToString());

  
    items.Add(item);
    return Results.Ok(new { message = "Item added successfully" });
});
app.MapGet("/shop", () =>
{
    
    return Results.Ok(items);
});
 

app.Run();

public class Item
{
    public string Name { get; set; }
    public int Quality { get; set; }
    public decimal Price { get; set; }
    public override string ToString()
    {
        return $"Name:{Name}, Quality:{Quality},Price:{Price}";
    }
}

