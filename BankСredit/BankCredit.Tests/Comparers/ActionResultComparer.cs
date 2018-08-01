using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BankCredit.Tests.Comparers
{
    internal class ActionResultComparer<TModel> : IEqualityComparer<ObjectResult> where TModel : class
    {
        private readonly IEqualityComparer<TModel> modelEqualityComparer;

        public ActionResultComparer(IEqualityComparer<TModel> modelEqualityComparer)
        {
            this.modelEqualityComparer = modelEqualityComparer;
        }

        public bool Equals(ObjectResult x, ObjectResult y)
        {

            if (x == null || y == null)
            {
                return false;
            }

            if (!(x.Value is TModel) || !(y.Value is TModel))
            {
                return false;
            }

            return x.StatusCode == y.StatusCode
                && modelEqualityComparer.Equals((TModel)x.Value, (TModel)y.Value);
        }

        public int GetHashCode(ObjectResult actionResult)
        {
            return actionResult
                .GetType()
                .GetMembers()
                .Sum(m => m.GetHashCode());
        }
    }
}