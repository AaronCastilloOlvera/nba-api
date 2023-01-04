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

        public IEnumerable <Team> GetByDivition(string divition)
        {
            return context.Teams.Where(t => t.Divition == divition);
        }


        public async Task Save(Team team)
        {
            context.Add(team);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Team team)
        {
            var myTeam = context.Teams.Find(team);

            if ( myTeam != null ) 
            { 
                myTeam.Name = team.Name;
                myTeam.ShortName = team.ShortName;
                myTeam.UrlLogo = team.UrlLogo;
                myTeam.Divition = team.Divition;
                myTeam.Location = team.Location;
                myTeam.PrincipalColor = team.PrincipalColor;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var myTeam = context.Teams.Find(id);

            if (myTeam != null)
            {
                context.Remove(myTeam);
                await context.SaveChangesAsync();
            }
        }
    }


    public interface ITeamService
    {
        IEnumerable<Team> Get();

        IEnumerable<Team> GetByDivition(string divition);

        Task Save(Team team);

        Task Update(int id, Team team);

        Task Delete(int id);
    }

}
