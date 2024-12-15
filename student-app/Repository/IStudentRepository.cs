using student_app.Model;

namespace student_app.Repository;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetSAllStudentsAsync();
    
    public Task<long> CountAsync();

    public Task<Student> CreateStudentAsync(Student student);
}