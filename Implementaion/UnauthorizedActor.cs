using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string FirstName => "unauthorized";

        public string LastName => "unauthorized";

        public string Email => "unauthorized";

        public int Connects => 0;

        public IEnumerable<int> AllowedUseCases => new List<int> { 1,47,48,52,53,60,70,71,72,73,74 };
    }
}
