using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class ChequeService
    {
        public void insert(Cheque cheque)
        {
            ChequeRepository repo = new ChequeRepository();
            repo.Insert(cheque);
        }
    }
}
