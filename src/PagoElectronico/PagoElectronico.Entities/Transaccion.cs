using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities.Enums;

namespace PagoElectronico.Entities
{
    public class Transaccion
    {
        public long codigo { get; set; }
        public long cuenta { get; set; }
        public double costo { get; set; }
        public int tipo { get; set; }
        public int suscripcion { get; set; }
        public DateTime fecha { get; set; }
        public string TipoDescription 
        {
            get 
            {
                if ((TiposTransaccionEnum)this.tipo == TiposTransaccionEnum.Transferencia)
                {
                    return EnumHelper.GetEnumDescription(TiposTransaccionEnum.Transferencia);
                }
                else if ((TiposTransaccionEnum)this.tipo == TiposTransaccionEnum.AperturaCuenta)
                {
                    return EnumHelper.GetEnumDescription(TiposTransaccionEnum.AperturaCuenta);
                }
                else
                {
                    return EnumHelper.GetEnumDescription(TiposTransaccionEnum.ModifCuenta);
                }
            }
        }
        public double CostoTotal
        {
            get
            {
                if ((TiposTransaccionEnum)this.tipo == TiposTransaccionEnum.Transferencia)
                {
                    return this.costo;
                }
                else 
                {
                    return this.costo * this.suscripcion;
                }
            }
        }
    }
}
