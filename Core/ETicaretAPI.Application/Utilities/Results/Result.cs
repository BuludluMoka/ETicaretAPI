namespace Core.Application.Utilities.Results
{
    public class Result
    {
        private object _data;

        public Result(string message)
        {
            Message = message;

        }

        public Result(object data, ResultInfo resultInfo)
        {
            Data = data;
            ResultInfo = resultInfo;
        }

        public Result(ResultInfo resultInfo)
        : this(null, resultInfo)
        {

        }
    


        public Result()
            : this(ResultInfo.NotImplemented)
        {
            
        }

        public int StatusCode { get; set; }

        public bool Status { get; set; }
        public string Message { get; set; }
        public ResultInfo ResultInfo { get; set; }

        public object Data
        {
            get => _data;

            set
            {
                if (value != null 
                    && ResultInfo == ResultInfo.NotImplemented)
                {
                    ResultInfo = ResultInfo.Success;
                }

                _data = value;
            }
        }
    }
}