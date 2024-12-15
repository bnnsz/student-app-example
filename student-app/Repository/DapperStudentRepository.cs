using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;
using student_app.Model;

namespace student_app.Repository;



public class DapperStudentRepository: IStudentRepository
{
    private readonly string _connectionString;
    private readonly ILogger<DapperStudentRepository> _logger;
    
    public DapperStudentRepository(IConfiguration configuration, ILogger<DapperStudentRepository> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
    }
    
    
    public async Task<IEnumerable<Student>> GetSAllStudentsAsync()
    {
        _logger.LogInformation("Getting all students with connection string: {0}", _connectionString);
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Student>("SELECT * FROM student");
    }

    public async Task<long> CountAsync()
    {
        _logger.LogInformation("Counting all students with connection string: {0}", _connectionString);
        using var connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<long>("SELECT CAST(COUNT(*) AS BIGINT) FROM student");
    }

    //create a new student
    public async Task<Student> CreateStudentAsync(Student student)
    {
        _logger.LogInformation("Creating a new student with connection string: {0}", _connectionString);
        using var connection = new SqlConnection(_connectionString);

        _logger.LogInformation("Creating a new student with data {0}", student);
        var sql =
            """
             INSERT INTO student (registrationNumber, firstName, lastName, email, phoneNumber, department) 
             VALUES (@RegistrationNumber, @FirstName, @LastName, @Email, @PhoneNumber, @Department);
            """;

        await connection.ExecuteAsync(sql, student);

        sql = "SELECT * FROM student WHERE Id = (SELECT SCOPE_IDENTITY())";

        return await connection.QueryFirstOrDefaultAsync<Student>(sql);
    }

}