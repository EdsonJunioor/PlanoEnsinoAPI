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

        [HttpDelete, Route("{cdLivro}/{cdAutor}")]
        public async Task<IActionResult> ApagarLivroAutor(int cdLivro, int cdAutor)
        {
            try
            {
                var resulta = await this.repository.GetLivroAutorByIdAsync(cdLivro, cdAutor);

                if (resulta != null)
                {
                    repository.Delete(resulta);
                    await repository.SaveChangesAsync();
                    return Ok("O livro e autor foram desconectados com sucesso!");
                }
                else
                {
                    return BadRequest("Erro ao desconectar livro e autor.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}