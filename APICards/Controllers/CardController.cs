using System;
using System.Collections.Generic;
using APICards.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICards.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private ICardRepository _repository;

        public CardController(ICardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllItems")]
        public IEnumerable<Card> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Card card)
        {
            if (card==null)
            {
                return BadRequest("Заполни карту");
            }
            _repository.Create(card);
            return CreatedAtRoute("GetCard", new { id = card.Id }, card);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid guid, [FromBody] Card updatedCard)
        {
            if (updatedCard==null || updatedCard.Id!=guid)
            {
                return BadRequest();
            }

            var item = _repository.Get(guid);
            
            if (updatedCard==null)
            {
                return NotFound();
            }

            _repository.Update(updatedCard);
            return RedirectToRoute("GetAllItems");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid guid)
        {
            var deletedCard = _repository.Delete(guid);
            if (deletedCard == null)
            {
                return BadRequest();
            }
            return new ObjectResult(deletedCard);

        }
    }
}