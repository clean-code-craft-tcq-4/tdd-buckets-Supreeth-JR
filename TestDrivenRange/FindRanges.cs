using System.Linq;

namespace TestDrivenRange
{
    using System.Collections.Generic;

    public class FindRanges
    {
        private readonly IUtilities _Utilities;
        public List<int> _NumberList;
        public Dictionary<(int, int), int> _RangeOutput;
        public FindRanges(IUtilities utilities)
        {
            _Utilities = utilities;
            _NumberList = new List<int>();
            _RangeOutput = new Dictionary<(int, int), int>();
        }

        public void GetRange()
        {
            validateInput();
            FindRange();
            _Utilities.PrintOutput(FormattedOutput());
        }

        private void validateInput()
        {
            var strInput = _Utilities.GetInput();
            if (!string.IsNullOrEmpty(strInput))
            {
                var lstString = strInput.Split(',');
                ConvertToNumberList(lstString);
                return;
            }
            _Utilities.PrintOutput("Enter valid input.");
        }

        private void ConvertToNumberList(string[] arrStrInput)
        {
            foreach (var input in arrStrInput)
            {
                if (int.TryParse(input, out int result))
                {
                    _NumberList.Add(result);
                }
            }
        }

        private void FindRange()
        {
            _NumberList = _NumberList.OrderBy(x => x).ToList();

            int firstNumberInRange = 0;
            int lastNumberInRange = 0;
            bool isFirstNumberInRange = true;
            int rangeCounter = 0;
            int lstIndex = 0;
            _NumberList.ForEach(x =>
            {
                lstIndex++;
                if (isFirstNumberInRange)
                {
                    firstNumberInRange = x;
                    lastNumberInRange = x;
                    isFirstNumberInRange = !isFirstNumberInRange;
                    rangeCounter++;
                }
                else
                {
                    if (lastNumberInRange != x)
                    {
                        if (lastNumberInRange + 1 == x)
                        {
                            lastNumberInRange = x;
                            rangeCounter++;

                            if (_NumberList.Count == lstIndex)
                            {
                                AddRangeCount(firstNumberInRange, lastNumberInRange, rangeCounter);
                            }
                        }
                        else
                        {
                            AddRangeCount(firstNumberInRange,lastNumberInRange,rangeCounter);
                            rangeCounter = 0;
                            rangeCounter++;
                            firstNumberInRange = x;
                            lastNumberInRange = x;
                        }
                    }
                    else
                    {
                        rangeCounter++;
                    }
                }
            });
        }

        private string FormattedOutput()
        {
            string formattedOutput = "";
            foreach (var keyValuePair in _RangeOutput)
            {
                formattedOutput += $"{keyValuePair.Key.Item1},{keyValuePair.Key.Item2} - {keyValuePair.Value} \n";
            }
            return formattedOutput;
        }

        private void AddRangeCount(int firstNumberInRange,int lastNumberInRange,int rangeCounter)
        {
            _RangeOutput.Add((firstNumberInRange, lastNumberInRange), rangeCounter);
        }
    }
}
