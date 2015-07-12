using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class BancoService
    {
        public IEnumerable<Banco> GetAll()
        {
            BancoRepository bancoRepo = new BancoRepository();
            return bancoRepo.GetAll();
        }

    }
}
