﻿using Microsoft.AspNetCore.Mvc;
using ROBO.Models.Aplicacao;
using ROBO.Models.Dominio;

namespace ROBO.Controllers
{
    public class RoboController : Controller
    {
        private readonly IAplicControlaRoboBecomex _aplicControlaRoboBecomex;

        public RoboController(IAplicControlaRoboBecomex aplicControlaRoboBecomex)
        {
            _aplicControlaRoboBecomex = aplicControlaRoboBecomex;
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult TelaRobo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            try
            {
                var robo = _aplicControlaRoboBecomex.Novo();
                return Ok(new HttpRetorno(true, "Robo criado com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpRetorno(false, ex.Message, null));
            }
        }

        [HttpPost]
        public IActionResult Reseta([FromBody] RoboBecomex roboBecomex)
        {
            try
            {
                 var robo = _aplicControlaRoboBecomex.Reseta(roboBecomex);
                return Ok(new HttpRetorno(true, "Robo reiniciado com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpRetorno(false, ex.Message, null));
            }
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] RoboBecomex roboBecomex)
        {
            try
            {
                var robo = _aplicControlaRoboBecomex.Alterar(roboBecomex);
                return Ok(new HttpRetorno(true, "Robo Atualizado com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpRetorno(false, ex.Message, null));
            }
        }

        [HttpPost]
        public IActionResult InclinaCabeca([FromBody] MovimentaCabecaDTO movimentaCabecaDTO)
        {
            try
            {
                var robo = _aplicControlaRoboBecomex.InclinaCabeca(movimentaCabecaDTO);
                return Ok(new HttpRetorno(true, "Ação executada com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpRetorno(false, ex.Message, null));
            }
        }

        [HttpPost]
        public IActionResult RotacionaCabeca([FromBody] MovimentaCabecaDTO movimentaCabecaDTO)
        {
            try
            {
                var robo = _aplicControlaRoboBecomex.RotacionaCabeca(movimentaCabecaDTO);
                return Ok(new HttpRetorno(true, "Ação executada com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpRetorno(false, ex.Message, null));
            }
        }

        [HttpPost]
        public IActionResult MoveCotovelo([FromBody] MovimentaBracoDTO movimentaBracoDTO)
        {
            try
            {
                var robo = _aplicControlaRoboBecomex.MoveCotovelo(movimentaBracoDTO);
                return Ok(new HttpRetorno(true, "Ação executada com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpRetorno(false, ex.Message, null));
            }
        }

        [HttpPost]
        public IActionResult RotacionaPulso([FromBody] MovimentaBracoDTO movimentaBracoDTO)
        {
            try
            {
                var robo = _aplicControlaRoboBecomex.RotacionaPulso(movimentaBracoDTO);
                return Ok(new HttpRetorno(true, "Ação executada com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpRetorno(false, ex.Message, null));
            }
        }
    }
}
