using System.ComponentModel.DataAnnotations;

namespace ShopEzy.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public Transaction()
        {
        }

        public Transaction(int customerId, int productId, int quantity, decimal price, DateTime date)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            Date = date;
        }

        public override string ToString()
        {
            return $"Transaction Id: {Id}, Customer Id: {CustomerId}, Product Id: {ProductId}, Quantity: {Quantity}, Price: {Price}, Date: {Date}";
        }
    }
}
