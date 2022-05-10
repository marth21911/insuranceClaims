using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace insuranceClaims.Models
{
    public class NewInventory
    {
        [Key]
        public int ItemId {get;set;}
        public int OriginalId {get;set;}
        [Required]
        public string ProductName {get;set;}
        public string Room {get;set;}
        [Required]
        public int QuantityBought {get;set;}
        [Required]
        public decimal UnitPrice {get;set;}
        public string ReceiptName {get;set;}
        [Required]
        public string ReceiptData {get;set;}
        public decimal Recovered {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}