namespace HigLabo.Web
{
    public class SelectButtonRecord
    {
        public string Text { get; set; } = "";
        public object? Value { get; set; }

        public SelectButtonRecord(string text, object? value)
        {
            Text = text;
            Value = value;
        }

        public static List<SelectButtonRecord> CreateRecordList<TEnum>()
            where TEnum : struct, Enum
        {
            return CreateRecordList(Enum.GetValues<TEnum>(), el => T.Text.Get(el));
        }
        public static List<SelectButtonRecord> CreateRecordList<TEnum>(Func<TEnum, string> textSelector)
            where TEnum : struct, Enum
        {
            return CreateRecordList(Enum.GetValues<TEnum>(), textSelector);
        }
        public static List<SelectButtonRecord> CreateRecordList<TEnum>(IEnumerable<TEnum> recordList)
            where TEnum : struct, Enum
        {
            return CreateRecordList(recordList, el => T.Text.Get(el));
        }
        public static List<SelectButtonRecord> CreateRecordList<TEnum>(IEnumerable<TEnum> recordList, Func<TEnum, string> textSelector)
            where TEnum : struct, Enum
        {
            var l = recordList.Select(el => new SelectButtonRecord(textSelector(el), el)).ToList();
            return l;
        }
        public static List<SelectButtonRecord> CreateRecordList<TEnum>(params TEnum[] recordList)
            where TEnum : struct, Enum
        {
            var l = recordList.Select(el => new SelectButtonRecord(T.Text.Get(el), el)).ToList();
            return l;
        }
    }
}
