using DeveloperSample.ClassRefactoring.Enums;
using DeveloperSample.ClassRefactoring.Models;

namespace DeveloperSample.ClassRefactoring.Interfaces
{
    public interface ISwallowFactory
    {
        public ISwallow GetSwallow(SwallowType swallowType);
    }
}
