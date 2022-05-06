using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace insuranceClaims.Models
{
    public class OriginalInventory
    {
        [Key]
        public int ID {get;set;}
        public int UniqueID {get;set;}
        public string OldProduct {get;set;}
        public string Room {get;set;}
        public int QuantityL {get;set;}
        public decimal UnitPrice {get;set;}
        public decimal Tax {get;set;}
        public decimal Retail {get;set;}
        public decimal Depreciation {get;set;}
        public decimal ACV {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;}= DateTime.Now;
    }
}