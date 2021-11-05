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
    public class LivroController : ControllerBase
    {
        private readonly IRepository repository;
        public LivroController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarLivros()
        {
            var result = await this.repository.GetAllLivroAsync();
            return Ok(result);
        }


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscarLivroById(int id)
        {
            try
            {
                var retorno = await this.repository.GetLivroByIdAsync(id);

                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound("Livro não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Livro Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarLivro([FromBody] Livro livroModel)
        {
            try
            {
                repository.Add(livroModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(livroModel);
                }
                else
                {
                    return BadRequest("Erro ao salvar livro.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditarUsuario(int id, [FromBody] Livro livroModel)
        {
            try
            {
                var retorno = await repository.GetLivroByIdAsync(id);

                if (retorno != null)
                {
                    repository.Update(livroModel);
                    await repository.SaveChangesAsync();
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


        [HttpPost, Route("livroAutor")]
        public async Task<ActionResult> SalvarLivroAutor([FromBody] LivroAutor livroAutorModel)
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
                    return BadRequest("Erro ao salvar CdLivro e CdAutor.");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro:{e.Message}");
            }
        }
    }
}
