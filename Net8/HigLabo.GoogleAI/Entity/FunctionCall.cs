namespace HigLabo.GoogleAI
{
    public class FunctionCall
    {
        public string Name { get; set; } = "";
        public object Args { get; set; } = new();

        public override string ToString()
        {
            return $"{this.Name}({this.Args})";
        }
    }
}
