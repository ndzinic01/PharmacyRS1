using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using NewPharmacy.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;

//namespace NewPharmacy.Data.Models
//{
//    public class Order
//    {
//        [Key]
//        public int Id { get; set; }
//        public DateTime OrderDate { get; set; }
//        public string Status { get; set; }
//        public double TotalPrice { get; set; }


//        [ForeignKey(nameof(MyAppUser))]
//        public int MyAppUserId { get; set; }
//        public MyAppUser? MyAppUser { get; set; }


//        [ForeignKey(nameof(Supplier))]
//        public int SupplierId { get; set; }
//        public Supplier? Supplier { get; set; }
//    }
//}

namespace NewPharmacy.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }


        [ForeignKey(nameof(MyAppUser))]
        public int MyAppUserId { get; set; }
        public MyAppUser? MyAppUser { get; set; }


        // Foreign Key for Supplier
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}