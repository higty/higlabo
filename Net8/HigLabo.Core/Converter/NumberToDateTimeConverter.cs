using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLabo.Core
{
	public interface INumberToDateTimeConverter
	{
		DateTime? Convert(string value, TimeOnly timeZone);
	}
	public enum DateDirection
	{
		Past,
		Future,
	}
	public class NumberToDateTimeConverter 
	{
		public DateTime GetNow(TimeOnly timeZone, Int32 hour, Int32 minute)
		{
			var dtime = DateTimeOffset.Now.ChangeTimeZone(timeZone).Date + new TimeSpan(hour, minute, 0);
			return dtime;
		}
		public static DateTime? GetPastDate(Int32? day)
		{
			if (day.HasValue == false) { return null; }
			if (day > 0 || day < 32)
			{
				var dtime = DateTime.Now.Date;
				var loopCount = 0;
				while (true)
				{
					if (dtime.Day == day)
					{
						return dtime;
					}
					dtime = dtime.AddDays(-1);
					loopCount++;
					if (loopCount > 100)
					{
						break;
					}
				}
			}
			return null;
		}
		public static DateTime? GetFutureDate(Int32? day)
		{
			if (day.HasValue == false) { return null; }
			if (day > 0 || day < 32)
			{
				var dtime = DateTime.Now.Date;
				var loopCount = 0;
				while (true)
				{
					if (dtime.Day == day)
					{
						return dtime;
					}
					dtime = dtime.AddDays(1);
					loopCount++;
					if (loopCount > 100)
					{
						break;
					}
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_HH : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			var hour = value.ToInt32();
			if (hour >= 0 && hour < 24)
			{
				return this.GetNow(timeZone, hour.Value, 0);
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_Hmm : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			if (value.Length == 3)
			{
				var hour = value.Substring(0, 1).ToInt32();
				var minute = value.Substring(1, 2).ToInt32();
				if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
				{
					return this.GetNow(timeZone, hour.Value, minute.Value);
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_HHmm : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			if (value.Length == 4)
			{
				var hour = value.Substring(0, 2).ToInt32();
				var minute = value.Substring(2, 2).ToInt32();
				if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
				{
					return this.GetNow(timeZone, hour.Value, minute.Value);
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_ddHH : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public DateDirection DateDirection { get; set; } = DateDirection.Future;

		public NumberToDateTimeConverter_ddHH(DateDirection dateDirection)
		{
			this.DateDirection = dateDirection;
		}
		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			if (value.Length == 2)
			{
				var date = GetFutureDate(value.Substring(0, 1).ToInt32());
				if (date.HasValue)
				{
					var dtime = date.Value;
					var hour = value.Substring(1,1).ToInt32();
					if (hour >= 0 && hour < 24)
					{
						return date.Value.AddHours(hour.Value);
					}
				}
			}
			else if (value.Length == 3)
			{
				var date = GetFutureDate(value.Substring(0, 1).ToInt32());
				if (date.HasValue)
				{
					var dtime = date.Value;
					var hour = value.Substring(1, 2).ToInt32();
					if (hour >= 0 && hour < 24)
					{
						return date.Value.AddHours(hour.Value);
					}
				}
				date = GetFutureDate(value.Substring(0, 2).ToInt32());
				if (date.HasValue)
				{
					var dtime = date.Value;
					var hour = value.Substring(2, 1).ToInt32();
					if (hour >= 0 && hour < 24)
					{
						return date.Value.AddHours(hour.Value);
					}
				}
			}
			else if (value.Length == 4)
			{
				var date = GetFutureDate(value.Substring(0, 2).ToInt32());
				if (date.HasValue)
				{
					var dtime = date.Value;
					var hour = value.Substring(2, 2).ToInt32();
					if (hour >= 0 && hour < 24)
					{
						return date.Value.AddHours(hour.Value);
					}
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_ddHHH : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public static readonly Regex dd_Hmm = new Regex("(?<Day>[\\d]{1,2})[日\\s](?<HourMinute>[\\d]{3})");

		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			var m = dd_Hmm.Match(value);
			if (m.Success)
			{
				var date = GetFutureDate(m.Groups["Day"].Value.ToInt32());
				if (date.HasValue)
				{
					var hour = m.Groups["HourMinute"].Value.Substring(0, 1).ToInt32();
					var minute = m.Groups["HourMinute"].Value.Substring(1, 2).ToInt32();
					if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
					{
						return date.Value.AddHours(hour.Value).AddMinutes(minute.Value);
					}
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_ddHHmm : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public static readonly Regex dd_HHmm = new Regex("(?<Day>[\\d]{1,2})[日\\s](?<HourMinute>[\\d]{4})");
		public static readonly Regex dd_HH_mm = new Regex("(?<Day>[\\d]{1,2})[日\\s](?<HourMinute>[\\d]{1,2}:[\\d]{1,2})");
		public static readonly Regex[] RegexList = new Regex[] { dd_HHmm, dd_HH_mm };

		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			foreach (var rx in RegexList)
			{
				var m = rx.Match(value);
				if (m.Success)
				{
					var date = GetFutureDate(m.Groups["Day"].Value.ToInt32());
					if (date.HasValue)
					{
						var dtime = date.Value;
						var hour = m.Groups["HourMinute"].Value.Substring(0, 2).ToInt32();
						var minute = m.Groups["HourMinute"].Value.Substring(2, 2).ToInt32();
						if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
						{
							return date.Value.AddHours(hour.Value).AddMinutes(minute.Value);
						}
					}
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_Mdd : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			if (value.Length == 3)
			{
				var month = value.Substring(0, 1).ToInt32();
				var day = value.Substring(1, 2).ToInt32();
				if (month >= 1 && month <= 12)
				{
					var dtime = new DateTime(DateTime.Now.Year, month.Value, 1);
					if (DateTime.DaysInMonth(DateTime.Now.Year, dtime.Month) >= day)
					{
						return new DateTime(DateTime.Now.Year, month.Value, day.Value);
					}
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_MMdd : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public static readonly Regex MM_dd = new Regex("(?<Month>[\\d]{1,2})[-/月](?<Day>[\\d]{1,2})");

		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			if (value.Length == 4)
			{
				var month = value.Substring(0, 2).ToInt32();
				var day = value.Substring(2, 2).ToInt32();
				if (month >= 1 && month <= 12)
				{
					var dtime = new DateTime(DateTime.Now.Year, month.Value, 1);
					if (DateTime.DaysInMonth(DateTime.Now.Year, dtime.Month) >= day)
					{
						return new DateTime(DateTime.Now.Year, month.Value, day.Value);
					}
				}
			}
			var m = MM_dd.Match(value);
			if (m.Success)
			{
				var month = m.Groups["Month"].Value.ToInt32();
				var day = m.Groups["Day"].Value.ToInt32();
				if (month > 0 && month < 13 &&
					day > 0 && day < 32)
				{
					var dateText = String.Format("{0}/{1}/{2}", DateTime.Now.Year, month, day);
					var dtime = DateTime.Now;
					if (DateTime.TryParse(dateText, out dtime))
					{
						return dtime;
					}
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_MMddHH : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public static readonly Regex MM_dd_HH = new Regex("(?<Month>[\\d]{1,2})[-/月](?<Day>[\\d]{1,2})[日\\s](?<Hour>[\\d]{1,2})");

		public DateDirection DateDirection { get; set; } = DateDirection.Future;

		public NumberToDateTimeConverter_MMddHH(DateDirection dateDirection)
		{
			this.DateDirection = dateDirection;
		}
		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			var m = MM_dd_HH.Match(value);
			if (m.Success)
			{
				var month = m.Groups["Month"].Value.ToInt32();
				var day = m.Groups["Day"].Value.ToInt32();

				if (month.HasValue && day.HasValue)
				{
					var date = String.Format("{0}/{1}/{2}", DateTime.Now.Year, month.Value, day.Value).ToDateTime();
					if (date.HasValue)
					{
						switch (this.DateDirection)
						{
							case DateDirection.Past:
								if (date > DateTime.Now)
								{
									date = String.Format("{0}/{1}/{2}", DateTime.Now.Year - 1, month.Value, day.Value).ToDateTime();
								}
								break;
							case DateDirection.Future:
								if (date < DateTime.Now)
								{
									date = String.Format("{0}/{1}/{2}", DateTime.Now.Year + 1, month.Value, day.Value).ToDateTime();
								}
								break;
							default: throw SwitchStatementNotImplementException.Create(this.DateDirection);
						}
						if (date.HasValue)
						{
							var dtime = date.Value;
							var hour = m.Groups["Hour"].Value.ToInt32();
							var s = String.Format("{0}/{1}/{2} {3}:00", dtime.Year, dtime.Month, dtime.Day, hour);
							if (DateTime.TryParse(s, out dtime))
							{
								return dtime;
							}
						}
					}
				}
			}
			return null;
		}
	}
	public class NumberToDateTimeConverter_MMddHHmm : NumberToDateTimeConverter, INumberToDateTimeConverter
	{
		public static readonly Regex MM_dd_HHmm = new Regex("(?<Month>[\\d]{1,2})[-/月](?<Day>[\\d]{1,2})[日\\s](?<HourMinute>[\\d]{4})");
		public static readonly Regex MM_dd_HH_mm = new Regex("(?<Month>[\\d]{1,2})[-/月](?<Day>[\\d]{1,2})[日\\s](?<HourMinute>[\\d]{1,2}:[\\d]{1,2})");
		public static readonly Regex[] RegexList = new Regex[] { MM_dd_HHmm, MM_dd_HH_mm };

		public DateDirection DateDirection { get; set; } = DateDirection.Future;
		
		public NumberToDateTimeConverter_MMddHHmm(DateDirection dateDirection)
		{
			this.DateDirection = dateDirection;
		}
		public DateTime? Convert(string value, TimeOnly timeZone)
		{
			foreach (var rx in RegexList)
			{
				var m = rx.Match(value);
				if (m.Success)
				{
					var month = m.Groups["Month"].Value.ToInt32();
					var day = m.Groups["Day"].Value.ToInt32();

					if (month.HasValue && day.HasValue)
					{
						var date = String.Format("{0}/{1}/{2}", DateTime.Now.Year, month.Value, day.Value).ToDateTime();
						if (date.HasValue)
						{
							switch (this.DateDirection)
							{
								case DateDirection.Past:
									if (date > DateTime.Now)
									{
										date = String.Format("{0}/{1}/{2}", DateTime.Now.Year - 1, month.Value, day.Value).ToDateTime();
									}
									break;
								case DateDirection.Future:
									if (date < DateTime.Now)
									{
										date = String.Format("{0}/{1}/{2}", DateTime.Now.Year + 1, month.Value, day.Value).ToDateTime();
									}
									break;
								default: throw SwitchStatementNotImplementException.Create(this.DateDirection);
							}
							if (date.HasValue)
							{
								var dtime = date.Value;
								var hour = m.Groups["HourMinute"].Value.Substring(0, 2).ToInt32();
								var minute = m.Groups["HourMinute"].Value.Substring(2, 2).ToInt32();
								var s = String.Format("{0}/{1}/{2} {3}:{4}", dtime.Year, dtime.Month, dtime.Day, hour, minute);
								if (DateTime.TryParse(s, out dtime))
								{
									return dtime;
								}
							}
						}
					}
				}
			}
			return null;
		}
	}
    public class NumberToDateTimeConverter_yyyyMMdd : NumberToDateTimeConverter, INumberToDateTimeConverter
    {
        public static readonly Regex yyyy_MM_dd = new Regex("(?<Year>[\\d]{2,4})[-/年](?<Month>[\\d]{1,2})[-/月](?<Day>[\\d]{1,2})[日\\s]");

        public DateTime? Convert(string value, TimeOnly timeZone)
        {
            var m = yyyy_MM_dd.Match(value);
            if (m.Success)
            {
                var year = m.Groups["Year"].Value.ToInt32();
                var month = m.Groups["Month"].Value.ToInt32();
                var day = m.Groups["Day"].Value.ToInt32();

                if (month.HasValue && day.HasValue)
                {
                    var date = String.Format("{0}/{1}/{2}", year, month.Value, day.Value).ToDateTime();
                    if (date.HasValue)
                    {
						return date;
                    }
                }
            }
            if (value.Length == 8)
            {
                var year = value.Substring(0, 4).ToInt32();
                var month = value.Substring(4, 2).ToInt32();
                var day = value.Substring(6, 2).ToInt32();
                if (year.HasValue && month >= 1 && month <= 12)
                {
                    var dtime = new DateTime(year.Value, month.Value, 1);
                    if (day <= DateTime.DaysInMonth(year.Value, dtime.Month))
                    {
                        return new DateTime(year.Value, month.Value, day.Value);
                    }
                }
            }
            return null;
        }
    }
}
