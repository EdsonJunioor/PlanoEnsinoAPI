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
    public class AvaliacaoController : ControllerBase
    {
        private readonly IRepository repository;

        public AvaliacaoController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAvaliacoes()
        {
            var result = await this.repository.GetAllAvaliacaoAsync();
            return Ok(result);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscarAvaliacaoById(int id)
        {
            try
            {
                var retorno = await this.repository.GetAvaliacaoByIdAsync(id);

                if (retorno != null)
                {
                    return Ok(retorno.Nome.ToLower());
                }
                else
                {
                    return NotFound("Avaliacao não encontrada.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Avalicao Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarAvaliacao([FromBody] Avaliacao avalicaoModel)
        {
            try
            {
                repository.Add(avalicaoModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(avalicaoModel);
                }
                else
                {
                    return BadRequest("Erro ao salvar avaliacao.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditarAvaliacao(int id, [FromBody] Avaliacao avaliacaoModel)
        {
            try
            {
                var retorno = await repository.GetAvaliacaoByIdAsync(id);

                if (retorno != null)
                {
                    repository.Update(avaliacaoModel);                    //para criar a sugestão PE podemos editao e nao passar o id no json
                    await repository.SaveChangesAsync();
                    return Ok("Avaliacao atualizada com sucesso.");
                }
                else
                {
                    return NotFound("Avaliacao não encontrada.");

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
