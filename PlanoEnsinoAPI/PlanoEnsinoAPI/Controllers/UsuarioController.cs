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
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository repository;

        public UsuarioController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var result = await this.repository.GetAllUsuarioAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuarioModel)
        {
            try
            {
                repository.Add(usuarioModel);

                if (await repository.SaveChangesAsync())
                {
                    return Ok(usuarioModel);
                }
                else
                {
                    return BadRequest("Erro ao salvar usúario.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
