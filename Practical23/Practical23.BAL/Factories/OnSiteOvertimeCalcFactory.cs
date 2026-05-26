using Practical23.BAL.Factories.Interfaces;
using Practical23.BAL.OvertimeCalcs;
using Practical23.BAL.OvertimeCalcs.Interfaces;

namespace Practical23.BAL.Factories;

public class OnSiteOvertimeCalcFactory : IOvertimePayCalcFactory
{
    public IOvertimePayCalc Create()
    {
        return new OnSiteOvertimePayCalc();
    }
}
