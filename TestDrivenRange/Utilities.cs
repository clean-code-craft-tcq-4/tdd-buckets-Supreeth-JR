namespace TestDrivenRange
{
    using System;

    public class Utilities : IUtilities
    {
        public string GetInput()
        {
            PrintOutput("Enter integer number in comma separated. ex - 2,3,4");
            return Console.ReadLine();
        } 

        public void PrintOutput(string strOutput)
            => Console.WriteLine(strOutput);

    }
}
