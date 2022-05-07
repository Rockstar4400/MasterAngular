using DataAccess.Generic;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToysController : ControllerBase
    {
        private readonly IGenericRepository<Toy> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ToysController(IGenericRepository<Toy> genericRepository, IUnitOfWork unitOfWork)
        {
            this._genericRepository = genericRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Toy>> Get()
        {
            return await _genericRepository.GetAsync(a => a.AgeRestriction > 0, a => a.OrderByDescending(b => b.AgeRestriction), "Company");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _genericRepository.CreateAsync(toy);

                if (created)
                _unitOfWork.Commit();

            return Created("Created", new { Response = StatusCode(201) });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updated = await _genericRepository.UpdateAsync(toy);

            if (updated)
                _unitOfWork.Context.Attach(toy);

            return Created("Updated", new { Response = StatusCode(204) });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _genericRepository.DeleteAsync(toy);

            if (created)
                _unitOfWork.Context.Remove(toy);

            return Created("Deleted", new { Response = StatusCode(204) });
        }

    }
}
