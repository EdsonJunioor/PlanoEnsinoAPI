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
    public class SugestaoPlanoEnsinoController : ControllerBase
    {
        private readonly IRepository repository;

        public SugestaoPlanoEnsinoController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarSugestaoPlanosEnsino()
        {
            var result = await this.repository.GetAllSugestaoPlanoEnsinoAsync();
            return Ok(result);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscarSugestaoPlanoEnsinoById(int id)
        {
            try
            {
                var retorno = await this.repository.GetSugestaoPlanoEnsinoByIdAsync(id);

                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound("Sugestão de Plano de ensino não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Sugestão de Plano de Ensino Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarSugestaoPlanoEnsino([FromBody] SugestaoPlanoEnsino sugestaoPlanoEnsinoModel)
        {
            try
            {
                repository.Add(sugestaoPlanoEnsinoModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(sugestaoPlanoEnsinoModel);
                }
                else
                {
                    return BadRequest("Erro ao salvar Sugestão de Plano de Ensino.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditarSugestaoPlanoEnsino(int id, [FromBody] SugestaoPlanoEnsino sugestaoPlanoEnsinoModel)
        {
            try
            {
                var retorno = await repository.GetSugestaoPlanoEnsinoByIdAsync(id);

                if (retorno != null)
                {
                    repository.Update(sugestaoPlanoEnsinoModel);                    //para criar a sugestão PE podemos editao e nao passar o id no json
                    await repository.SaveChangesAsync();
                    return Ok("Sugestao de Plano de Ensino atualizado com sucesso.");
                }
                else
                {
                    return NotFound("Sugestao de Plano de Ensino não encontrado.");

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
