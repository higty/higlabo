using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class LanguageText<T>
        where T : LanguageText, new()
    {
        public static T Text { get; set; } = new();
    }

    public abstract class LanguageText
    {
        public string DefaultLanguage { get; set; } = "en-US";
        protected abstract String[] LanguageList { get; }

        public Func<string> GetCurrentLanguage = () => CultureInfo.CurrentCulture.Name;

        protected string GetLanguage()
        {
            var language = CultureInfo.CurrentCulture.Name;
            if (this.GetCurrentLanguage != null)
            {
                language = this.GetCurrentLanguage();
            }
            for (int i = 0; i < this.LanguageList.Length; i++)
            {
                if (language == this.LanguageList[i]) { return language; }
            }
            return this.DefaultLanguage;
        }
        public abstract String GetText(String key);
    }

}
