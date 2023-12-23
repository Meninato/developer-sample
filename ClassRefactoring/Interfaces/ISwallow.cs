using DeveloperSample.ClassRefactoring.Enums;

namespace DeveloperSample.ClassRefactoring.Interfaces
{
    public interface ISwallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; }
        public void ApplyLoad(SwallowLoad load);
        public double GetAirspeedVelocity();
    }
}