﻿namespace WebAPI.Domain.Models
{
    public sealed class Order
    {
        public int OrderId { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
    }
}
