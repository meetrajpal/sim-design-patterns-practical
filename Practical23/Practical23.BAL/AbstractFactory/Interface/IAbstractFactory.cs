using Practical23.BAL.Factories.Interfaces;

namespace Practical23.BAL.AbstractFactory.Interface;

public interface IAbstractFactory
{
    void Register(string deptName, IOvertimePayCalcFactory factory);
    IOvertimePayCalcFactory GetFactory(string deptName);
}
