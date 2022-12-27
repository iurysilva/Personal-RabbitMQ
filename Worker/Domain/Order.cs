﻿namespace Worker.Domain.Models
{
    public sealed class Order
    {
        public int OrderNumber { get; set; }
        public string? ItemName { get; set; }
        public float Price { get; set; }
    }
}
