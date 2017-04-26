using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This file contains functions that deal with sending streams of data between
//all the players in the lobby. I halfway implemented reading the time each
//tourist was at in their video, but it was unreliable if the app lost focus or
//the phone locked.
public class StatusReceiver : Photon.MonoBehaviour {
	public GameObject UserListPanel;

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
        Debug.Log(id);
        //Where the user is at in their video in milliseconds
				int current_time = (int)stream.ReceiveNext();
        Debug.Log(current_time);
        //The total length of the video in milliseconds
				int end_time = (int)stream.ReceiveNext();
        Debug.Log(end_time);
        //The name of the video in the form video.mp4
				string c = (string)stream.ReceiveNext();
        Debug.Log(c);


				foreach (Transform item in UserListPanel.transform) {
					string button_id = item.transform.FindChild("TextPlayerID").GetComponent<Text>().text;
					//if(button_id == id){
						string video_status = current_time.ToString() + "/" + end_time.ToString();
						Debug.Log(video_status);
						item.transform.FindChild("TextDetails").GetComponent<Text>().text = video_status;
					//}
				}
		}*/
	}


}
