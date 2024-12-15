using NHibernate.Linq;
using student_app.Model;

namespace student_app.Repository;

public class NHibernameStudentRepository: IStudentRepository
{
    private readonly NHibernate.ISession _session;
    
    public NHibernameStudentRepository(NHibernate.ISession session)
    {
        _session = session;
    }
    
    public async Task<IEnumerable<Student>> GetSAllStudentsAsync()
    {
       return await _session.Query<Student>().ToListAsync();
    }

    public Task<long> CountAsync()
    {
        return _session.Query<Student>().LongCountAsync();
    }

    public Task<Student> CreateStudentAsync(Student student)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(student);
            transaction.Commit();
        }
        
        return Task.FromResult(student);
    }
}