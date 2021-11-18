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
        public async Task<IActionResult> SalvarLivro([FromBody] Livro livroModel)
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

        public async Task<ActionResult> SalvarLivroAutor(LivroAutor livroAutorModel)
        {
            try
            {
                var livro = await repository.GetLivroByIdAsync(livroAutorModel.CdLivro);
                var autor = await repository.GetAutorByIdAsync(livroAutorModel.CdAutor);
                if(livro != null && autor != null)
                {
                    repository.Add(livroAutorModel);

                    if (await repository.SaveChangesAsync())
                    {
                        return Ok(livroAutorModel);
                    }
                    else
                    {
                        return BadRequest("Erro ao salvar cdLivro e cdAutor.");
                    }
                }
                else
                {
                    return BadRequest("Erro ao salvar cdLivro e cdAutor, algum registro está nulo.");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro exception:{e.Message}");
            }
        }
    }
}
