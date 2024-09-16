using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly UpWorkContext _context;

        protected EfUseCase(UpWorkContext context)
        {
            _context = context;
        }
        protected UpWorkContext Context => _context;
    }
}
