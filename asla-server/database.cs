//  
//  database.cs
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
using MySql.Data.MySqlClient;

namespace aslaserver
{
	public class database
	{
		Boolean connected = false;
		string server="";
		string dbname="";
		string username="";
		string passwd="";
		string port="3306";
		public MySqlConnection connection;
		
		public database ()
		{
			//Naaaa.
		}
		
		public Boolean isConnected() {
			return this.connected;
		}
		
		public void connect(string server, string dbname, string username, string passwd, string port) {
			this.server = server;
			this.dbname=dbname;
			this.username=username;
			this.passwd = passwd;
			this.port=port;
			string connectionString =
  		      	"Server="+server+";" +
 	 	        "Database="+dbname+";" +
  		        "User ID="+username+";" +
  		        "Password="+passwd+";" +
  		        "Pooling=false";
			this.connection = new MySqlConnection (connectionString);
			this.connection.Open ();
		}
	}
}

