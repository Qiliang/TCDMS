﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.IServices
{
    public interface IUserService
    {
        int?[] GetProductLines(int userID);
    }
}
