using Microsoft.AspNetCore.Mvc;
using SoftBank_console.src.Entities;
using SoftBank_console.src.Mocks;
using System.Collections.Generic;

namespace SoftBank_api.Controllers
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
        public string Depositar(int conta)
        {
            try
            {
                return "Editado com sucesso";
            }
            catch
            {
                throw new("Erro ao depositar!");
            }
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
