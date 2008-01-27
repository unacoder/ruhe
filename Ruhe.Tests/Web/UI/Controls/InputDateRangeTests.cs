using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateRangeTests : RuheWebTest<InputDateRange> {
        private TextBoxTester from;
        private TextBoxTester to;
        private LabelTester inputReadOnlyLabel;
        private TextBoxTester readOnlyFrom;
        private TextBoxTester readOnlyTo;
        private LabelTester readOnlyLabel;

        [Test]
        public void GetAndSetDateRangeValue() {
            InputDateRange input = new InputDateRange();
            DateRange oneWeek = new DateRange(DateTime.Today, DateTime.Today.AddDays(7));
            input.DateRange = oneWeek;

            Assert.AreEqual(oneWeek, input.DateRange);
        }

        [Test]
        public void InitialValueIsNull() {
            Assert.IsNull(new InputDateRange().DateRange);
        }

        [Test]
        public void HasTwoTextBoxes() {
            LoadPage();
            WebAssert.Visible(from);
            WebAssert.Visible(to);
            WebAssert.NotVisible(inputReadOnlyLabel);
        }

        [Test]
        public void DateRangeToStringIsDisplayedForReadOnlyControl() {
            LoadPage();
            WebAssert.NotVisible(readOnlyFrom);
            WebAssert.NotVisible(readOnlyTo);
            WebAssert.Visible(readOnlyLabel);
            DateRange expected = new DateRange(DateTime.Today, DateTime.Today.AddDays(3));
            Assert.AreEqual(expected.ToString(GlobalDatePattern), readOnlyLabel.Text);
        }

        protected override void SetUp() {
            base.SetUp();
            from = new TextBoxTester(IdFor("input_from"));
            to = new TextBoxTester(IdFor("input_to"));
            inputReadOnlyLabel = new LabelTester(IdFor("input_readOnly"));

            readOnlyFrom = new TextBoxTester(IdFor("readOnlyInput_from"));
            readOnlyTo = new TextBoxTester(IdFor("readOnlyInput_to"));
            readOnlyLabel = new LabelTester(IdFor("readOnlyInput_readOnly"));
        }
    }
}