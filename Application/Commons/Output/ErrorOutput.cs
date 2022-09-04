namespace Application.Commons.Output
{
    public class ErrorOutput
    {
        public ErrorOutput(string error, string property)
        {
            Error = error;
            Property = property;
        }

        public string Error { get; set; }
        public string Property { get; set; }
    }
}
