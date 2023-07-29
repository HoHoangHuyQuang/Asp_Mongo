namespace Product_Api.Data;
public interface IProductDatabaseSettings
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}
public class ProductDatabaseSettings: IProductDatabaseSettings
{
    // public string ProductsCollectionName { get; set; } 
    // public string CategorysCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }

}

/*
insert to appsettings.json
  "ProductDatabase": {   
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "ur db name"
  }
*/