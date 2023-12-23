using DeveloperSample.ClassRefactoring.Enums;
using DeveloperSample.ClassRefactoring.Interfaces;
using System;

namespace DeveloperSample.ClassRefactoring.Models
{
    public abstract class Swallow : ISwallow
    {
        //Mark the property and method as abstract to force implementation
        //on the subtypes
        public abstract SwallowType Type { get; }
        public abstract double GetAirspeedVelocity();

        //Default value for Load SwallowLoad.None
        public SwallowLoad Load { get; private set; } = SwallowLoad.None;

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }
    }
}
