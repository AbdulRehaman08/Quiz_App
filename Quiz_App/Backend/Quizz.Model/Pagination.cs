using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Model
{
    public class Pagination
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
