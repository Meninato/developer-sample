using DeveloperSample.ClassRefactoring.Enums;
using DeveloperSample.ClassRefactoring.Interfaces;
using DeveloperSample.ClassRefactoring.Models;
using System;
using System.Collections.Generic;

namespace DeveloperSample.ClassRefactoring
{
    public class SwallowFactory : ISwallowFactory
    {
        //Note:
        //Using a dictionary to cache options x types to reduce a couple of ifs
        //In a different requirement it also opens the possibility to change the creater functions in a 
        //class to add advanced creation

        private Dictionary<SwallowType, Func<ISwallow>> _options = new Dictionary<SwallowType, Func<ISwallow>>();

        public SwallowFactory()
        {
            _options.Add(SwallowType.African, CreateAfrican);
            _options.Add(SwallowType.European, CreateEuropean);
        }

        public ISwallow GetSwallow(SwallowType swallowType)
        {
            if(_options.TryGetValue(swallowType, out Func<ISwallow> builder))
            {
                return builder();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private ISwallow CreateAfrican()
        {
            return new SwallowAfrican();
        }

        private ISwallow CreateEuropean()
        {
            return new SwallowEuropean();
        }
    }
}