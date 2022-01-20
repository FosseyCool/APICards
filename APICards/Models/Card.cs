using System;

namespace APICards.Models
{
    public class Card
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
        
        public string Type { get; set; }

        public string Person { get; set; }
        
        public bool IsComplete { get; set; }
    }
}