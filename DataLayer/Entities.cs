using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Serializable]
    public partial class Entities
    {
        private Entities(DbConnection connectionString, bool contextOwnsConnection = true)
            : base(connectionString, contextOwnsConnection) { }
        public static Entities CreateEntities (bool contextOwnsConnection = true)
        {
            //read file connect
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open("connectdb.dba", FileMode.OpenOrCreate, FileAccess.Read);
            connect cp = (connect)bf.Deserialize(fs);

            //Decrypt content
            string servername = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
            string username = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
            string pass = Encryptor.Decrypt(cp.passwd, "qwertyuiop", true);
            string database = Encryptor.Decrypt(cp.database, "qwertyuiop", true);

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder sqlConnectBuilder = new SqlConnectionStringBuilder();
            sqlConnectBuilder.DataSource = servername;
            sqlConnectBuilder.InitialCatalog = database;
            sqlConnectBuilder.UserID = username;
            sqlConnectBuilder.Password = pass;

            string sqlConnectionString = sqlConnectBuilder.ConnectionString;

            EntityConnectionStringBuilder entityBuider = new EntityConnectionStringBuilder();
            entityBuider.Provider = "System.Data.SqlClient";
            entityBuider.ProviderConnectionString = sqlConnectionString;
            entityBuider.Metadata = @"res://*/KHACHSAN.csdl|res://*/KHACHSAN.ssdl|res://*/KHACHSAN.msl";
            EntityConnection connection = new EntityConnection(entityBuider.ConnectionString);

            fs.Close();
            return new Entities(connection);
        }
    }
}
