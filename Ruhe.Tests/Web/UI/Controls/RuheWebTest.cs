using System.Text.RegularExpressions;
using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.Common.Utilities;
using Ruhe.TestExtensions;

namespace Ruhe.Tests.Web.UI.Controls {
    public class RuheWebTest<T> : WebFormTestCase {
        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp() {
            //launches at http://localhost:4269/Ruhe.TestWeb
            new AspNetDevelopmentServer(4269, TestWebPath, "Ruhe.TestWeb");
        }

        private string TestWebPath {
            get {
                string executingPath = StringUtilities.RemovePrefix(GetType().Assembly.CodeBase, "file:///");
                return Regex.Replace(executingPath, string.Format("/{0}/.*", GetType().Assembly.GetName().Name), "/Ruhe.TestWeb").Replace('/', '\\');
            }
        }

        protected static string IdFor(string partialId) {
            return Tests.IdFor.It(partialId);
        }

        protected static string GetUrlPath<R>() {
            string subPath = StringUtilities.RemovePrefix(typeof(R).FullName, @"\w+\.").Replace(".", "/");
            return string.Format("{0}{1}Tests.aspx", "http://localhost:4269/Ruhe.TestWeb/", subPath);
        }

        protected virtual void LoadPage() {
            Browser.GetPage(GetUrlPath<T>());
        }

        protected virtual void LoadPageWithOption(string option) {
            Browser.GetPage(string.Format("{0}?{1}=on", GetUrlPath<T>(), option));
        }

        protected virtual void LoadPageWithSuffix(string suffix) {
            Browser.GetPage(GetUrlPath<T>().Replace("Tests.aspx", suffix + ".aspx"));
        }
    }
}