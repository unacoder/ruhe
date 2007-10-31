using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputNumber : AbstractValueTypeInput<double> {
        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.Double; }
        }

        protected override string KeystrokeFilter {
            get {
                if (!MinimumValue.HasValue || MinimumValue < 0)
                    return "Ruhe$NUMBER";
                return "Ruhe$POSITIVE_NUMBER";
            }
        }
    }
}