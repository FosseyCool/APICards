using System;
using System.Collections.Generic;
using APICards.Data;
using APICards.Models;

namespace APICards
{
    public class CardRepository : ICardRepository
    {
       // private List<Card> cards = new List<Card>();

        private CardContext _context;

        /*
        public CardRepository()
        {
            Add(new Card { Id = new Guid(), Name = "АльфаБанк", Person = "Иван Иванов Иванович", Type = "Visa" });
            Add(new Card { Id = new Guid(), Name = "СберБанк", Person = "Васян Васянов Васянович", Type = "Visa" });
        }
        */
        public CardRepository(CardContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Card> GetAll()
        {
            return _context.Cards;
        }

        public Card Get(Guid id)
        {
            return _context.Cards.Find(id);
        }

        public void Create(Card item)
        {
            _context.Cards.Add(item);
            _context.SaveChanges();
        }

        public void Update(Card item)
        {
            Card currentCard = Get(item.Id);
            currentCard.IsComplete = item.IsComplete;
            currentCard.Name = item.Name;
            currentCard.Type = item.Type;
            currentCard.Person = item.Person;

            _context.Cards.Update(currentCard);
            _context.SaveChanges();
        }

        public Card Delete(Guid id)
        {
            Card card = Get(id);
            if (card!=null)
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
            }

            return card;
        }

        
    }
}