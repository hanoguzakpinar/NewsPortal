using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Shared.Entities.Abstract;

namespace NewsPortal.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public string Text { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}