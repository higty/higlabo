using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class ValidationResultMessagePanel
    {
        public VueAttribute ValidationName { get; private set; } = new VueAttribute("h-validation-name");

        public ValidationResultMessagePanel() { }
        public ValidationResultMessagePanel(String validationName)
        {
            this.ValidationName.SetValue(validationName);
        }
    }
}
