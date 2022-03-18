using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInBank_API.src.Entities;

namespace DevInBank_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class HomeController : Controller
    {
        // POST: HomeController/Edit/5
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
        public  string DeletarConta(int Id)
        {
            return "Deletado com sucesso";
        }
    }
}
