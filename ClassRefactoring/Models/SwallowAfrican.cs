
using DeveloperSample.ClassRefactoring.Enums;

namespace DeveloperSample.ClassRefactoring.Models
{
    public class SwallowAfrican : Swallow
    {
        public override SwallowType Type => SwallowType.African;

        public override double GetAirspeedVelocity()
        {
            //Note: Is not necessary to check for SwallowLoad.None
            //because its value is being initialized inside Swallow class as default

            //Default value when SwallowLoad.None
            double velocity = 22;
            if (Load == SwallowLoad.Coconut)
            {
                velocity = 18;
            }

            return velocity;
        }
    }
}