using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VersionOne.SDK.APIClient;
using GWStatusReport.Models;

namespace GWStatusReport.DAL
{
    public class TeamDAL
    {
        string connectionString = "[Connection string]";

        //To View all Teams
        public IEnumerable<Team> GetAllTeams()
        {
            try
            {
                string _data = "https://www15.v1host.com/Greenway/rest-1.v1/";
                string _metaUrl = "https://www15.v1host.com/Greenway/meta.v1/";
               
                string sUsername = "pragan.krishna";
                string sPassword = "pragan05";

                V1APIConnector dataConnector = new V1APIConnector(_data, sUsername, sPassword);
                //VersionOneAPIConnector metaConnector = new VersionOneAPIConnector(_metaUrl);

                //IMetaModel metaModel = new MetaModel(metaConnector);

                //IServices services = new Services(metaModel, dataConnector);
                //IAssetType TeamType = metaModel.GetAssetType("Team");
                //Query query1 = new Query(TeamType);

                //IAttributeDefinition teamAttribute = TeamType.GetAttributeDefinition("Team.Name");

                List<Team> lstTeam = new List<Team>();

                //query1.Selection.Add(teamAttribute);


                //QueryResult result1 = services.Retrieve(query1);

                //foreach (Asset story in result1.Assets)
                //{
                //}
                    //using (SqlConnection con = new SqlConnection(connectionString))
                    //{
                    //    SqlCommand cmd = new SqlCommand("spGetAllTeams", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    con.Open();
                    //    SqlDataReader rdr = cmd.ExecuteReader();
                    //    while (rdr.Read())
                    //    {
                    //        Team team = new Team();
                    //        team.ID = Convert.ToInt32(rdr["TeamID"]);
                    //        team.Name = rdr["Name"].ToString();
                    //        team.Category = rdr["Category"].ToString();
                    //        lstTeam.Add(team);
                    //    }

                    //    con.Close();
                    //}

                lstTeam.Add(new Team { ID = 1, Name = "Patriots", Category = "NFT" });
                lstTeam.Add(new Team { ID = 2, Name = "Raiders", Category = "NFT" });
                lstTeam.Add(new Team { ID = 3, Name = "Titans", Category = "PDT" });

                return lstTeam;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Team
        public Team GetTeamData(int id)
        {
            try
            {
                Team Team = new Team();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblTeam WHERE TeamID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Team.ID = Convert.ToInt32(rdr["TeamID"]);
                        Team.Name = rdr["Name"].ToString();
                        Team.Category = rdr["Category"].ToString();
                    }

                    con.Close();
                }
                return Team;
            }
            catch
            {
                throw;
            }            
        }
    }
}
