using UnityEngine;
using System.Collections;

public class VideoFunctions : MonoBehaviour {

	//This function takes the name of a video as an argument and creates a matching
	//gameobject which is instantiated on every player's game. The players read
	//this object in Update() and launch the appropriate video. We did it this way
	//because of endless bugs with RPCs and other official communication methods.
	public void LoadScene (string destination, string id) {
		PhotonNetwork.Instantiate(destination, Vector3.zero, Quaternion.identity, 0);
	}

	public void Play (){
		PhotonNetwork.Instantiate("Play", Vector3.zero, Quaternion.identity, 0);
	}

	public void Play (string id){
		PhotonNetwork.Instantiate("Play", Vector3.zero, Quaternion.identity, 0);
	}

	public void Stop (){
		PhotonNetwork.Instantiate("Stop", Vector3.zero, Quaternion.identity, 0);
	}

	public void Pause (){
		PhotonNetwork.Instantiate("Pause", Vector3.zero, Quaternion.identity, 0);
	}

	public void Next (){
		PhotonNetwork.Instantiate("Next", Vector3.zero, Quaternion.identity, 0);
	}

	public void Previous (){
		PhotonNetwork.Instantiate("Previous", Vector3.zero, Quaternion.identity, 0);
	}
}
