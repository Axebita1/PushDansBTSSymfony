using Microsoft.AspNetCore.Mvc;
using PushDansMaster.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LigneGlobalController : ControllerBase
    {
        private readonly ILigneGlobalService service;

        public LigneGlobalController(ILigneGlobalService srv)
        {
            service = srv;
        }


        [HttpGet("getall/")]
        public IEnumerable<LigneGlobal_DTO> GetAllLignesGlobal()
        {
            return service.getAll().Select(f => new LigneGlobal_DTO()
            {
                ID = f.getID,
                id_panier = f.getIDPanier,
                quantite = f.getQuantite,
                reference = f.getReference,
                id_reference = f.getIDReference
            }); 
        }

        // POST: api/LigneGlobal/insert → Insert a new LigneGlobal
        [HttpPost("insert/")]
        public ActionResult<LigneGlobal_DTO> Insert(LigneGlobal_DTO f)
        {
            LignesGlobal f_work = service.insert(new LignesGlobal(f.id_panier, f.quantite, f.reference, f.id_reference));
            //Je récupère l'id LigneGlobal
            f.ID = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }


    }
}