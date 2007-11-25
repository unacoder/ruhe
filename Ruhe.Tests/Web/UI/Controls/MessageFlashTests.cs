using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class MessageFlashTests : RuheWebTest<Message> {
        private ButtonTester submit;
        private PanelTester body;

        [Test]
        public void FlashSurvivesRedirect() {
            WebAssert.NotVisible(body);
            submit.Click();
            WebAssert.Visible(body);
        }

        [Test]
        public void FlashDoesNotSurviveReloadOnceShown() {
            submit.Click();
            LoadPageWithSuffix("Flash");
            WebAssert.NotVisible(body);
        }

        [Test]
        public void UsesSpecifiedMessageType() {
            submit.Click();
            StringAssert.Contains(MessageType.Confirmation.ToString().ToLower(), Browser.CurrentPageText);
        }

        [Test]
        public void UsesSpecifiedHeaderText() {
            submit.Click();
            StringAssert.Contains("My Header", Browser.CurrentPageText);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FlashIsNotUsableOutsideWebContext() {
            Message.Flash("doesn't matter");
        }

        protected override void SetUp() {
            base.SetUp();
            LoadPageWithSuffix("Flash");
            submit = new ButtonTester(IdFor("submit"));
            body = new PanelTester(IdFor("flash"));
        }
    }
}