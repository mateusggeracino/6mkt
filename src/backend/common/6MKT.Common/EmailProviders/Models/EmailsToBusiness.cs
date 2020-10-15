using System;
using System.Collections;
using System.Collections.Generic;

namespace _6MKT.Common.EmailProviders.Models
{
    public class EmailsToBusiness : BaseEmail
    {
        public string PurchaseTitle { get; set; }
        public string SubcategoryName { get; set; }
        public IEnumerable<Tuple<string, string>> Emails { get; set; }
    }
}