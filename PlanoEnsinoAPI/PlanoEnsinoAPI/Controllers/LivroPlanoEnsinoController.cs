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
    public class LivroPlanoEnsinoController : ControllerBase
    {
        private readonly IRepository repository;
        public LivroPlanoEnsinoController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> SalvarLivroPlano([FromBody] LivroPlanoEnsino livroPlanoEnsinoModel)
        {
            try
            {
                repository.Add(livroPlanoEnsinoModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(livroPlanoEnsinoModel);
                }
                else
                {
                    return BadRequest("Erro ao linkar livro e plano.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpDelete, Route("{cdLivro}/{cdDisciplina}")]
        public async Task<IActionResult> ApagarLivroPlano(int cdLivro, int cdDisciplina)
        {
            try
            {
                var resulta = await this.repository.GetLivroPlanoEnsinoById(cdLivro, cdDisciplina);

                if (resulta != null)
                {
                    repository.Delete(resulta);
                    await repository.SaveChangesAsync();
                    return Ok("O livro e plano de ensino foram desconectados com sucesso!");
                }
                else
                {
                    return BadRequest("Erro ao desconectar livro e plano de ensino.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
