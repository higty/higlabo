using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace HigLabo.Rss.Test.TestCase
{
    [TestClass]
    public class Rss_2_0_ParserTest
    {
        [TestMethod]
        [DeploymentItem(@"rss2_feed_one.xml", "testData")]
        public void TestRss2_0ParserWithFeedOne()
        {
            // A
            Rss_2_0_Parser parser = new Rss_2_0_Parser();
            // A
            var feed = parser.Parse(File.ReadAllText(@"testData\rss2_feed_one.xml", Encoding.UTF8));
            // A
            Assert.IsNotNull(feed);
            Assert.AreEqual(3, feed.Items.Count);
            Assert.AreEqual(RssVersion.Rss_2_0, feed.Version);
        }

        [TestMethod]
        [DeploymentItem(@"rss2_feed_two.xml", "testData")]
        public void TestRss2_0ParserWithFeedTwo()
        {
            // A
            Rss_2_0_Parser parser = new Rss_2_0_Parser();
            // A
            var feed = parser.Parse(File.ReadAllText(@"testData\rss2_feed_two.xml", Encoding.UTF8));
            // A
            Assert.IsNotNull(feed);
            Assert.AreEqual(60, feed.Items.Count);
            Assert.AreEqual(RssVersion.Rss_2_0, feed.Version);
        }

        [TestMethod]
        [DeploymentItem(@"rss2_feed_three.xml", "testData")]
        public void TestRss2_0ParserWithFeedThree()
        {
            // A
            Rss_2_0_Parser parser = new Rss_2_0_Parser();
            // A
            var feed = parser.Parse(File.ReadAllText(@"testData\rss2_feed_three.xml", Encoding.UTF8));
            // A
            Assert.IsNotNull(feed);
            Assert.AreEqual(15, feed.Items.Count);
            Assert.AreEqual(RssVersion.Rss_2_0, feed.Version);
        }
    }
}
