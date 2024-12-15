using student_app.Model;
using student_app.Repository;

namespace student_app.Services;

public class StudentService: IStudentService
{
    private readonly IStudentRepository _studentRepository;
    
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<IEnumerable<Student>> GetSAllStudentsAsync()
    {
        return await _studentRepository.GetSAllStudentsAsync();
    }
    
    public async Task<Student> RegisterStudentAsync(Student student)
    {
        var count = await _studentRepository.CountAsync();
        var now = DateTime.Now;
        var registrationNumber = $"{now.Year}{count + 1L}";
        student.RegistrationNumber = registrationNumber;
        return await _studentRepository.CreateStudentAsync(student);
    }
}