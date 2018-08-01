using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCredit.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BankCredit.WebApi.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        public virtual bool IsModelValid(out IEnumerable<MessageModel> errors)
        {
            if (!ModelState.IsValid)
            {
                errors = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(modelError => GetMessage(modelError))
                    .Select(e => new MessageModel() { Message = e })
                    .ToArray();
                return false;
            }
            errors = Enumerable.Empty<MessageModel>();
            return true;
        }

        private static string GetMessage(ModelError modelError) =>
            !String.IsNullOrEmpty(modelError.ErrorMessage)
            ? modelError.ErrorMessage
            : modelError.Exception?.Message;
    }
}