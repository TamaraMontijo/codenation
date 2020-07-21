using System;
using System.Collections.Generic;
using Codenation.Challenge.Exceptions;
using System.Linq;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        List<Team> Teams = new List<Team>();
        List<Player> Players = new List<Player>();

        public SoccerTeamsManager()
        {
        }

        private void TeamNotFount(long id)
        {
          var team = Teams.Find(t => t.Id == id);
          if (team == null)
          {
            throw new TeamNotFoundException();
          }
        }

        private void PlayerNotFound(long id)
        {
          var player = Players.Find(p => p.Id == id);
          if (player == null)
          {
            throw new PlayerNotFoundException();
          }
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            Team team = new Team();
            team.Id = id;
            team.Name = name;
            team.CreateDate = createDate;
            team.MainShirtColor = mainShirtColor;
            team.SecondaryShirtColor = secondaryShirtColor;

            if (Teams.Any(t => t.Id == team.Id))
            {
              throw new UniqueIdentifierException();
            }
            else
            {
              Teams.Add(team);
            }
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            Player player = new Player();

            player.Id = id;
            player.TeamId = teamId;
            player.Name = name;
            player.BirthDate = birthDate;
            player.SkillLevel = skillLevel;
            player.Salary = salary;

            if (Players.Contains(player) == false)
            {
                Players.Add(player);
            }
            else
            {
              throw new UniqueIdentifierException();
            }

            if (!Teams.Any(t => t.Id == teamId))
            {
              throw new TeamNotFoundException();
            }
        }


        public void SetCaptain(long playerId)
        {
          PlayerNotFound(playerId);

          var captain = Players.Find(p => p.Id == playerId);
          captain.Captain = captain.Id == playerId;

        }

        public long GetTeamCaptain(long teamId)
        {
          TeamNotFount(teamId);

          foreach (Player player in Players)
          {
            if (player.Captain)
            {
                return player.Id;
            }
          }

          throw new CaptainNotFoundException();
        }

        public string GetPlayerName(long playerId)
        {
          PlayerNotFound(playerId);

          var player = Players.Find(p => p.Id == playerId);
          return player.Name;
        }

        public string GetTeamName(long teamId)
        {
          TeamNotFount(teamId);

          var team = Teams.Find(t => t.Id == teamId);
          return team.Name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
          TeamNotFount(teamId);

          List<long> TeamPlayersId = Players.OrderBy(p => p.Id).Select(p => p.Id).ToList();

          return TeamPlayersId;
        }

        public long GetBestTeamPlayer(long teamId)
        {
          TeamNotFount(teamId);

          return Players.OrderByDescending(p => p.SkillLevel).ThenBy(p => p.Id).First().Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
          TeamNotFount(teamId);

          return Players.OrderBy(p => p.BirthDate).ThenBy(p => p.Id).First().Id;
        }

        public List<long> GetTeams()
        {
          return Teams.OrderBy(t => t.Id).Select(t => t.Id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
          TeamNotFount(teamId);

          return Players.OrderByDescending(p => p.Salary).ThenBy(p => p.Id).First().Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
          PlayerNotFound(playerId);

          var player = Players.Find(p => p.Id == playerId);
          return player.Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
          return Players.OrderByDescending(p => p.SkillLevel).Select(p => p.Id).Take(top).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
          var team = Teams.Find(t => t.Id == teamId);
          var visitorTeam = Teams.Find(t => t.Id == visitorTeamId);
          if (team == null || visitorTeam == null)
            throw new TeamNotFoundException();

            if (team.MainShirtColor == visitorTeam.MainShirtColor)
            {
              return visitorTeam.SecondaryShirtColor;
            }
            else
            {
              return visitorTeam.MainShirtColor;
            }
        }
    }
}
