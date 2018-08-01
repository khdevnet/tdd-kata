using System.Collections.Generic;
using BankCredit.WebApi.Models;


namespace BankCredit.Tests.Comparers
{
    internal class MessageModelComparer : BaseModelComparer<MessageModel>, IEqualityComparer<MessageModel>
    {
        public bool Equals(MessageModel x, MessageModel y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return x.Message == y.Message;
        }
    }
}