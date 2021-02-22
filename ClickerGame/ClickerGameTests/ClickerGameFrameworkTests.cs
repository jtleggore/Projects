using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using ClickerGameFramework;

namespace ClickerGameTests
{
    [TestFixture]
    class ClickerGameFrameworkTests
    {
        [Test]
        public void test()
        {
            MainOperator.doClick(5);
        }
    }
}
