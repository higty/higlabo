namespace HigLabo.Core;
public class YearMonth
{
    public int? Year {  get; set; }
    public int? Month { get; set; }

    public DateInfoType? GetDateInfoType()
    {
        if (this.Year.HasValue && this.Month.HasValue)
        {
            return DateInfoType.YearMonth;
        }
        else if (this.Year.HasValue && this.Month.HasValue == false)
        {
            return DateInfoType.Year;
        }
        if (this.Year.HasValue == false && this.Month.HasValue)
        {
            return null;
        }
        else
        {
            return null;
        }
    }
    public DateOnly? GetDateOnly()
    {
        if (this.Year.HasValue && this.Month.HasValue)
        {
            return new DateOnly(this.Year.Value, this.Month.Value, 1);
        }
        else if (this.Year.HasValue && this.Month.HasValue == false)
        {
            return new DateOnly(this.Year.Value, 1, 1);
        }
        if (this.Year.HasValue == false && this.Month.HasValue)
        {
            return null;
        }
        else
        {
            return null;
        }
    }
    public override string ToString()
    {
        if (this.Year.HasValue && this.Month.HasValue)
        {
            return $"{this.Year.Value.ToString("0000")}/{this.Month.Value.ToString("00")}";
        }
        else if (this.Year != null && this.Month == null)
        {
            return "Year: " +  this.Year.Value.ToString("0000");
        }
        else if (this.Year == null && this.Month != null)
        {
            return "Month: " + this.Month.Value.ToString();
        }
        return "";
    }
}
