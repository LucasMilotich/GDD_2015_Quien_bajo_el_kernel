using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class RetiroService
    {
        public IEnumerable<Retiro> getUltimosCincoRetirosByCuenta(string cuenta)
        {
            RetiroRepository retiroRepo = new RetiroRepository();
            return retiroRepo.getUltimosCincoRetirosByCuenta(cuenta);
        }

        public void GuardarRetiro(Retiro retiro)
        {
            using (var transaction = new TransactionScope())
            {
                ChequeService chequeService = new ChequeService();
                chequeService.insert(retiro.cheque);
                RetiroRepository repo = new RetiroRepository();
                repo.Insert(retiro);
            
                transaction.Complete();
                transaction.Dispose();

            }
        }
    }
}
