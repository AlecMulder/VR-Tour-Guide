using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkController : MonoBehaviour{
	string _room = "VR Tourism";
	public Text PlayersText;

	void Start(){
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby(){
		PlayersText.text = "Connected";
		Debug.Log("joined lobby");
		RoomOptions roomOptions = new RoomOptions() { };
		PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
	}

	void OnConnectionFail(){
		PlayersText.text = "Connection lost, restart app";
	}
}
