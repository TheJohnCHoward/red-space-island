using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NetworkView))]
public class NetworkHandler : MonoBehaviour
{

	private string gameName = "Game name";
	private int players = 0;
	public GameObject background, play, quit;
	public bool showNetworkInterface;
	
	void Awake() {
		MasterServer.ClearHostList(); // Clear host list
	}
	
	void OnGUI() {
		if (showNetworkInterface) {
			// Display interface for server hosting lobby
			if (Network.isServer) {
				players = Network.connections.Length;
				string data = players + "/1 players connected";
				GUILayout.Label (data);
				if (GUILayout.Button ("Stop Server")) {
					Network.Disconnect();
					MasterServer.UnregisterHost();
					print ("Server Stopped");
				}
				if (true) {
					if (GUILayout.Button ("Start Game")) {
						//MasterServer.UnregisterHost();
						Network.maxConnections = -1;
						MasterServer.RegisterHost("Red Space Island", gameName, "Closed");
						Network.RemoveRPCsInGroup(0);
						// Need to update when we get character select screen
						networkView.RPC( "LoadLevel", RPCMode.AllBuffered, "Level1", 1);
					}
				}
			}
			// Display interface for client in lobby
			else if (Network.isClient) {
				string wait = "Please wait...";
				GUILayout.Label (wait);
				if (GUILayout.Button ("Disconnect")) {
					Network.Disconnect ();
				}
			}
			// Display interface for disconnected players
			else if (Network.peerType == NetworkPeerType.Disconnected){
				GUILayout.BeginHorizontal();
				gameName = GUILayout.TextField (gameName, 25, GUILayout.MinWidth(100));
				//description = GUILayout.TextField (description, 25, GUILayout.MinWidth(100));
				if (GUILayout.Button ("Start Server")) {
					// Use NAT punchthrough if no public IP present
					Network.InitializeServer (1, 25002, !Network.HavePublicAddress ());
					MasterServer.RegisterHost ("Red Space Island", gameName, "Open");
					GUILayout.EndHorizontal();
				} else {
					// Start Server
					GUILayout.EndHorizontal();
					// Get latest host list
					MasterServer.RequestHostList ("Red Space Island");
					HostData[] data = MasterServer.PollHostList();
					// Go through all the hosts in the host list
					foreach (HostData val in data) {
						if (val.comment == "Closed")
							continue;
						GUILayout.BeginHorizontal();
						string name = val.gameName + " " + val.connectedPlayers + "/" + val.playerLimit + "\n";
						GUILayout.Label(name);
						GUILayout.FlexibleSpace();
						/*string hostInfo;
						hostInfo = "[";
						foreach (string host in val.ip) 
							hostInfo = hostInfo + host + ":" + val.port + " ";
						hostInfo = hostInfo + "]";
						GUILayout.Label (hostInfo);
						GUILayout.Space (5);*/
						//GUILayout.Label (val.comment);
						//GUILayout.Space (5);
						//GUILayout.FlexibleSpace();
						if (GUILayout.Button ("Connect")) {
							// Connect to HostData struct, internally the correct method is used (GUID when using NAT).
							Network.Connect (val);
						}
						GUILayout.EndHorizontal();
					}
				}
			}
			if (GUILayout.Button ("Main Menu")) {
				showNetworkInterface = false;
				background.renderer.enabled = true;
				play.renderer.enabled = true;
				play.collider.enabled = true;
				quit.renderer.enabled = true;
				quit.collider.enabled = true;
			}
		}
	}
	
	void OnFailedToConnect(NetworkConnectionError error) {
		Debug.Log("Could not connect to server: " + error);
	}
	
	// Load the game
	[RPC]
	void LoadLevel(string level, int levelPrefix) {
		Network.SetSendingEnabled(0, false);
		Network.isMessageQueueRunning = false;
		Network.SetLevelPrefix(levelPrefix);
		Application.LoadLevel(level);
		Network.SetSendingEnabled(0, true);
		Network.isMessageQueueRunning = true;
	}
	
	// from menu
	/*void OnDisconnectedFromServer(NetworkDisconnection info) {
		Application.LoadLevel(0);
	}
	
	void OnPlayerDisconnected(NetworkPlayer player) {
		Network.RemoveRPCs(player, 0);
		Network.DestroyPlayerObjects(player);
		networkView.RPC("playerDisconnected", RPCMode.AllBuffered);
	}
	
	[RPC]
	void playerDisconnected() {
		dc = true;
	}*/
}

