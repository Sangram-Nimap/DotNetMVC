namespace Vidly.Models
{
    public class ProductList
   
            public List<Products> ProductData { get; set; }

            public int CurrentPageIndex { get; set; }


            public int PageCount { get; set; }

        }
        public class Products
        {

            public long ProductId { get; set; }

            public string ProductName { get; set; }

            public long CategoryId { get; set; }

            public string CategoryName { get; set; }

        }
    }