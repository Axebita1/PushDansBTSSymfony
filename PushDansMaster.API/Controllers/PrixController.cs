using Microsoft.AspNetCore.Mvc;
using PushDansMaster.DTO;
using PushDansMaster.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrixController : ControllerBase
    {
        private readonly IPrixService service;

        public PrixController(IPrixService srv)
        {
            service = srv;
        }

        [HttpGet("getall/")]
        public IEnumerable<Prix_DTO> GetAllPrix()
        {
            return service.getAll().Select(p => new Prix_DTO()
            {
                ID = p.GetIDPrix,
                idFournisseur = p.getIDFournisseur,
                prix = p.getPrix,
                idLigneGlobal = p.getIDLignesGlobal
            }) ;
        }

        [HttpGet("get/{id}")]
        public ActionResult<Prix_DTO> GetPrix(int id)
        {
            Prix p = service.getbyID(id);

            if (p == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new Prix_DTO()
            {
                ID = p.GetIDPrix,
                idFournisseur = p.getIDFournisseur,
                prix = p.getPrix,
                idLigneGlobal = p.getIDLignesGlobal
            };
        }


        [HttpPost("insert/")]
        public ActionResult<Prix_DTO> Insert(Prix_DTO p)
        {
            Prix f_work = service.insert(new Prix(p.prix,p.idFournisseur, p.idLigneGlobal));
            //Je récupère l'id Prix
            p.ID = f_work.GetIDPrix;
            //je renvoie l'objet DTO
            return p;
        }

        [HttpPut("update/{id}")]
        public ActionResult<Prix_DTO> Update(Prix_DTO p, int id)
        {
            p.ID = id;

            Prix f_work = service.update(new Prix(p.prix, p.idFournisseur, p.idLigneGlobal));

            return p;
        }

        // DELETE: api/Prix/delete/5 → Delete an Prix
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            service.deleteByID(id);
        }
    }
}
