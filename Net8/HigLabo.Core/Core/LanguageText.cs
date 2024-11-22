using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class LanguageText<T>
    where T : LanguageText, new()
{
    public static T Text { get; set; } = new();
}

public abstract class LanguageText
{
    public string DefaultLanguage { get; set; } = "en-US";
    protected abstract String[] LanguageList { get; }

    public Func<string> GetCurrentLanguage = () => Thread.CurrentThread.CurrentCulture.Name;
    public List<LanguageText> TextList { get; init; } = new();

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

		protected abstract String GetText(string key);
		
    private IEnumerable<LanguageText> GetLanguageTextList()
    {
        foreach (var item in this.TextList)
        {
            yield return item;
        }
        yield return this;
    }
    public string GetByKey(string key)
    {
        foreach (var item in this.GetLanguageTextList())
        {
            var text = item.GetText(key);
            if (text.IsNullOrEmpty() == false) { return text; }
        }
        return key;
    }

    private IEnumerable<string> GetKeyList<T>(T key)
        where T : Enum
    {
        var typeName = typeof(T).Name;
        yield return $"{typeName}_{key.ToStringFromEnum()}";
        yield return $"{typeName.ExtractString('+', null)}_{key.ToStringFromEnum()}";
        yield return key.ToStringFromEnum();
    }
    public string Get<T>(T key)
        where T: Enum
    {
        foreach (var eKey in this.GetKeyList(key))
        {
            foreach (var languageText in this.GetLanguageTextList())
            {
                var text = languageText.GetText(eKey);
                if (text.IsNullOrEmpty() == false) { return text; }
            }
        }
        return key.ToStringFromEnum();
    }

    public string Get(params string[] textList)
    {
        for (int i = 0; i < this.LanguageList.Length; i++)
        {
            if (this.GetCurrentLanguage() == this.LanguageList[i])
            {
                if (textList.Length > i)
                {
                    return textList[i];
                }
            }
        }
        if (textList.Length > 0)
        {
            return textList[0];
        }
        return "";
    }

}
