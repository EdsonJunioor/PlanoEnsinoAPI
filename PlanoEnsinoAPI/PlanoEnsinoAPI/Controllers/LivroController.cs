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

        [HttpPost, Route("livroAutor/{cdAutor}")]
        public async Task<IActionResult> SalvarLivro(Livro livroModel, int cdAutor)
        {
            try
            {
                var autor = await repository.GetAutorByIdAsync(cdAutor);

                if (autor != null)
                {
                    repository.Add(livroModel);

                    if (await repository.SaveChangesAsync())
                    {
                        var livroAutor = new LivroAutor()
                        {
                            CdLivro = livroModel.CdLivro,
                            CdAutor = autor.CdAutor
                        };

                        await SalvarLivroAutor(livroAutor);

                        return Ok("Livro salvo com sucesso.");
                    }
                    else
                    {
                        return BadRequest("Erro ao salvar livro.");
                    }
                }
                else
                {
                    return BadRequest("Erro ao salvar livro, autor não pode ser nulo.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditarLivro(int id, [FromBody] Livro livroModel)
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
