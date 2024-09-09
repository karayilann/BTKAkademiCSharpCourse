﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Northwind.Business.Utilities
{
    public static class ValidationTools
    {
        public static void Validater(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (result.Errors.Count > 0) throw new ValidationException(result.Errors);
        }

    }
}
