using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
	public class NumberToDateTimeProcessor
	{
		public TimeOnly TimeZone { get; set; } = new TimeOnly(9, 0);
		public List<INumberToDateTimeConverter> Converters { get; init; } = new();

		public NumberToDateTimeProcessor()
			: this(DateTimeOffset.Now.Offset.GetTimeOnly())
		{

		}
		public NumberToDateTimeProcessor(TimeOnly timeZone)
		{
		}
		public NumberToDateTimeProcessor(TimeOnly timeZone, DateDirection dateDirection)
		{
			this.Converters.Add(new NumberToDateTimeConverter_HH());
			this.Converters.Add(new NumberToDateTimeConverter_Hmm());
			this.Converters.Add(new NumberToDateTimeConverter_HHmm());
			this.Converters.Add(new NumberToDateTimeConverter_ddHH(dateDirection));
			this.Converters.Add(new NumberToDateTimeConverter_ddHHH());
			this.Converters.Add(new NumberToDateTimeConverter_ddHHmm());
			this.Converters.Add(new NumberToDateTimeConverter_Mdd());
			this.Converters.Add(new NumberToDateTimeConverter_MMdd());
			this.Converters.Add(new NumberToDateTimeConverter_MMddHH(dateDirection));
			this.Converters.Add(new NumberToDateTimeConverter_MMddHHmm(dateDirection));
		}
		public DateTime? Convert(string? value)
		{
			if (value == null) { return null; }
			foreach (var item in Converters)
			{
				var dtime = item.Convert(value, this.TimeZone);
				if (dtime.HasValue) { return dtime.Value; }
			}
			return null;
		}
	}
}
