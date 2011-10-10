//  
//  andserver.cs
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
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace aslaserver
{
	public class andserver
	{
		private TcpListener tcpListener;
    	private Thread listenThread;

	    public andserver () {
			this.tcpListener = new TcpListener (IPAddress.Any, 3000);
			this.listenThread = new Thread (new ThreadStart (ListenForClients));
			this.listenThread.Start ();
		}
		
		private void ListenForClients () {
			this.tcpListener.Start ();

			while (true) {
				//blocks until a client has connected to the server
				TcpClient client = this.tcpListener.AcceptTcpClient ();

				//create a thread to handle communication 
				//with connected client
				Thread clientThread = new Thread (new ParameterizedThreadStart (HandleClientComm));
				clientThread.Start (client);
			}
		}
		
		private void HandleClientComm (object client) {
			TcpClient tcpClient = (TcpClient)client;
			NetworkStream clientStream = tcpClient.GetStream ();

			byte[] message = new byte[4096];
			int bytesRead;

			while (true) {
				bytesRead = 0;

				try {
					//blocks until a client sends a message
					bytesRead = clientStream.Read (message, 0, 4096);
				}
				catch {
					//a socket error has occured
					break;
				}

				if (bytesRead == 0) {
					//the client has disconnected from the server
					break;
				}

				//message has successfully been received
				ASCIIEncoding encoder = new ASCIIEncoding ();
				Console.WriteLine (encoder.GetString (message, 0, bytesRead));
				byte[] buffer = encoder.GetBytes("01");
				clientStream.Write(buffer, 0 , buffer.Length);
				clientStream.Flush();
			}

			tcpClient.Close ();
		}

	}
}


