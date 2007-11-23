using System;
using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.Tests.TestExtensions.HtmlTesters;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateTests : RuheWebTest<InputDate> {
        private HtmlImageTester calendar;
        private HtmlImageTester readonlyCalendar;

        private void LoadTestPage() {
            LoadPage();
            calendar = new HtmlImageTester(IdFor.It("date_calendar"));
            readonlyCalendar = new HtmlImageTester(IdFor.It("readonly_calendar"));
        }

        [Test]
        public void HasCalendarImage() {
            LoadTestPage();
            WebAssert.Visible(calendar);
        }

        [Test]
        public void DoesNotHaveCalendarImageWhenReadOnly() {
            LoadTestPage();
            WebAssert.NotVisible(readonlyCalendar);
        }

        [Test]
        public void EmitsKeystrokeFilterScript() {
            LoadTestPage();
            Assert.IsTrue(Browser.CurrentPageText.Contains("Ruhe$DATE"));
        }

        [Test]
        public void EmitsUsersDateFormat() {
            LoadTestPage();
            Assert.IsTrue(Browser.CurrentPageText.Contains("var Ruhe$DATE_FORMAT = "));
        }

        [Test]
        public void DefaultValueIsNull() {
            InputDate input = new InputDate();
            input.Text = string.Empty;
            Assert.IsNull(input.Value);
        }

        [Test]
        public void NonNullValueCanBeConvertedToDateTime() {
            InputDate input = new InputDate();
            DateTime expected = new DateTime(2002, 10, 21);
            input.Value = expected;
            Assert.AreEqual("10/21/2002", input.Text);
            Assert.AreEqual(expected, input.Value);
        }

        [Test]
        public void DefaultingValueToTodaySetsValue() {
            InputDate input = new InputDate();
            input.DefaultToToday = true;
            Assert.AreEqual(DateTime.Today, input.Value);
        }

        [Test]
        public void DefaultToTodayOnlySetsValueIfOneIsNotAlreadySet() {
            InputDate input = new InputDate();
            DateTime expected = new DateTime(2000, 1, 1);
            input.Value = expected;
            input.DefaultToToday = true;
            Assert.AreEqual(expected, input.Value);
        }
    }
}