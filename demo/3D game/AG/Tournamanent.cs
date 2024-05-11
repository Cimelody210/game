using System;
using System.IO;
using TrackerLibrary.Models;

namespace Tournamanent
{
    public static class TournamanentLogic
    {
        public static void CreateRounds(TournamanentModel model)
        {
            List<TeamModel> random  = RandomizeTeamOrder(model.EnterredTeams);
            foreach( TeamModel tm in model.EnterredTeams)
            {
                p =  new DynamicParameters();
                p.Add("@TournamentID", model.ID);
                p.Add("@TeamId", tm.ID);
                p.Add("@Id",0, dbType, DbType.Int32m direction: ParamaterDirection.Output);

                connection.Execute("dbo.spTournament_Insert", p, commandType: CommandType.StoredProcedure);
            }
            return model;
        }
    }
    public class Program
    {
        public static void Main(string [] args)
        {

        }
    }
}