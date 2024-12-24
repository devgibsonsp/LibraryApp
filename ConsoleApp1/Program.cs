using Infrastructure.Data;

var factory = new AppDbContextFactory();
var context = factory.CreateDbContext(null);

Console.WriteLine("DbContext created successfully!");

