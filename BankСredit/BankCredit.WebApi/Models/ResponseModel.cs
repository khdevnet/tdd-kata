using System.Collections.Generic;

namespace BankCredit.WebApi.Models
{
    public class ResponseModel<TData> : ResponseModel
    {
        public TData Data { get; set; }
    }

    public class ResponseModel
    {
        public IEnumerable<MessageModel> Errors { get; set; }
    }
}