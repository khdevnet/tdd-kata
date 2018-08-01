using System.Collections.Generic;
using BankCredit.WebApi.Models;

namespace BankCredit.Tests.Comparers
{
    internal class ResponseModelDataComparer<TData> : ResponseModelComparer, IEqualityComparer<ResponseModel<TData>> where TData : class
    {
        private readonly IEqualityComparer<TData> modelEqualityComparer;

        public ResponseModelDataComparer(IEqualityComparer<TData> modelEqualityComparer, IEqualityComparer<MessageModel> messageModelEqualityComparer) : base(messageModelEqualityComparer)
        {
            this.modelEqualityComparer = modelEqualityComparer;
        }

        public bool Equals(ResponseModel<TData> x, ResponseModel<TData> y)
        {
            if (x == null || y == null)
            {
                return false;
            }


            if (!(x.Data is TData) || !(y.Data is TData))
            {
                return false;
            }

            return DataEqual(x.Data, y.Data) && Equals(x, y);
        }

        private bool DataEqual(TData x, TData y)
        {
            return x != null && y != null
                ? modelEqualityComparer.Equals(x, y)
               : true;
        }

        public int GetHashCode(ResponseModel<TData> actionResult)
        {
            return modelEqualityComparer.GetHashCode() + GetHashCode((ResponseModel)actionResult);
        }
    }
}