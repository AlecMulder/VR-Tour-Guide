using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
//This file contains functions that control the ui of the app, as well as some
//functions necessary to know when players connect and disconnect.

public class MenuController : MonoBehaviour {
	public GameObject MainPanel, UserPanel, UserButton;
	public GameObject LaunchButton, VideoInputField;
	public GameObject PlayButton, PauseButton, BackButton;
	public RectTransform  UserListPanel, VideoPanel;
	public Text UserTitleText;

	//Right now this just keeps track of who's already been added to the MainPanel
	//so they are only added once. Not fully implemented, candidate for removal.
	private List<PhotonPlayer> player_list = new List<PhotonPlayer>();

	//This method is run when the object the script is attached to is instantiated
	//In this case it is run when the game loads
	void Start(){

	}

	//This method is run once every frame.
	void Update(){

	}
	//Called whenever a player joins the lobby.
	//BUG: this is called when a tour guide joins the lobby as well as when a
	//BUG: tourist joins the lobby. This results in the tour guide being given a
	//BUG: button, which could be confusing for end users. Not urgent though
	//BUG: because it's unlikely that two people will be using tour guide at the
	//BUG: same time
	void OnPhotonPlayerConnected(PhotonPlayer new_player){
		Debug.Log("Somebody connected");
		foreach (PhotonPlayer player in PhotonNetwork.otherPlayers){
			//If player is already in player_list
			if (player_list.Exists(x => x == player)){

			}
			else{
				player_list.Add(player);
				AddUserButton(player);
			}
		}
	}

	//This method adds a button for each player detected. It then adds a listener
	//function to the button.
	void AddUserButton(PhotonPlayer player){
		Debug.Log("So they get a button");
		GameObject user_button = (GameObject)Instantiate(UserButton);
		//Adds a button representing the user to the main panel
		user_button.transform.SetParent(UserListPanel, false);
		//Sets the text of that user to it's id#
		Text IDText = user_button.transform.Find("TextPlayerID").GetComponent<Text>();
		IDText.text = player.ID.ToString();
		user_button.name = player.ID.ToString();
		int id = int.Parse(player.ID.ToString());
		Button tempButton = user_button.GetComponent<Button>();
		tempButton.onClick.AddListener(() => UserButtonClicked(id));
	}

	void OnPhotonPlayerDisconnected(PhotonPlayer explayer){
		Debug.Log("Somebody disconnected");
		foreach (PhotonPlayer player in player_list){
			if (Array.Exists(PhotonNetwork.otherPlayers, x => x == player)){

			}
			else{
				player_list.Remove(player);
				RemoveUserButton(player);
			}
		}
	}

	//Turns the button on the main page that represents the player that left the
	//game red, waits, then removes it and closes the page that represents that player.
	void RemoveUserButton(PhotonPlayer player){
		Debug.Log("So their button is going away");
		Text TitleText = UserPanel.transform.Find("TitleText").GetComponent<Text>();
		if(player.ID.ToString() == TitleText.text) BackToMenu();
		foreach (Transform user_button in UserListPanel)
    {
			if(player.ID.ToString() == user_button.name){
				StartCoroutine(TurnRedWaitDestroy(user_button));
			}
    }
	}

	//Called by RemoveUserButton(), turns a button red for 5 seconds, then deletes
	//the button
	private IEnumerator TurnRedWaitDestroy(Transform user_button){
		user_button.GetComponent<Image>().color = Color.red;
		user_button.GetComponent<Button>().interactable = false;
		yield return StartCoroutine(WaitForRealSeconds(5));
		Destroy(user_button.gameObject);
  }
	//This is a hack required to ensure that the button actually stays red for 5s
	private static IEnumerator WaitForRealSeconds(float time){
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + time){
				yield return null;
		}
	}

	//Deactivates all and single user panels and activates the main panel
	public void BackToMenu(){
		MainPanel.SetActive(true);
		UserPanel.SetActive(false);
	}

	//This method hides the main panel and reveals and makes ready the panel for
	//each user by assigning values to all of the labels and buttons
	public void UserButtonClicked(int id){
		MainPanel.SetActive(false);
		UserPanel.SetActive(true);
		Debug.Log ("Button clicked = " + id);
		if(id == 0) {
			UserTitleText.text = "All Players";
		}else{
			UserTitleText.text = id.ToString();
		}

		VideoTransmitter video_transmitter = new VideoTransmitter();

		Button temp_launch_button = LaunchButton.GetComponent<Button>();
		temp_launch_button.onClick.AddListener(() => LaunchButtonClicked(id));
		Button temp_play_button = PlayButton.GetComponent<Button>();
		temp_play_button.onClick.AddListener(() => video_transmitter.Play(id));
		Button temp_pause_button = PauseButton.GetComponent<Button>();
		temp_pause_button.onClick.AddListener(() => video_transmitter.Pause(id));

	}
	//This is activated by the big launch button on the user panel. It checks the
	//value of the field and launches the specified video.
	public void LaunchButtonClicked(int id){
		VideoTransmitter video_transmitter = new VideoTransmitter();
		Text video_input_text = VideoInputField.transform.Find("Text").GetComponent<Text>();
		int video = int.Parse(video_input_text.text);
		video_transmitter.LoadScene(video, id);
	}

}
