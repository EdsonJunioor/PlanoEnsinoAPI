﻿using Microsoft.AspNetCore.Mvc;
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


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscarUsuarioById(int id)
        {
            try
            {
                var retorno = await this.repository.GetUsuarioByIdAsync(id);
                
                if(retorno != null)
                {
                    return Ok(retorno.Nome.ToLower());
                }
                else
                {
                    return NotFound("Usuário não encontrado.");
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Usuário Erro:{ex.Message}");
            }
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
            
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditarUsuario(int id, [FromBody]Usuario usuarioModel)
        {
            try
            {
                var retorno = await repository.GetUsuarioByIdAsync(id);

                if(retorno != null)
                {
                    repository.Update(usuarioModel);                    //para criar a sugestão PE podemos editao e nao passar o id no json
                    await repository.SaveChangesAsync();
                    return Ok("Usuário atualizado com sucesso.");
                }
                else
                {
                    return NotFound("Usuário não encontrado.");

                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

    }
}
