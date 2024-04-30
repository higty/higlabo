using HigLabo.Core;

namespace HigLabo.GoogleAI
{
    public class Condition
    {
        public Operator Operator { get; set; }
        public string? StringValue {  get; set; }
        public double? NumericValue { get; set; }

        public override string ToString()
        {
            if (this.StringValue != null && this.NumericValue.HasValue)
            {
                return $"{this.Operator.ToStringFromEnum()} {this.StringValue} {this.NumericValue}";
            }
            if (this.StringValue != null)
            {
                return $"{this.Operator.ToStringFromEnum()} {this.StringValue}";
            }
            if (this.NumericValue.HasValue)
            {
                return $"{this.Operator.ToStringFromEnum()} {this.NumericValue}";
            }
            return "";
        }
    }
}
