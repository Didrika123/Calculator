using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;
using System.Linq;

namespace Calculator.Tests
{
    class CalculatorDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //yield return new object[] { 1, 1, 2 }; //Yield makes it so FIrst this is returned, then next time this is called it remembers, and next yield will be called instead (Pro: it doesnt created objects not called for)
            //yield return new object[] { 1, 1, 2 }; //Second call, using yield, will make this return.
            string testName = testMethod.Name;
            string path = "CalculatorExternalTestData.txt";
            var lines = System.IO.File.ReadAllLines(path);
            List<object[]> list = new List<object[]>();
            bool foundData = false, readAllData = false;
            foreach(var line in lines){
                if (foundData && !readAllData)
                {
                    if (line == "")
                    {
                        readAllData = true;
                    }
                    else
                    {
                        var split = line.Split(',');
                        var oneSetOfTestData = new object[] { double.Parse(split[0]), double.Parse(split[1]), double.Parse(split[2]) };
                        list.Add(oneSetOfTestData);
                    }
                }
                if (line == testName)
                {
                    foundData = true;
                }
            }
            return list;
           
            /*
             * This is how the pros do it, but i rewrote it in simpler terms above ( I think (Cuz im not entirely 100% sure i understand this below))
             * 
            return lines.Select(x => {
                var lineSplit = x.Split(',');
                return new object[] { double.Parse(lineSplit[0]), double.Parse(lineSplit[1]), double.Parse(lineSplit[2]) }; } );
            */
        }
    }
}
