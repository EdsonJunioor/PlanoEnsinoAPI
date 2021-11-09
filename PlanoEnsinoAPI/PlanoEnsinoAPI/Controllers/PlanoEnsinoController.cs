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
    public class PlanoEnsinoController : ControllerBase
    {
        private readonly IRepository repository;

        public PlanoEnsinoController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPlanosEnsino()
        {
            var result = await this.repository.GetAllPlanoEnsinoAsync();
            return Ok(result);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscarPlanoEnsinoById(int id)
        {
            try
            {
                var retorno = await this.repository.GetPlanoEnsinoByIdAsync(id);

                if (retorno != null)
                {
                    return Ok(retorno.DsDisciplina.ToLower());
                }
                else
                {
                    return NotFound("Plano de ensino não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Plano de Ensino Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarPlanoEnsino([FromBody] PlanoEnsino planoEnsinoModel)
        {
            try
            {
                repository.Add(planoEnsinoModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(planoEnsinoModel);
                }
                else
                {
                    return BadRequest("Erro ao salvar Plano de Ensino.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditarPlanoEnsino(int id, [FromBody] PlanoEnsino planoEnsinoModel)
        {
            try
            {
                var retorno = await repository.GetPlanoEnsinoByIdAsync(id);

                if (retorno != null)
                {
                    repository.Update(planoEnsinoModel);                    //para criar a sugestão PE podemos editao e nao passar o id no json
                    await repository.SaveChangesAsync();
                    return Ok("Plano de Ensino atualizado com sucesso.");
                }
                else
                {
                    return NotFound("Plano de Ensino não encontrado.");

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
