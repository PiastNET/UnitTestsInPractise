﻿
namespace Mocking
{
    public class Invoice
    {
        public decimal TotalValue { get; set; }
        public string DocumentNumber { get; set; }

        public bool IsNew { get; set; }
        public bool IsDirty { get; set; }
    }
}
