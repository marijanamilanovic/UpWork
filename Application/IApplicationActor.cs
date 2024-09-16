using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IApplicationActor
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }

        string Email { get; }

        int Connects { get; }

        IEnumerable<int> AllowedUseCases { get; }
    }
}
