using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.TestExtensions.AspTesters;

namespace Ruhe.Tests.Extensions.AspTesters {
	public class InputDropDownListTesterTests : WebFormTestCase {
		private InputDropDownListTester dropDownList;

		[Test]
		public void SelectByValue() {
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputDropDownListTester)));
			dropDownList = new InputDropDownListTester("dropDownList", CurrentWebForm);
			dropDownList.SelectByValue("two");
			AssertEquals("selected index should be 2", 2, dropDownList.SelectedIndex);
		}
	}
}