﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;

namespace PagoElectronico.Services.Interfaces
{
    public interface ILoginService
    {
        Usuario Login(string username, string password);
    }
}
