using MySql.Data.MySqlClient;
using E_AgroServiceDemo.Repositories.Interfaces;
using E_AgroServiceDemo.Models;
using System.ComponentModel;
using Org.BouncyCastle.Bcpg;

namespace E_AgroServiceDemo.Repositories;

public class FarmerRepository:IFarmerRepository{
        public static string conString = "server=localhost;port=3306;user=root;password=password;database=eagroservicesdb";

    public List<Farmer> GetAllFarmers()
    {
       List<Farmer> farmers=new List<Farmer>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM farmers";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
           while (reader.Read()) {
                int id = Int32.Parse(reader["farmerId"].ToString());
                string name  = reader["farmerName"].ToString();
                string mobileNumber = reader["contactNumber"].ToString();
                string location=reader["location"].ToString();
                string password=reader["password"].ToString();
                long creditedAmount=long.Parse(reader["creditBalance"].ToString());
                long debitedAmount=long.Parse(reader["debitBalance"].ToString());
                long balance=long.Parse(reader["balance"].ToString());
               Farmer farmer=new Farmer()
                {
                  FarmerId=id,
                  FarmerName=name,
                  ContactNumber=mobileNumber,
                  Location=location,
                  Password=password,
                  CreditedAmount=creditedAmount,
                  DebitedAmount=debitedAmount,
                  Balance=balance
                };

               farmers.Add(farmer);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return farmers;

    }
}