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
    public class AutorController : ControllerBase
    {
        private readonly IRepository repository;
        public AutorController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAutores()
        {
            var result = await this.repository.GetAllAutorAsync();
            return Ok(result);
        }


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscarAutorById(int id)
        {
            try
            {
                var retorno = await this.repository.GetAutorByIdAsync(id);

                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound("Autor não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Autor Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarAutor([FromBody] Autor autorModel)
        {
            try
            {
                repository.Add(autorModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(autorModel);
                }
                else
                {
                    return BadRequest("Erro ao salvar curso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditarAutor(int id, [FromBody] Autor autorModel)
        {
            try
            {
                var retorno = await repository.GetAutorByIdAsync(id);

                if (retorno != null)
                {
                    repository.Update(autorModel);
                    await repository.SaveChangesAsync();
                    return Ok("Autor atualizado com sucesso.");
                }
                else
                {
                    return NotFound("Autor não encontrado.");

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

    }
}