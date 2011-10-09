/******************************************************************************
    asla-server
    Copyright (C) 2011 Juan Egido <alberje@alberje.es>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *****************************************************************************/
using System;
using OpenMetaverse;

namespace aslaserver
{
	class MainClass
	{
        // GridClient is the primary class the library uses for almost all things
        private static OpenMetaverse.GridClient Client = new OpenMetaverse.GridClient();
			
        static void Main(string[] args)
        {
            if (Client.Network.Login("AlberSpa", "Resident", "", "asla.server", "0.1"))
            {
                // Yay we made it! let's print out the message of the day
                Console.WriteLine("You have successfully logged into Second Life!\n The Message of the day is {0}\nPress any Key to Logout", 
                    Client.Network.LoginMessage);
                
                Console.ReadLine(); // Wait for user to press a key before we continue
 
                Client.Network.Logout(); // Lets logout since we're done here
            }
            else
            {
                // tell the user why the login failed
                Console.WriteLine("We were unable to login to Second Life, The Login Server said: {0}",
                    Client.Network.LoginMessage);
            }
            Console.WriteLine("Press Any Key to Exit");
            Console.ReadLine(); // Wait for user to press a key before we exit
		}
	}
}
	