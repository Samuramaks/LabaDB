using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp
{
    internal class DataBase
    {
        MySqlConnection connect = new MySqlConnection("Server=localhost;Database=machine_monitoring;Uid=root;pwd=root;");
        List<Machine> _machine = new List<Machine>();
        public void OpenConnection() => connect.Open();
        public void CloseConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open) connect.Close();
        }

        public List<Machine> ReadValue()
        {
            try
            {

                string response = "SELECT * FROM machine_monitoring.machine";
                MySqlCommand cmd = new MySqlCommand(response, connect);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _machine.Add(new Machine(id: Convert.ToInt32(reader["id_machine"]), name: reader["name"].ToString(), type_cnc: reader["type_cnc"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _machine;
        }

        public string SendLog(ObservableCollection<Logs> logs)
        {
            if (logs.Count == 0) return "Логи пустые. Нечего отправлять в бд";
            else
            {
                try
                {
                    foreach (Logs log in logs)
                    {
                        string response = $"INSERT INTO logger(date, type_error, msg, id_machine) VALUES (N'{log.Date}',N'{log.TypeError}',N'{log.Msg}', N'{log.Id_machine}')";

                        MySqlCommand cmd = new MySqlCommand(response, connect);
                         cmd.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                return "Логи отправлены и очищены";
            }
        }
    }
}
