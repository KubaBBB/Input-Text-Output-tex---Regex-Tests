using System;
using NUnit.Framework;

namespace Codding
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void SearchAndReplace_OneLineGiven_OneShouldBeReplaced() 
        {
            var output = new Output();
            output.SearchAndReplace(new String[] { "Bbbbbbbbb" }, 1, "b", "a", 1);
            Assert.AreEqual(new String[] { "Baaaaaaaa" }, output.Text);
        }

        [Test]
        public void SearchAndReplace_NothingGiven_NothingReplaced() 
        {
            var output = new Output();
            output.SearchAndReplace(new String[] { "" }, 1, "b", "a", 1);
            Assert.AreEqual(new String[] { "" }, output.Text);
        }

        [Test]
        public void SearchAndReplace_TwoLinesGiven_OneShouldBeReplaced()
        {
            var output = new Output();
            output.SearchAndReplace(new String[] { "Bbbbbbbbb" , "bbbbbbbbb" }, 2, "b", "a", 1);
            Assert.AreEqual(new String[] { "Baaaaaaaa" , "bbbbbbbbb" }, output.Text);
        }

        [Test]
        public void SearchAndReplace_TwoLinesGiven_NothingShouldBeReplaced()
        {
            var output = new Output();
            output.SearchAndReplace(new String[] { "Bbbbbbbbb", "bbbbbbbbb" }, 2, "b", "a", -1);
            Assert.AreEqual(new String[] { "Bbbbbbbbb", "bbbbbbbbb" }, output.Text);
        }

        [Test]
        public void SearchAndReplace_TwoLinesGiven_NothingShouldBeOnOutput()
        {
            var output = new Output();
            output.SearchAndReplace(new String[] { "Bbbbbbbbb", "bbbbbbbbb" }, 0, "b", "a", 1);
            Assert.AreEqual(new String[] { }, output.Text);
        }

        [Test]
        public void SearchAndReplace_TwoLinesGiven_TwoShouldBeReplaced()
        {
            var output = new Output();
            output.SearchAndReplace(new String[] { "Bbbbbbbbb", "bbbbbbbbb" }, 2, "b", "a", 2);
            Assert.AreEqual(new String[] { "Baaaaaaaa", "aaaaaaaaa" }, output.Text);
        }

        [Test]
        public void SearchAndReplace_TwoLinesGiven_TwoShouldBeReplaced_ChangedKey()
        {
            var output = new Output();
            output.SearchAndReplace(new String[] { "Bbbbbbbbb", "bbbbbbbbb" }, 2, "bb", "aAa", 2);
            Assert.AreEqual(new String[] { "BaAaaAaaAaaAa", "aAaaAaaAaaAab" }, output.Text);
        }
    }
}
