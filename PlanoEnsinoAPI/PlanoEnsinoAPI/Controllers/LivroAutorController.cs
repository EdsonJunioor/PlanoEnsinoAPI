using Microsoft.AspNetCore.Mvc;
using PlanoEnsinoAPI.Data;
using PlanoEnsinoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroAutorController : ControllerBase
    {
        private readonly IRepository repository;
        public LivroAutorController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarLivros()
        {
            var result = await this.repository.GetAllLivroAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarLivroAutor([FromBody] LivroAutor livroAutorModel)
        {
            try
            {
                repository.Add(livroAutorModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(livroAutorModel);
                }
                else
                {
                    return BadRequest("Erro ao linkar livro e autor.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarLivro([FromBody] Livro livroModel)
        {
            try
            {
                repository.Update(livroModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok("Livro atualizado com sucesso.");
                }
                else
                {
                    return NotFound("Livro não encontrado.");

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> ApagarLivroAutor([FromBody] LivroAutor livroAutorModel)
        {
            try
            {
                repository.Delete(livroAutorModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(livroAutorModel);
                }
                else
                {
                    return BadRequest("Erro ao apagar a ligação entre livro e autor.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}