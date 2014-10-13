using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Server : MonoBehaviour {

	public int port = 25000;
	public int clients = 2;

	void startServer(){
		Network.InitializeServer(clients, port, false);
		Application.runInBackground = true;
	}

	void stopServer(){
		Network.Disconnect();
	}
	

	void OnGUI (){
		if(Network.peerType == NetworkPeerType.Disconnected) {
			GUILayout.Label("Server is not running");

			if(GUILayout.Button("Start Server")) {
				startServer();
			}
		}

		else if(Network.peerType == NetworkPeerType.Connecting) {
			GUILayout.Label("Server is starting");
		}

		else {
			GUILayout.Label("Server started");
			GUILayout.Label("Server Ip: " + Network.player.ipAddress + " Port: " + Network.player.port);
			GUILayout.Label("Clients: " + Network.connections.Length + "/" + clients);

			if(GUILayout.Button("Stop Server")) {
				stopServer();
			}
		}
	}
}
