using nba_api.Models;

namespace nba_api.Services
{
    public class TeamService: ITeamService
    {
        NBAContext context;

        public TeamService(NBAContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Team> Get()
        {
            return context.Teams;
        }

        public async Task Save(Team team)
        {
            context.Add(team);
            await context.SaveChangesAsync();
        }

    }


    public interface ITeamService
    {
        IEnumerable<Team> Get();

        Task Save(Team team);
    }

}
