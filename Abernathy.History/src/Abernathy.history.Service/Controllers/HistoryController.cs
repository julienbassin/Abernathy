﻿using Abernathy.history.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private IHistoryService _historyService;
        [HttpGet()]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await _itemsRepo.GetAllAsync()).Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid Id)
        {
            var item = await _itemsRepo.GetAsync(Id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreatedItemDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var item = new Item
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            await _itemsRepo.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { item.Id }, item);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAsync(Guid Id, ItemDto updatedModel)
        {
            var existingItem = await _itemsRepo.GetAsync(Id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updatedModel.Name;
            existingItem.Description = updatedModel.Description;
            existingItem.Price = updatedModel.Price;

            await _itemsRepo.UpdateAsync(existingItem);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var existingItem = await _itemsRepo.GetAsync(Id);
            if (existingItem == null)
            {
                return NotFound();
            }

            await _itemsRepo.RemoveAsync(existingItem.Id);
            return NoContent();
        }
    }
}
