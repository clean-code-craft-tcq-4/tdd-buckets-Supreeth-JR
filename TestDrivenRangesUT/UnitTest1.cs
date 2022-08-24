using Moq;

namespace TestDrivenRangesUT
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestDrivenRange;

    [TestClass]
    public class UnitTest1
    {
        private Mock<IUtilities> _UtilitesMock;
        [TestInitialize]
        public void TestInit()
        {
            _UtilitesMock = new Mock<IUtilities>();
        }

        [TestMethod]
        public void ValidInput()
        {
            _UtilitesMock.Setup(x => x.GetInput()).Returns("2,3,5");
            var findRange = new FindRanges(_UtilitesMock.Object);
            findRange.GetRange();
            bool result = findRange._NumberList.Count > 0;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotValidInput()
        {
            _UtilitesMock.Setup(x => x.GetInput()).Returns("a,b");
            var findRange = new FindRanges(_UtilitesMock.Object);
            findRange.GetRange();
            Assert.IsTrue(findRange._NumberList.Count == 0);
        }

        [TestMethod]
        public void FindRange()
        {
            _UtilitesMock.Setup(x => x.GetInput()).Returns("3,3,5,4,10,11,12");
            var findRange = new FindRanges(_UtilitesMock.Object);
            findRange.GetRange();
            Assert.IsTrue(findRange._RangeOutput.Count == 2);
        }
    }
}
