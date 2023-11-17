using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;

public class Database : MonoBehaviour
{
    public static Database _DATABASE;

    // Database variables
    private IDbConnection conn;
    private string dbName = "Assets/SQL/entifarm.db";

    // Objects variables
    private List<Plant> plants;

    private void Awake()
    {

        if (_DATABASE != null && _DATABASE != this)
        {
            Destroy(this);
        }
        else
        {

            _DATABASE = this;

            conn = new SqliteConnection(string.Format("URI=file:{0}", dbName));
            conn.Open();

            plants = new List<Plant>();
            GetAllPlants();
        }
        
    }

    private List<Plant> GetAllPlants()
    {
        // Miramos si el array está vacío. En caso que no esté, retornamos el array
        if (plants.Count == 0)
        {
            return plants;
        }

        // Nos conectamos a la base de datos y ejecutamos el comando de recibir todas las plantas
        IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM plants;";
        IDataReader reader = cmd.ExecuteReader();


        // Mientras tengamos ROWS que leer, almacenamos los datos en un array, encapsulado en el objecto Plant
        while (reader.Read())
        {
            plants.Add(new Plant(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetFloat(5)));
        }

        return plants;

    }

    public List<Plant> GetUserPlants()
    {
        List<Plant> userPlants = new List<Plant>();

        IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT plants.id_plant, plants.plant, plants.time, plants.quantity, plants.sell, plants.buy FROM plants_users LEFT JOIN plants ON plants.id_plant = plants_users.id_plant WHERE plants_users.id_user = 1";
        IDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            userPlants.Add(new Plant(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetFloat(5)));
        }
        return userPlants;
    }



}
