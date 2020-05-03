using System.Collections.Generic;

namespace ImportCsv.Api.Contracts
{
    public class BaseMessageException
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public IList<string> Errors { get; set; }
        public string Detailed { get; set; }
    }
}