using System.ComponentModel.DataAnnotations.Schema;

namespace human.models;
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime? DOB { get; set; }
      
    
}
