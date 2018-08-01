using System;
using System.Collections.Generic;
using System.Linq;
using BankCredit.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankCredit.Tests.Comparers
{
    internal class BaseModelComparer<TModel> where TModel : class
    {
        public int GetHashCode(TModel model)
        {
            return model
                .GetType()
                .GetMembers()
                .Sum(m => m.GetHashCode());
        }
    }
}