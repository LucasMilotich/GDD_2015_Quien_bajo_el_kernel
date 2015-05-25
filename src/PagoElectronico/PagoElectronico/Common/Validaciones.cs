using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PagoElectronico.Common
{
    public class Validaciones
    {
        public bool validarCampoVacio (TextBox unTextBox)
        {
		    if (!string.IsNullOrEmpty(unTextBox.Text))
	        {
	            unTextBox.BackColor = System.Drawing.Color.LightCoral;
                return false;
	        }
            return true;
        }

        public bool validarCampoString(TextBox textBox)
        {
            Regex expRegular = new Regex("^[a-zA-Z]*$");
            if (!expRegular.IsMatch(textBox.Text))
            {
                textBox.BackColor = System.Drawing.Color.LightCoral;
                return false;
            }
            return true;
        }
        
        public bool validarCampoNumericoEntero(TextBox textBox)
        {
            Regex expRegular = new Regex("^[0-9]*$");
            if (!expRegular.IsMatch(textBox.Text))
            {
                textBox.BackColor=System.Drawing.Color.LightCoral;
                return false;
            }
            return true;
        }

        public bool validarCampoNumericoDouble(TextBox textBox)
        {
            Double num;
            if (!Double.TryParse(textBox.Text, out num))
            {
                textBox.BackColor = System.Drawing.Color.LightCoral;
                return false;
            }
            return true;            
        }
        
        public bool validarCampoMail(TextBox textBox)
        {
            Regex expRegular = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            if (!expRegular.IsMatch(textBox.Text))
            {
                textBox.BackColor=System.Drawing.Color.LightCoral;
                return false;
            }
            return true;
        }

    }
}
