using Microsoft.AspNetCore.Mvc;
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
                return BadRequest(ex);
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
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult NovoNome([FromBody] NovoNomeDTO novoNomeDTO)
        {
            try
            {
                var robo = _aplicControlaRoboBecomex.NovoNome(novoNomeDTO);
                return Ok(new HttpRetorno(true, "Nome alterado com sucesso.", robo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
                return BadRequest(ex);
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
                return BadRequest(ex);
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
                return BadRequest(ex);
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
                return BadRequest(ex);
            }
        }
    }
}
