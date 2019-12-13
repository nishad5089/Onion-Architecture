using System;
namespace Onion.Domain.Models
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string Name {get; private set; }
        public Student()
        {
            Id = Guid.NewGuid();
   
        }

        public void SetName(string name){
            Name = name;
        }
    }
}