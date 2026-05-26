using Practical23.BAL.AbstractFactory.Interface;

namespace Practical23.BAL.AbstractFactory;

public class AbstractFactoryStore : IAbstractFactoryStore
{
    private readonly Dictionary<string, IAbstractFactory> _abstractFactories = [];

    public void Register(string deptName, IAbstractFactory abstractFactory)
    {
        _abstractFactories.Add(deptName.ToLower(), abstractFactory);
    }

    public IAbstractFactory GetAbstractFactory(string deptName)
    {
        if (!_abstractFactories.TryGetValue(deptName.ToLower(), out IAbstractFactory? abstractFactory))
        {
            throw new KeyNotFoundException($"Abstract factory not found for given department name: {deptName} central abstract factory store.");
        }
        return abstractFactory;
    }
}
