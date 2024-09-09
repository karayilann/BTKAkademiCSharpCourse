namespace EntitiyFrameworkDemo
{
    // Entitiy Framework'ta en öenmli kurallardan birisi database karşılık gelen bir class olmasıdır.


    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
