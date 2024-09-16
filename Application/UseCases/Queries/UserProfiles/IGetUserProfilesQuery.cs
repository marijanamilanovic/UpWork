using Application.DTO;
using Application.DTO.UserProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.UserProfiles
{
    public interface IGetUserProfilesQuery : IQuery<PagedResponse<UserProfileDTO>, SearchUserProfile>
    {
    }
}
