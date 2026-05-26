namespace Practical23.BAL.AbstractFactory.Interface;

public interface IAbstractFactoryStore
{
    void Register(string deptName, IAbstractFactory abstractFactory);

    IAbstractFactory GetAbstractFactory(string deptName);
}
