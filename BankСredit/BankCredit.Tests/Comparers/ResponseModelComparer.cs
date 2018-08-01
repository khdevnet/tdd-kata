using System.Collections.Generic;
using System.Linq;
using BankCredit.WebApi.Models;

namespace BankCredit.Tests.Comparers
{
    internal class ResponseModelComparer : IEqualityComparer<ResponseModel>
    {
        private readonly IEqualityComparer<MessageModel> messageModelEqualityComparer;

        public ResponseModelComparer(IEqualityComparer<MessageModel> messageModelEqualityComparer)
        {
            this.messageModelEqualityComparer = messageModelEqualityComparer;
        }

        public virtual bool Equals(ResponseModel x, ResponseModel y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return ErrorsEqual(x, y);
        }

        private bool ErrorsEqual(ResponseModel x, ResponseModel y)
        {
            return x.Errors != null && y.Errors != null
                ? x.Errors.SequenceEqual(y.Errors, messageModelEqualityComparer)
               : true;
        }

        public int GetHashCode(ResponseModel actionResult)
        {
            return messageModelEqualityComparer.GetHashCode();
        }
    }
}