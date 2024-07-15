using HigLabo.Core;
using System.Globalization;

namespace HigLabo.Bing
{
    public enum BingMarket
    {
        Argentina,
        Australia,
        Austria,
        BelgiumDutch,
        BelgiumFrench,
        Brazil,
        Canada,
        CanadaFrench,
        Chile,
        Denmark,
        Finland,
        France,
        Germany,
        HongKong,
        India,
        Indonesia,
        Italy,
        Japan,
        Korea,
        Malaysia,
        Mexico,
        Netherlands,
        NewZealand,
        Norway,
        China,
        Philippines,
        Poland,
        Russia,
        SouthAfrica,
        Spain,
        Sweden,
        SwitzerlandFrench,
        SwitzerlandGerman,
        Taiwan,
        Turkiye,
        UnitedKingdom,
        UnitedStates,
        UnitedStatesSpanish,
    }
    public static class BingMarketLanguage
    {
        public static BingMarket Create()
        {
            switch (CultureInfo.CurrentCulture.Name)
            {
                case "en-US": return BingMarket.UnitedStates;
                case "ja-JP": return BingMarket.Japan;
                case "zh-CN": return BingMarket.China;
                case "zh-TW": return BingMarket.Taiwan;
                case "en-GB": return BingMarket.UnitedKingdom;
                case "fr-FR": return BingMarket.France;
                case "de-DE": return BingMarket.Germany;
                case "it-IT": return BingMarket.Italy;
                case "es-ES": return BingMarket.Spain;
                case "ru-RU": return BingMarket.Russia;
                case "pt-BR": return BingMarket.Brazil;
                case "ko-KR": return BingMarket.Korea;
                case "nl-NL": return BingMarket.Netherlands;
                case "sv-SE": return BingMarket.Sweden;
                case "da-DK": return BingMarket.Denmark;
                case "fi-FI": return BingMarket.Finland;
                case "no-NO": return BingMarket.Norway;
                case "pl-PL": return BingMarket.Poland;
                case "tr-TR": return BingMarket.Turkiye;
                case "en-AU": return BingMarket.Australia;
                case "en-CA": return BingMarket.Canada;
                case "fr-CA": return BingMarket.CanadaFrench;
                case "es-CL": return BingMarket.Chile;
                case "es-MX": return BingMarket.Mexico;
                case "en-NZ": return BingMarket.NewZealand;
                case "en-MY": return BingMarket.Malaysia;
                case "en-PH": return BingMarket.Philippines;
                case "en-ZA": return BingMarket.SouthAfrica;
                case "fr-BE": return BingMarket.BelgiumFrench;
                case "nl-BE": return BingMarket.BelgiumDutch;
                case "zh-HK": return BingMarket.HongKong;
                case "en-IN": return BingMarket.India;
                case "en-ID": return BingMarket.Indonesia;
                case "es-AR": return BingMarket.Argentina;
                case "de-AT": return BingMarket.Austria;
                default: return BingMarket.UnitedStates;
            }
        }
    }
    public static class BingMarketExtensions
    {
        public static string GetMarketCode(this BingMarket market)
        {
            switch (market)
            {
                case BingMarket.Argentina:return "es-AR";
                case BingMarket.Australia:return "en-AU";
                case BingMarket.Austria:return "de-AT";
                case BingMarket.BelgiumDutch:return "nl-BE";
                case BingMarket.BelgiumFrench:return "fr-BE";
                case BingMarket.Brazil: return "pt-BR";
                case BingMarket.Canada: return "en-CA";
                case BingMarket.CanadaFrench: return "fr-CA";
                case BingMarket.Chile: return "es-CL";
                case BingMarket.Denmark:return "da-DK";
                case BingMarket.Finland: return "fi-FI";
                case BingMarket.France: return "fr-FR";
                case BingMarket.Germany:return "de-DE";
                case BingMarket.HongKong: return "zh-HK";
                case BingMarket.India: return "en-IN";
                case BingMarket.Indonesia: return "en-ID";
                case BingMarket.Italy: return "it-IT";
                case BingMarket.Japan: return "ja-JP";
                case BingMarket.Korea: return "ko-KR";
                case BingMarket.Malaysia: return "en-MY";
                case BingMarket.Mexico: return "es-MX";
                case BingMarket.Netherlands: return "nl-NL";
                case BingMarket.NewZealand:return "en-NZ";
                case BingMarket.Norway: return "no-NO";
                case BingMarket.China: return "zh-CN";
                case BingMarket.Philippines:return "en-PH";
                case BingMarket.Poland: return "pl-PL";
                case BingMarket.Russia: return "ru-RU";
                case BingMarket.SouthAfrica: return "en-ZA";
                case BingMarket.Spain: return "es-ES";
                case BingMarket.Sweden: return "sv-SE";
                case BingMarket.SwitzerlandFrench: return "fr-CH";
                case BingMarket.SwitzerlandGerman: return "de-CH";
                case BingMarket.Taiwan: return "zh-TW";
                case BingMarket.Turkiye: return "tr-TR";
                case BingMarket.UnitedKingdom: return "en-GB";
                case BingMarket.UnitedStates: return "en-US";
                case BingMarket.UnitedStatesSpanish: return "es-US";
                default: throw SwitchStatementNotImplementException.Create(market);
            }
        }
    }
}
