﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NewsPortal.Shared.Entities.Abstract;

namespace NewsPortal.Entities.Concrete
{
    public class Role : IdentityRole<int>
    {
    }
}
