using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;


var connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=310796Winning!;Trusted_Connection=False; TrustServerCertificate=True;";
var connection = new SqlConnection(connectionString);


connection.Open();
//CreateUser(connection);
//ReadUsers(connection);
//ReadRoles(connection);
ReadUsersWithRoles(connection);
connection.Close();



static void ReadUsers(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var items = repository.Get();

    foreach (var item in items)
        Console.WriteLine(item.Name);
}

static void ReadRoles(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var items = repository.Get();

    foreach (var item in items) 
        Console.WriteLine(item.Name);
}

static void CreateUser(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var user = new User()
    {
        Id = 0,
        Name = "Rafael Ehlert",
        Email = "ra.faehlert@gmail.com",
        Slug = "rafael-ehlert",
        Bio = "C# Backend developer",
        PasswordHash = "Hash",
        Image = "https://..."
    };
    repository.Create(user);
}
static void ReadUsersWithRoles(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var items = repository.Get();

    foreach (var item in items)
    {
        Console.WriteLine(item.Name);
        foreach (var role in item.Roles)
        {
            Console.WriteLine($" - {role.Name}");
        }    
    }
}