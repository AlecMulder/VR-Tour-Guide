using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This file contains functions that control the initial networking.
//T
public class NetworkController : MonoBehaviour{
	//Note that in order for a tourist and tour leader to communicate, they must
	//be in the same room.
	string _room = "VR Tourism";
	public Text main_status_text;
	public Text user_status_text;


	void Start(){
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby(){
		main_status_text.text = "Connected";
		user_status_text.text = "Connected";
		Debug.Log("joined lobby");
		RoomOptions roomOptions = new RoomOptions() { };
		PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
	}

	void OnConnectionFail(){
		Debug.Log("Connection lost");
		main_status_text.text = "Connection lost, restart app";
		user_status_text.text = "Connection lost, restart app";
	}
}
