using UnityEngine;
using System.Collections;

//This class contains functions that control video playback of the users.
//They create gameobjects which are instantiated in every player's game. The players
//read this object in Update() and act appropriately. We did it this way
//because of endless bugs with RPCs and other official communication methods.
//A new addition to this is that the Vector3 is being used to carry a message.
//All users recieve the instantiated object and will check if the first float
//of the Vector3 is equal to their id after casting it from float to int.
//If it does or if it is 0 they will act on it, 0 representing a message intended
//for all users.
public class VideoTransmitter : MonoBehaviour {

	public void LoadScene (int video, int id) {
		Vector3 message =  new Vector3 (id,video,0);
		PhotonNetwork.Instantiate("VideoMessage", message, Quaternion.identity, 0);
		Debug.Log("Load video " + message);
	}

	public void Play (){
		PhotonNetwork.Instantiate("Play", Vector3.zero, Quaternion.identity, 0);
	}

	public void Play (int id){
		Vector3 message =  new Vector3 (id,0,0);
		PhotonNetwork.Instantiate("Play", message, Quaternion.identity, 0);
		Debug.Log(id + " Play");
	}

	public void Stop (){
		PhotonNetwork.Instantiate("Stop", Vector3.zero, Quaternion.identity, 0);
	}

	public void Stop (int id){
		Vector3 message =  new Vector3 (id,0,0);
		PhotonNetwork.Instantiate("Stop", message, Quaternion.identity, 0);
		Debug.Log(id + " Stop");
	}

	public void Pause (){
		PhotonNetwork.Instantiate("Pause", Vector3.zero, Quaternion.identity, 0);
	}

	public void Pause (int id){
		Vector3 message =  new Vector3 (id,0,0);
		PhotonNetwork.Instantiate("Pause", message, Quaternion.identity, 0);
		Debug.Log(id + " Pause");
	}

	public void Next (){
		PhotonNetwork.Instantiate("Next", Vector3.zero, Quaternion.identity, 0);
	}

	public void Previous (){
		PhotonNetwork.Instantiate("Previous", Vector3.zero, Quaternion.identity, 0);
	}
}
