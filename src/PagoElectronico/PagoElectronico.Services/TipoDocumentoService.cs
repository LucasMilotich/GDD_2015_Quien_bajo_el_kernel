using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
   public class TipoDocumentoService
    {
        public IEnumerable<TipoDocumento> GetAll()
        {
            TipoDocumentoRepository TipoDocumentoRepo = new TipoDocumentoRepository();
            return TipoDocumentoRepo.GetAll();
        }

    }
}
