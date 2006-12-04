using System;
using NUnit.Framework;
using AIMLbot;
using System.Xml;

namespace Tests.AIMLTagHandlers
{
    [TestFixture]
    public class sizeTagTests
    {
        private AIMLbot.Bot mockBot;
        private AIMLbot.User mockUser;
        private AIMLbot.Request mockRequest;
        private AIMLbot.Result mockResult;
        private AIMLbot.AIMLTagHandlers.size mockBotTagHandler;

        [TestFixtureSetUp]
        public void setupMockObjects()
        {
            this.mockBot = new Bot();
            this.mockUser = new User("1", this.mockBot);
            this.mockRequest = new Request("This is a test", this.mockUser, this.mockBot);
            this.mockResult = new Result(this.mockUser, this.mockBot, this.mockRequest);
        }

        [Test]
        public void testWithValidData()
        {
            XmlNode testNode = StaticHelpers.getNode("<size/>");
            this.mockBotTagHandler = new AIMLbot.AIMLTagHandlers.size(this.mockBot, this.mockUser, this.mockRequest, this.mockResult, testNode);
            Assert.AreEqual("0", this.mockBotTagHandler.Transform());
            AIMLbot.Utils.AIMLLoader loader = new AIMLbot.Utils.AIMLLoader(this.mockBot);
            loader.loadAIML();
            Assert.AreEqual("25", this.mockBotTagHandler.Transform());
        }

        [Test]
        public void testWithBadXml()
        {
            XmlNode testNode = StaticHelpers.getNode("<soze/>");
            this.mockBotTagHandler = new AIMLbot.AIMLTagHandlers.size(this.mockBot, this.mockUser, this.mockRequest, this.mockResult, testNode);
            Assert.AreEqual("", this.mockBotTagHandler.Transform());
        }
    }
}
