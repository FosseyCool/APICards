using System;
using System.Collections.Generic;
using APICards.Models;

namespace APICards
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll();

        Card Get(Guid id);

        void Create(Card item);

        void Update(Card item);
        Card Delete(Guid id);

       
    }
}