
DoFly(new Duck());
DoFly(new Planet());
DoFly(new Airplane());

IFlyable[] flyables = new IFlyable[4];
flyables[0] = new Duck();
flyables[1] = new Planet();
flyables[2] = new Airplane();
flyables[3] = new Disk();

foreach (var flyable in flyables)
    flyable.Fly();

void DoFly(IFlyable flable)
{
    flable.Fly();
}

interface IFlyable
{
    void Fly() => Console.WriteLine("Any flying");
}

class Airplane : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Arplane flying");
    }
}

class Duck : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Duck flying");
    }
}

class Planet : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Planet flying");
    }
}

class Disk : IFlyable
{

}