﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Entities.Concrete;
using NewsPortal.Shared.Entities.Abstract;

namespace NewsPortal.Entities.Dtos
{
    public class ReportDto : DtoGetBase
    {
        public Report Report { get; set; }
    }
}