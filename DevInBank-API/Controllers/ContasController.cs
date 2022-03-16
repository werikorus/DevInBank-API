using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInBank_API.src.Entities;
using DevInBank_API.src.Enums;

namespace DevInBank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : Controller
    {
        [HttpGet]
        public List<Contas> GetContas()
        {
            List<Contas> contas = new List<Contas>();

            Contas c1 = new ("Werik Filipe dos Santos Cunha", "022.381.581-03", "Florianóplis-SC", 4645.85,  AgenciasEnum.Florianopolis, 4545.22);
            Contas c2 = new ("Ester Carvalho de Alencar", "021.313.123-01", "Florianóplis-SC", 4645.85,  AgenciasEnum.Biguacu, 6578.56);

            contas.Add(c1);
            contas.Add(c2);

            return contas;
        }
    }
}
