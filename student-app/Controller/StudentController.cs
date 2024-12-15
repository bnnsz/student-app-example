using Microsoft.AspNetCore.Mvc;
using student_app.Model;
using student_app.Services;

namespace student_app.Controller;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Student>> GetAsync()
    {
        return await _studentService.GetSAllStudentsAsync();
    }
    
    [HttpPost]
    public async Task<Student> PostAsync(Student student)
    {
        return await _studentService.RegisterStudentAsync(student);
    }
}