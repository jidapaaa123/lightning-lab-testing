using LightningLab2.Abstractions;
using LightningLab2.Data;
using LightningLab2.Models;
using LightningLab2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite("Data Source=library.db"));

builder.Services.AddScoped<IUserService, DummyUserService>();
builder.Services.AddScoped<IBookService, DummyBookService>();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// GET /users
app.MapGet("/users", (IUserService userService) =>
{
    var users = userService.GetAllUsers();
    return Results.Ok(users);
})
.WithName("GetAllUsers");

// GET /users/{id}
app.MapGet("/users/{id}", (int id, IUserService userService) =>
{
    var user = userService.GetUser(id);
    if (user == null)
        return Results.NotFound($"User {id} not found");
    
    return Results.Ok(user);
})
.WithName("GetUser");

// GET /books
app.MapGet("/books", (IBookService bookService) =>
{
    var books = bookService.GetAllBooks();
    return Results.Ok(books);
})
.WithName("GetAllBooks");

// GET /books/{id}
app.MapGet("/books/{id}", (string id, IBookService bookService) =>
{
    var book = bookService.GetBook(id);
    if (book == null)
        return Results.NotFound($"Book {id} not found");
    
    return Results.Ok(book);
})
.WithName("GetBook");

// GET /checkouts
app.MapGet("/checkouts", (LibraryDbContext dbContext) =>
{
    var checkouts = dbContext.Checkouts.ToList();
    return Results.Ok(checkouts);
})
.WithName("GetAllCheckouts");

// POST /checkout
app.MapPost("/checkout", (CheckoutRequest request, IUserService userService, IBookService bookService) =>
{
    // Logic Gate 1: Check User
    var user = userService.GetUser(request.UserId);
    
    if (user == null)
        return Results.NotFound($"User {request.UserId} not found");
    
    if (user.Fines > 10)
        return Results.BadRequest($"User has outstanding fines of ${user.Fines:F2}, exceeding the $10.00 limit");
    
    if (user.IsBanned)
        return Results.Forbid();
    
    // Logic Gate 2: Check Book
    var book = bookService.GetBook(request.BookId);
    
    if (book == null)
        return Results.NotFound($"Book {request.BookId} not found");
    
    if (book.Status != BookStatus.Available)
        return Results.NotFound($"Book is {book.Status} and cannot be checked out");
    
    // Logic Gate 3: Success
    return Results.Ok($"Checkout approved for user {user.Name} to borrow {book.Title}");
})
.WithName("Checkout");

app.Run();

public class CheckoutRequest
{
    public int UserId { get; set; }
    public string BookId { get; set; } = string.Empty;
}
