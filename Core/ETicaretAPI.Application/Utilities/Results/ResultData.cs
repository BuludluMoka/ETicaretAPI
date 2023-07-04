namespace Core.Application.Utilities.Results
{
    public class ResultData : IResultData
    {

        public object Data { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public bool Status { get; set; }
    }
}