Address address = new() 
{ 
    City = "Moscow" 
};
Company company = new() 
{ 
    Title = "Yandex", 
    Address = address 
};
Employee bob = new()
{
    Name = "Bobby",
    Company = company,
};

Console.WriteLine(bob);
Console.WriteLine();

Employee tom = (Employee)bob.Clone();
tom.Name = "Tommy";
tom.Company?.Title = "PiterSoft";
tom.Company?.Address?.City = "St Petersburg";

Console.WriteLine(bob);
Console.WriteLine(tom);
Console.WriteLine();

Employee[] employees = new Employee[3]
{
    new(){ Name = "Sammy", Age = 28 },
    new(){ Name = "Bobby", Age = 37 },
    new(){ Name = "Penny", Age = 20 },
};

foreach(var e in employees)
    Console.WriteLine(e);
Console.WriteLine();

employees.Sort((e1, e2) => e1.Age.CompareTo(e2.Age));

foreach (var e in employees)
    Console.WriteLine(e);

class Address : ICloneable
{
    public string? City { get; set; }

    public object Clone()
        => new Address() { City = null };

    public override string ToString()
        => $"City: {City}";
}

class Company : ICloneable
{
    public string? Title { get; set; }
    public Address? Address { get; set; }

    public object Clone()
        => new Company()
        {
            Title = Title,
            Address = Address?.Clone() as Address
        };

    public override string ToString()
        => $"Title: {Title}, Address: {Address}";
}

class Employee : ICloneable, IComparable<Employee>
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public Company? Company { get; set; }

    public object Clone()
    {
        return new Employee()
        {
            Name = Name,
            Company = Company?.Clone() as Company,
        };
    }

    public int CompareTo(Employee? other)
        => this.Name.CompareTo(other.Name);

    public override string ToString()
        => $"Name: {Name}, Age: {Age}, Company: {Company}";
}

