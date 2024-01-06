using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    internal class Log
    {
        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime ExceptionTime { get; set; }
        public string ExceptionPath { get; set; }
        public string ExceptionMethod { get; set; }


    }
}
