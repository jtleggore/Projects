using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using ClickerGameFramework;
using static ClickerGameLogic.ClickerGameLogic;

namespace ClickerGameTests
{
    class ClickerGameFrameworkTests
    {
        [TestFixtureSource(nameof(BuildingTestCases))]
        class BuildingTests {

            Building a;

            static IEnumerable<Building[]> BuildingTestCases()
            {
                yield return new Building[] { new Building("TestBuilding", 2.25F, 1.5F, 1.2F) };
            }

            public BuildingTests(Building a)
            {
                this.a = a; 
            }

            [Test]
            public void When_Building_Expects_CorrectCost()
            {
                a.CostMultiplier = 3;
                Building.GlobalCostMultiplier = 2;

                Assert.That(a.CurrentCost == a.BaseCost * a.CostMultiplier * Building.GlobalCostMultiplier);
            }

            [Test]
            public void When_Building_Expects_CorrectDPT()
            {
                a.DPTMultiplier = 3;
                Building.GlobalDPTMultiplier = 2;

                Assert.That(a.CurrentDPT == a.BaseDPT * a.DPTMultiplier * Building.GlobalDPTMultiplier);
            }

            [Test]
            public void When_Building_Expects_CorrectNextCost()
            {
                a.CostMultiplier = 3;
                Building.GlobalCostMultiplier = 2;

                a.Quantity = 3;

                Assert.That(a.CurrentCost == 2.16F);
            }
        }

        [TestFixtureSource(nameof(UpgradeTestCases))]
        class UpgradeTests
        {
            Upgrade a;

            static IEnumerable<Upgrade[]> UpgradeTestCases()
            {
                yield return new Upgrade[] { new Upgrade("TestUpgrade", 5.25F, UnlockUpgrade1, SetUpgradeBonus1) };
            }

            public UpgradeTests(Upgrade a)
            {
                this.a = a;
            }

            [Test]
            public void When_Upgrade_Expects_CorrectCost()
            {
                a.CostMultiplier = 3;
                Upgrade.GlobalCostMultiplier = 2;

                Assert.That(a.CurrentCost == a.BaseCost * a.CostMultiplier * Upgrade.GlobalCostMultiplier);
            }

            /*[Test]
            public void When_Upgrade_Expects_CorrectDPT()
            {
                a.DPTMultiplier = 3;
                Upgrade.GlobalDPTMultiplier = 2;

                Assert.That(a.CurrentDPT == a.BaseDPT * a.DPTMultiplier * Upgrade.GlobalDPTMultiplier);
            }

            [Test]
            public void When_Upgrade_Expects_CorrectNextCost()
            {
                a.CostMultiplier = 3;
                Upgrade.GlobalCostMultiplier = 2;

                a.Quantity = 3;

                Assert.That(a.CurrentCost == 2.16F);
            }
        }*/
    }
}
