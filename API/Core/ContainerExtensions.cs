using Application;
using Application.UseCases.Commands.Experiences;
using Application.UseCases.Commands.Jobs;
using Application.UseCases.Commands.LanguageProficiencyLevels;
using Application.UseCases.Commands.Languages;
using Application.UseCases.Commands.Proposals;
using Application.UseCases.Commands.SalaryTypes;
using Application.UseCases.Commands.SavedJobs;
using Application.UseCases.Commands.Skills;
using Application.UseCases.Commands.UserEducations;
using Application.UseCases.Commands.UserLanguages;
using Application.UseCases.Commands.UserProfilePortfolios;
using Application.UseCases.Commands.UserProfiles;
using Application.UseCases.Commands.UserProfileSkills;
using Application.UseCases.Commands.Users;
using Application.UseCases.Commands.UserWorkExperiences;
using Application.UseCases.Commands.WorkHours;
using Application.UseCases.Queries.AuditLogs;
using Application.UseCases.Queries.Experiences;
using Application.UseCases.Queries.Jobs;
using Application.UseCases.Queries.LanguageProficiencyLevels;
using Application.UseCases.Queries.Languages;
using Application.UseCases.Queries.Proposals;
using Application.UseCases.Queries.SalaryTypes;
using Application.UseCases.Queries.Skills;
using Application.UseCases.Queries.UserEducations;
using Application.UseCases.Queries.UserLanguages;
using Application.UseCases.Queries.UserProfilePortfolios;
using Application.UseCases.Queries.UserProfiles;
using Application.UseCases.Queries.Users;
using Application.UseCases.Queries.UserWorkExperiences;
using Application.UseCases.Queries.WorkHours;
using Implementation.Logging.UseCases;
using Implementation.UseCases;
using Implementation.UseCases.Commands.Experiences;
using Implementation.UseCases.Commands.Jobs;
using Implementation.UseCases.Commands.LanguageProficiencyLevels;
using Implementation.UseCases.Commands.Languages;
using Implementation.UseCases.Commands.Proposals;
using Implementation.UseCases.Commands.SalaryTypes;
using Implementation.UseCases.Commands.SavedJobs;
using Implementation.UseCases.Commands.Skills;
using Implementation.UseCases.Commands.UserEducations;
using Implementation.UseCases.Commands.UserLanguages;
using Implementation.UseCases.Commands.UserProfilePortfolios;
using Implementation.UseCases.Commands.UserProfiles;
using Implementation.UseCases.Commands.UserProfileSkills;
using Implementation.UseCases.Commands.Users;
using Implementation.UseCases.Commands.UserWorkExperiences;
using Implementation.UseCases.Commands.WorkHours;
using Implementation.UseCases.Queries.AuditLogs;
using Implementation.UseCases.Queries.Experiences;
using Implementation.UseCases.Queries.Jobs;
using Implementation.UseCases.Queries.LanguageProficiencyLevels;
using Implementation.UseCases.Queries.Languages;
using Implementation.UseCases.Queries.Proposals;
using Implementation.UseCases.Queries.SalaryTypes;
using Implementation.UseCases.Queries.Skills;
using Implementation.UseCases.Queries.UserEducations;
using Implementation.UseCases.Queries.UserLanguages;
using Implementation.UseCases.Queries.UserProfilePortfolios;
using Implementation.UseCases.Queries.UserProfiles;
using Implementation.UseCases.Queries.Users;
using Implementation.UseCases.Queries.UserWorkExperiences;
using Implementation.UseCases.Queries.WorkHours;
using Implementation.Validators.Experiences;
using Implementation.Validators.Jobs;
using Implementation.Validators.LanguageProficiencyLevels;
using Implementation.Validators.Languages;
using Implementation.Validators.Proposals;
using Implementation.Validators.SalaryTypes;
using Implementation.Validators.SavedJobs;
using Implementation.Validators.Skills;
using Implementation.Validators.UserEducations;
using Implementation.Validators.UserLanguages;
using Implementation.Validators.UserProfilePortfolios;
using Implementation.Validators.UserProfiles;
using Implementation.Validators.UserProfileSkills;
using Implementation.Validators.Users;
using Implementation.Validators.UserWorkExperiences;
using Implementation.Validators.WorkHours;
using System.IdentityModel.Tokens.Jwt;

namespace API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<UseCaseHandler>();

            services.AddTransient<IGetAuditLogsQuery,EfGetAuditLogsQuery>();

            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IUpdateUserAccessCommand, EfUpdateUserAccessCommand>();
            services.AddTransient<IUpdateUserImageCommand, EfUpdateUserImageCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();

            services.AddTransient<ICreateUserProfileCommand, EfCreateUserProfileCommand>();
            services.AddTransient<IUpdateUserProfileCommand, EfUpdateUserProfileCommand>();
            services.AddTransient<IDeleteUserProfileCommand, EfDeleteUserProfileCommand>();
            services.AddTransient<IGetUserProfilesQuery, EfGetUserProfilesQuery>();
            services.AddTransient<IGetUserProfileQuery, EfGetUserProfileQuery>();

            services.AddTransient<IUpdateUserProfileSkillCommand, EfUpdateUserProfileSkillCommand>();


            services.AddTransient<ICreateUserLanguageCommand, EfCreateUserLanguageCommand>();
            services.AddTransient<IUpdateUserLanguageCommand, EfUpdateUserLanguageCommand>();
            services.AddTransient<IDeleteUserLanguageCommand, EfDeleteUserLanguageCommand>();
            services.AddTransient<IGetUserLanguagesQuery, EfGetUserLanguagesQuery>();

            services.AddTransient<ICreateUserEducationCommand, EfCreateUserEducationCommand>();
            services.AddTransient<IUpdateUserEducationCommand, EfUpdateUserEducationCommand>();
            services.AddTransient<IDeleteUserEducationCommand, EfDeleteUserEducationCommand>();
            services.AddTransient<IGetUserEducationsQuery, EfGetUserEducationsQuery>();
            services.AddTransient<IGetUserEducationQuery, EfGetUserEducationQuery>();

            services.AddTransient<ICreateExperienceCommand, EfCreateExperienceCommand>();
            services.AddTransient<IUpdateExperienceCommand, EfUpdateExperienceCommand>();
            services.AddTransient<IDeleteExperienceCommand, EfDeleteExperienceCommand>();
            services.AddTransient<IGetExperiencesQuery, EfGetExperiencesQuery>();
            services.AddTransient<IGetExperienceQuery, EfGetExperienceQuery>();

            services.AddTransient<ICreateUserProfilePortfolioCommand, EfCreateUserProfilePortfolioCommand>();
            services.AddTransient<IUpdateUserProfilePortfolioCommand, EfUpdateUserProfilePortfolioCommand>();
            services.AddTransient<IDeleteUserProfilePortfolioCommand, EfDeleteUserProfilePortfolioCommand>();
            services.AddTransient<IGetUserProfilePortfoliosQuery, EfGetUserProfilePortfoliosQuery>();
            services.AddTransient<IGetUserProfilePortfolioQuery, EfGetUserProfilePortfolioQuery>();

            services.AddTransient<ICreateWorkHourCommand, EfCreateWorkHourCommand>();
            services.AddTransient<IUpdateWorkHourCommand, EfUpdateWorkHourCommand>();
            services.AddTransient<IDeleteWorkHourCommand, EfDeleteWorkHourCommand>();
            services.AddTransient<IGetWorkHoursQuery, EfGetWorkHoursQuery>();
            services.AddTransient<IGetWorkHourQuery, EfGetWorkHourQuery>();

            services.AddTransient<ICreateJobCommand, EfCreateJobCommand>();
            services.AddTransient<IUpdateJobCommand, EfUpdateJobCommand>();
            services.AddTransient<IDeleteJobCommand, EfDeleteJobCommand>();
            services.AddTransient<IGetJobsQuery, EfGetJobsQuery>();
            services.AddTransient<IGetJobQuery, EfGetJobQuery>();

            services.AddTransient<ICreateLanguageProficiencyLevelCommand, EfCreateLanguageProficiencyLevelCommand>();
            services.AddTransient<IUpdateLanguageProficiencyLevelCommand, EfUpdateLanguageProficiencyLevelCommand>();
            services.AddTransient<IDeleteLanguageProficiencyLevelCommand, EfDeleteLanguageProficiencyLevelCommand>();
            services.AddTransient<IGetLanguageProficiencyLevelsQuery, EfGetLanguageProficiencyLevelsQuery>();
            services.AddTransient<IGetLanguageProficiencyLevelQuery, EfGetLanguageProficiencyLevelQuery>();

            services.AddTransient<ICreateProposalCommand, EfCreateProposalCommand>();
            services.AddTransient<IUpdateProposalCommand, EfUpdateProposalCommand>();
            services.AddTransient<IDeleteProposalCommand, EfDeleteProposalCommand>();
            services.AddTransient<IGetProposalsQuery, EfGetProposalsQuery>();
            services.AddTransient<IGetProposalQuery, EfGetProposalQuery>();

            services.AddTransient<ICreateLanguageCommand, EfCreateLanguageCommand>();
            services.AddTransient<IUpdateLanguageCommand, EfUpdateLanguageCommand>();
            services.AddTransient<IDeleteLanguageCommand, EfDeleteLanguageCommand>();
            services.AddTransient<IGetLanguagesQuery, EfGetLanguagesQuery>();
            services.AddTransient<IGetLanguageQuery, EfGetLanguageQuery>();

            services.AddTransient<ICreateSalaryTypeCommand, EfCreateSalaryTypeCommand>();
            services.AddTransient<IUpdateSalaryTypeCommand, EfUpdateSalaryTypeCommand>();
            services.AddTransient<IDeleteSalaryTypeCommand, EfDeleteSalaryTypeCommand>();
            services.AddTransient<IGetSalaryTypesQuery, EfGetSalaryTypesQuery>();
            services.AddTransient<IGetSalaryTypeQuery, EfGetSalaryTypeQuery>();

            services.AddTransient<ICreateSavedJobCommand, EfCreateSavedJobCommand>();
            services.AddTransient<IDeleteSavedJobCommand, EfDeleteSavedJobCommand>();

            services.AddTransient<ICreateSkillCommand, EfCreateSkillCommand>();
            services.AddTransient<IUpdateSkillCommand, EfUpdateSkillCommand>();
            services.AddTransient<IDeleteSkillCommand, EfDeleteSkillCommand>();
            services.AddTransient<IGetSkillsQuery, EfGetSkillsQuery>();
            services.AddTransient<IGetSkillQuery, EfGetSkillQuery>();   

            services.AddTransient<ICreateUserWorkExperienceCommand, EfCreateUserWorkExperienceCommand>();
            services.AddTransient<IUpdateUserWorkExperienceCommand, EfUpdateUserWorkExperienceCommand>();
            services.AddTransient<IDeleteUserWorkExperienceCommand, EfDeleteUserWorkExperienceCommand>();
            services.AddTransient<IGetUserWorkExperiencesQuery, EfGetUserWorkExperiencesQuery>();
            services.AddTransient<IGetUserWorkExperienceQuery, EfGetUserWorkExperienceQuery>();
        }
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<UpdateUserAccessValidator>();
            services.AddTransient<UpdateUserImageValidator>();

            services.AddTransient<CreateUserProfileValidator>();
            services.AddTransient<UpdateUserProfileValidator>();

            services.AddTransient<UpdateUserProfileSkillValidator>();

            services.AddTransient<CreateUserLanguageValidator>();
            services.AddTransient<UpdateUserLanguageValidator>();

            services.AddTransient<CreateUserEducationValidator>();
            services.AddTransient<UpdateUserEducationValidator>();

            services.AddTransient<CreateExperienceValidator>();
            services.AddTransient<UpdateExperienceValidator>();

            services.AddTransient<CreateUserProfilePortfolioValidator>();
            services.AddTransient<UpdateUserProfilePortfolioValidator>();

            services.AddTransient<CreateWorkHourValidator>();
            services.AddTransient<UpdateWorkHourValidator>();

            services.AddTransient<CreateJobValidator>();
            services.AddTransient<UpdateJobValidator>();
            
            services.AddTransient<CreateLanguageProficiencyLevelValidator>();
            services.AddTransient<UpdateLanguageProficiencyLevelValidator>();

            services.AddTransient<CreateProposalValidator>();
            services.AddTransient<UpdateProposalValidator>();

            services.AddTransient<CreateLanguageValidator>();
            services.AddTransient<UpdateLanguageValidator>();

            services.AddTransient<CreateSalaryTypeValidator>();
            services.AddTransient<UpdateSalaryTypeValidator>();

            services.AddTransient<CreateSavedJobValidator>();

            services.AddTransient<CreateSkillValidator>();
            services.AddTransient<UpdateSkillValidator>();

            services.AddTransient<CreateUserWorkExperienceValidator>();
            services.AddTransient<UpdateUserWorkExperienceValidator>();

        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers.Authorization.ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
