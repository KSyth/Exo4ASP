namespace Exo4;

public class FakeDbMonkey
{
    private List<Monkey> _monkeys;
    private int _lastIndex = 0;

    public FakeDbMonkey()
    {
        _monkeys = new List<Monkey>()
        {
            new Monkey() { Id = ++_lastIndex, Name = "Babouche", Age = 5},
            new Monkey() { Id = ++_lastIndex, Name = "KingKong", Age = 100}
        };
    }
    
    public List<Monkey> GetAll()
    {
        return _monkeys;
    }

    public Monkey? GetById(int id)
    {
        return _monkeys.FirstOrDefault(c => c.Id == id);
    }
    
    

    public bool Add(Monkey monkey)
    {
        monkey.Id = ++_lastIndex;
        _monkeys.Add(monkey);
        return true; // l'ajout s'est bien passé
    }

    public bool Edit(Monkey monkey)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        var monkey = GetById(id);
        if (monkey == null)
            return false;
        _monkeys.Remove(monkey);
        return true;
    }
}