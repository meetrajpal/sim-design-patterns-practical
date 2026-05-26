using Practical23.BAL.AbstractFactory.Interface;
using Practical23.BAL.Factories.Interfaces;

namespace Practical23.BAL.AbstractFactory;

public class OutdoorAbstractFactory : IAbstractFactory
{
    private readonly Dictionary<string, IOvertimePayCalcFactory> _factories = [];

    public void Register(string deptName, IOvertimePayCalcFactory factory)
    {
        _factories.Add(deptName.ToLower(), factory);
    }

    public IOvertimePayCalcFactory GetFactory(string deptName)
    {
        if (!_factories.TryGetValue(deptName.ToLower(), out IOvertimePayCalcFactory? factory))
        {
            throw new KeyNotFoundException($"Factory not found for given department name: {deptName} from abstract factory.");
        }
        return factory;
    }
}
