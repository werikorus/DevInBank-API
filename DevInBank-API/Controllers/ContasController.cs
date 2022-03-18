using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DevInBank_API.src.Entities;
using DevInBank_API.src.Mocks;

namespace DevInBank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : Controller
    {
        [HttpGet]
        public List<Contas> GetContas()
        {
            List<Contas> AllAccounts = ContasMock.GetAllContas();
            return AllAccounts;
        }
    } 
}
