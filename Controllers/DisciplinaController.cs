using Microsoft.AspNetCore.Http;
 
using Microsoft.AspNetCore.Mvc;
using pifinal.Models;

namespace pifinal.Controllers;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public DisciplinaController(DataBaseContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult listAll()
        {
             DateTime localDate = DateTime.Now;

            return Ok(_context.Disciplina.Select( 
                c => new Disciplina{
                nome = c.nome,
                id = c.id,
                sigla = c.sigla,
                created_at = c.created_at ??  localDate.ToString()
            }).ToList()
            );
        }

        [HttpPost]
        public async Task<IActionResult> add([FromForm]Disciplina payload)
        {
            
            _context.Disciplina.Add(payload);

           return await _context.SaveChangesAsync() > 0 ? Ok(payload): BadRequest("Erro ao cadastrar Dsciplina");
        }

          [HttpPut]
        public async Task<IActionResult> update([FromForm]Disciplina payload)
        {
            _context.Disciplina.Update(payload);

           return await _context.SaveChangesAsync() > 0 ? Ok(_context.Disciplina.FirstOrDefault(p => p.id == payload.id)): BadRequest("Erro ao cadastrar Dsciplina");
        }

          [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            Disciplina dados = _context.Disciplina.FirstOrDefault(p => p.id == id);
             if (dados == null)
            {
                return BadRequest("Disciplina não encontrada");
            }

            _context.Remove(dados);

           return await _context.SaveChangesAsync() > 0 ? Ok("Disciplina atualizada com sucesso!"): BadRequest("Erro ao cadastrar Dsciplina");
        }

    }
