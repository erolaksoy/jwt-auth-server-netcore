using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Services;

namespace WorkJwtExampleServer.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FlashCardsController : CustomBaseController
    {
        private readonly IGenericService<FlashCard,FlashCardDto> _service;
        public FlashCardsController(IGenericService<FlashCard,FlashCardDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return ActionResultInstance(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlashCard(FlashCardDto flashCardDto)
        {
            var result = await _service.AddAsync(flashCardDto);
            return ActionResultInstance(result);
        }
    }
}
