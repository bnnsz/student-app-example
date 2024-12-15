using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using student_app.Model;
using student_app.Repository;
using student_app.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISessionFactory>(_ =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var cfg = Fluently.Configure()
        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)
            .Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>())
        .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(Student).Assembly)) 
        .BuildSessionFactory();

    return cfg;
});

builder.Services.AddScoped<NHibernate.ISession>(provider =>
{
    var sessionFactory = provider.GetRequiredService<ISessionFactory>();
    return sessionFactory.OpenSession();
});
builder.Services.AddScoped<IStudentRepository, NHibernameStudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();