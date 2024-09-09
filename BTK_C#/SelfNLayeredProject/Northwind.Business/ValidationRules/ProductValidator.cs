using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Entities.Concrete;

namespace Northwind.Business.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
        
            RuleFor(p=> p.ProductName).NotEmpty().WithMessage("Product Name is required");
            RuleFor(p=> p.CategoryId).NotEmpty();
            RuleFor(p=> p.QuantityPerUnit).NotEmpty(); 
            RuleFor(p=> p.UnitPrice).NotEmpty();
            RuleFor(p=> p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            //RuleFor(p=>p.UnitPrice).GreaterThan(10).When(p=>p.CategoryId==2);

            // Custom kural tanımlama
            //RuleFor(p=>p.ProductName).Must(StartWithA).WithMessage("Product Name must start with A");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
