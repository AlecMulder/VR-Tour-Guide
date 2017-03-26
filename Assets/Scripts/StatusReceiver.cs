using UnityEngine;
using System.Collections;

//
public class StatusReceiver : Photon.MonoBehaviour {

	void Start (){

		//this ensures that only you can control your player
		if (photonView.isMine){

		}
	}
		void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){/*
			//This sends your data to the other players in the same room
			if (stream.isWriting){
        stream.SendNext("id");
				stream.SendNext(1);
				stream.SendNext(1);
				stream.SendNext("string");
			}
			//This recieves information from other players in the same room
			else{
        string id = (string)stream.ReceiveNext();
        //Debug.Log(id);
        //Where the user is at in their video in milliseconds
				int a = (int)stream.ReceiveNext();
        //Debug.Log(a);
        //The total length of the video in milliseconds
				int b = (int)stream.ReceiveNext();
        //Debug.Log(b);
        //The name of the video in the form video.mp4
				string c = (string)stream.ReceiveNext();
      //  Debug.Log(c);
			}*/
		}


}
