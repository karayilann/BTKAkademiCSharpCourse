
ProductDirector director = new ProductDirector(new NewProductBuilder());
director.Construct();

Console.WriteLine("\n=====================================\n");

ProductDirector oldDirector = new ProductDirector(new OldProductBuilder());
oldDirector.Construct();



public class ProductViewModel
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int DiscountAmount { get; set; }
    public bool isDiscountApplied { get; set; }
    public string CategoryName { get; set; }
}


abstract class ProductBuilder
{
    public abstract void GetProductData();
    public abstract void ApplyDiscount();
    public abstract ProductViewModel GetProduct();
}


class NewProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();
    public override void GetProductData()
    {
        model.Id = 1;
        model.CategoryName = "Electronics";
        model.ProductName = "Laptop";
        model.UnitPrice = 50000;
    }

    public override void ApplyDiscount()
    {
        model.DiscountAmount = 10;
        model.UnitPrice -= ((model.UnitPrice / 100) * model.DiscountAmount);
        model.isDiscountApplied = true;
    }

    public override ProductViewModel GetProduct() => model;
}



class OldProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();
    public override void GetProductData()
    {
        model.Id = 1;
        model.CategoryName = "Electronics";
        model.ProductName = "Old Laptop";
        model.UnitPrice = 50000;

    }

    public override void ApplyDiscount()
    {
        model.DiscountAmount = 0;
        model.isDiscountApplied = false;
    }

    public override ProductViewModel GetProduct() => model;
}


class ProductDirector
{
    private ProductBuilder _builder;
    public ProductDirector(ProductBuilder builder)
    {
        _builder = builder;
    }

    public void Construct()
    {
        _builder.GetProductData();
        Console.WriteLine("Product Name: " + _builder.GetProduct().ProductName);
        Console.WriteLine("Product Price: " + _builder.GetProduct().UnitPrice);
        Console.WriteLine("Product Category: " + _builder.GetProduct().CategoryName);
        
        _builder.ApplyDiscount();
        Console.WriteLine("Discount Applied: " + _builder.GetProduct().isDiscountApplied);
        Console.WriteLine("After discount price : " + _builder.GetProduct().UnitPrice);

    }
}
