//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bank_app.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class favourite_payment
    {
        public int id_fav_pay { get; set; }
        public int id_account { get; set; }
        public int id_reciever { get; set; }
        public decimal money { get; set; }
    
        public virtual account account { get; set; }
    }
}
