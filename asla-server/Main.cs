//  
//  Main.cs
//  
//  Author:
//       Juan Egido <alberje@alberje.es>
// 
//  Copyright (c) 2011 Juan Egido
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Data;
using OpenMetaverse;
using MySql.Data.MySqlClient;

namespace aslaserver
{
	class MainClass
	{
//        // GridClient is the primary class the library uses for almost all things
        private static OpenMetaverse.GridClient Client = new OpenMetaverse.GridClient();
//			
		static void Main (string[] args)
		{
			//Init basic info an connections.
			try {
				config conf = new config();
				database db = new database();
				db.connect(conf.db.server, conf.db.database, conf.db.username, conf.db.passwd, conf.db.port);
				andserver srv = new andserver();
				slclient cli = new slclient();
			}
			
			catch (Exception e) {
				Console.WriteLine("Error initializing, finishing...\n"+e.Message);
				return;
			}
			
//			string stloc = OpenMetaverse.NetworkManager.StartLocation("Drax", 65, 156, 58);
//            if (Client.Network.Login("AlberSpa", "Resident", "", "asla.server", stloc, "0.1"))
//            {
//                // Yay we made it! let's print out the message of the day
//                Console.WriteLine("You have successfully logged into Second Life!\n The Message of the day is {0}\nPress any Key to Logout", 
//                    Client.Network.LoginMessage);
//                
//                Console.ReadLine(); // Wait for user to press a key before we continue
// 
//                Client.Network.Logout(); // Lets logout since we're done here
//            }
//            else
//            {
//                // tell the user why the login failed
//                Console.WriteLine("We were unable to login to Second Life, The Login Server said: {0}",
//                    Client.Network.LoginMessage);
//            }
//            Console.WriteLine("Press Any Key to Exit");
//            Console.ReadLine(); // Wait for user to press a key before we exit
		}
//		config conf = new config();
//			Console.WriteLine("DB" + conf.db.database);
//			Console.WriteLine("U" +conf.db.username);
//			Console.WriteLine("PASS" + conf.db.passwd);
//			Console.WriteLine("SS" + conf.db.server);
//			Console.WriteLine("Port" + conf.db.port);
//			string connectionString =
//  		      	"Server="+conf.db.server+";" +
// 	 	        "Database="+conf.db.database+";" +
//  		        "User ID="+conf.db.username+";" +
//  		        "Password="+conf.db.passwd+";" +
//  		        "Pooling=false";
//			MySqlConnection dbcon = new MySqlConnection (connectionString);
//			dbcon.Open ();
//		
//			IDbCommand dbcmd = dbcon.CreateCommand ();
//			// requires a table to be created named employee
//			// with columns firstname and lastname
//			// such as,
//			//        CREATE TABLE employee (
//			//           firstname varchar(32),
//			//           lastname varchar(32));
//			string sql =
//           "SELECT firstname, lastname " +
//           "FROM user";
//			dbcmd.CommandText = sql;
//			IDataReader reader = dbcmd.ExecuteReader ();
//			while (reader.Read()) {
//				string FirstName = (string)reader ["firstname"];
//				string LastName = (string)reader ["lastname"];
//				Console.WriteLine ("Name: " +
//                  FirstName + " " + LastName);
//			}
//			// clean up
//			reader.Close ();
//			reader = null;
//			dbcmd.Dispose ();
//			dbcmd = null;
//			dbcon.Close ();
//			dbcon = null;
//		}
	}
}
	