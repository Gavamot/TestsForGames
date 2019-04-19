using System.Reflection.Metadata;
using NUnit.Framework;
using SkillsTree;

namespace NUnitTestProject1
{
    [TestFixture]
    class SkillTreeTest
    {
        SkillTreeRep rep = new SkillTreeRep();

        [Test]
        public void TestForAvailableSimple()
        {
            var tree = rep.Get1();
            var skill = tree.Skills[0];
            Assert.AreEqual(skill.CanBeUnlocked, true);

            skill = skill.Children[0];
            Assert.AreEqual(skill.CanBeUnlocked, true);

            Assert.AreEqual(skill.Children[0].CanBeUnlocked, false);
        }

        [Test]
        public void TestForAvailableDynamic()
        {
            var tree = rep.Get1();
            tree.Skills[0].Children[0].IsLocked = false;

            var skill = tree.Skills[0].Children[0].Children[0];
            Assert.AreEqual(skill.CanBeUnlocked, true);

            skill = skill.Children[0];
            Assert.AreEqual(skill.CanBeUnlocked, false);
        }

        [Test]
        public void TestForAvailableTwoParents()
        {
            var tree = rep.Get2();
            var skill_1 = tree.Skills[0].Children[0].Children[1];
            var skill_2 = tree.Skills[0].Children[1].Children[0];
            var skill_res = skill_1.Children[0]; 

            Assert.AreEqual(skill_res.CanBeUnlocked, false);

            skill_1.IsLocked = false;
            Assert.AreEqual(skill_res.CanBeUnlocked, false);

            skill_2.IsLocked = false;
            Assert.AreEqual(skill_res.CanBeUnlocked, true);
        }

    }
}