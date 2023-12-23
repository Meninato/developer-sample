
using DeveloperSample.ClassRefactoring.Enums;

namespace DeveloperSample.ClassRefactoring.Models
{
    public class SwallowEuropean : Swallow
    {
        public override SwallowType Type => SwallowType.European;

        public override double GetAirspeedVelocity()
        {
            //Note: Is not necessary to check for SwallowLoad.None
            //because its value is being initialized inside Swallow class as default

            //Default value when SwallowLoad.None
            double velocity = 20;
            if (Load == SwallowLoad.Coconut)
            {
                velocity = 16;
            }

            return velocity;
        }
    }
}