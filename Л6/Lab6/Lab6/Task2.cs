namespace Lab6;
public class Task2
{
    private List<Student> _students { get; set; }
    public Task2()
    {
        _students = new List<Student>();
    }

    public void Add(Student student)
    {
        _students.Add(student);
    }

    public void Add(string name, string lastName, string group)
        => Add(new Student(Guid.NewGuid(), name, lastName, group));

    public void Delete(Student student)
        => _students.Remove(student);

    public List<Student> Sort(SortProperty sortProperty, bool descending = false)
    {
        Func<Student, string> sortPredicate = sortProperty switch
        {
            SortProperty.Name => x => x.Name,
            SortProperty.LastName => x => x.LastName,
            SortProperty.Group => x => x.Group,
            _ => throw new ArgumentException()
        };
        
        var ordered =  !descending ? _students.OrderBy(sortPredicate).ToList() :
            _students.OrderByDescending(sortPredicate).ToList();

        return ordered;
    }

    public List<Student> GetAll() => _students;

    public List<Student> Find(Func<Student, bool> predicate)
        =>_students.Where(predicate).ToList();


    public void Clear() => _students.Clear();
}

public record class Student(Guid id, string Name, string LastName, string Group)
{
    public override string ToString()
    {
        return $"{LastName} {Name} {Group}";
    }
}
public enum SortProperty
{
    Name,
    LastName,
    Group
}
