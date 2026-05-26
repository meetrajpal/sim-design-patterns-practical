using Practical23.BAL.OvertimeCalcs.Interfaces;

namespace Practical23.BAL.OvertimeCalcs;

public class HROvertimePayCalc : IOvertimePayCalc
{
    public decimal CalculateOvertimePayment(decimal hours)
    {
        return hours * 100;
    }
}
