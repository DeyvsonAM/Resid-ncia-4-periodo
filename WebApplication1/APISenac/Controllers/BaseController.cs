using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services.Interfaces;
using APISenac.Models;

namespace APISenac.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T, TDTO> : ControllerBase
        where T : BaseEntity
        where TDTO : class
    {
        private readonly IBaseService<T> _service;
        private readonly IMapper _mapper;

        public BaseController(IBaseService<T> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        


        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] TDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var entity = _mapper.Map<T>(dto);
                await _service.CreateAsync(entity);
                return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao criar a entidade", details = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var dto = _mapper.Map<TDTO>(entity);
            return Ok(dto);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await _service.GetAllAsync(); // Chama o método GetAllAsync do serviço.
                var Models = _mapper.Map<List<T>>(entities); // Mapeia as entidades para os DTOs.
                return Ok(Models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao obter as entidades", details = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEntity(Guid id, [FromBody] TDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<T>(dto);
            var updatedEntity = await _service.UpdateAsync(id, entity);

            if (updatedEntity == null)
                return NotFound();

            return Ok(updatedEntity);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEntity(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }


        [HttpPut("Inactive{id:guid}")]
        public async Task<IActionResult> Inactive(Guid id)
        {
            // Chama o serviço para inativar o sistema
            var result = await _service.InactiveAsync(id);

            if (result)
            {
                // Retorna status 200 OK se a inativação foi bem-sucedida
                return Ok(new { message = "Sistema inativado com sucesso!" });
            }
            
            // Retorna status 404 Not Found se a entidade não foi encontrada
            return NotFound(new { message = "Sistema não encontrado!" });
        }
    }
}
