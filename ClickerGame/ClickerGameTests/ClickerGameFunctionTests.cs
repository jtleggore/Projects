using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using ClickerGameFunctions;

namespace ClickerGameTests
{
    [TestFixture]
    public class ClickerGameFunctionTests
    {
        [TestCase(1F, 5F, 5F, 10F)]
        public void TestMoneyFunctions(float baseDPT, float multDPT, float addDPT, float expectedResponse)
        {
            float actualResponse = MainFunctions.moneyMultiplyer(baseDPT, multDPT, addDPT);

            Assert.That(actualResponse == expectedResponse);
        }
    }
}
