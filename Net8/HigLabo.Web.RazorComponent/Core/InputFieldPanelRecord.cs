namespace HigLabo.Web
{
    public class InputFieldPanelRecord
    {
        public string Text { get; set; } = "";
        public object? Value { get; set; }

        public InputFieldPanelRecord(string text, object? value)
        {
            Text = text;
            Value = value;
        }

        public static void HandleRecordListLoadingContext<TEnum>(RecordListLoadingContext context)
            where TEnum : struct, Enum
        {
            context.RecordList.Clear();
            foreach (var item in Enum.GetValues<TEnum>())
            {
                var r = new InputFieldPanelRecord(T.Text.Get(item), item);
                context.RecordList.Add(r);
            }
        }

        public static List<InputFieldPanelRecord> CreateRecordList<TEnum>()
            where TEnum : struct, Enum
        {
            return CreateRecordList(Enum.GetValues<TEnum>(), el => T.Text.Get(el));
        }
        public static List<InputFieldPanelRecord> CreateRecordList<TEnum>(Func<TEnum, string> textSelector)
            where TEnum : struct, Enum
        {
            return CreateRecordList(Enum.GetValues<TEnum>(), textSelector);
        }
        public static List<InputFieldPanelRecord> CreateRecordList<TEnum>(IEnumerable<TEnum> recordList)
            where TEnum : struct, Enum
        {
            return CreateRecordList(recordList, el => T.Text.Get(el));
        }
        public static List<InputFieldPanelRecord> CreateRecordList<TEnum>(IEnumerable<TEnum> recordList, Func<TEnum, string> textSelector)
            where TEnum : struct, Enum
        {
            var l = recordList.Select(el => new InputFieldPanelRecord(textSelector(el), el)).ToList();
            return l;
        }
        public static List<InputFieldPanelRecord> CreateRecordList<TEnum>(params TEnum[] recordList)
            where TEnum : struct, Enum
        {
            var l = recordList.Select(el => new InputFieldPanelRecord(T.Text.Get(el), el)).ToList();
            return l;
        }
    }
}
