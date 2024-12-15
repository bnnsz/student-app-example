using FluentNHibernate.Mapping;
using NHibernate.Mapping.Attributes;

namespace student_app.Model
{
    [Class(Table = "student")]
    public class Student
    {
        [Id]
        public virtual int? Id { get; set; }
        [Property]
        public virtual string? RegistrationNumber { get; set; }
        [Property]
        public virtual string FirstName { get; set; }
        [Property]
        public virtual string LastName { get; set; }
        [Property]
        public virtual string Email { get; set; }
        [Property]
        public virtual string PhoneNumber { get; set; }
        [Property]
        public virtual string Department { get; set; }
    }
    
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("student"); 
            Id(x => x.Id);
            Map(x => x.RegistrationNumber);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            Map(x => x.PhoneNumber);
            Map(x => x.Department);
        }
    }
}
