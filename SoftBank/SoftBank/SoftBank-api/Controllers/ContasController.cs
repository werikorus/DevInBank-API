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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string EditarConta(int id)
        {
            try
            {
                return "Editado com sucesso";
            }
            catch
            {
                return "Erro ao editar conta";
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public string DeletarConta(int Id)
        {
            return "Deletado com sucesso";
        }
    } 
}
