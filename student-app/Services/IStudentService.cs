using student_app.Model;

namespace student_app.Services;

public interface IStudentService
{
    public Task<IEnumerable<Student>> GetSAllStudentsAsync();

    public Task<Student> RegisterStudentAsync(Student student);
}