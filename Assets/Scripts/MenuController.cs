using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
//This file controls functions related to the main menu, including functions
//that load videos

public class MenuController : MonoBehaviour {
	public GameObject MainPanel;
	public GameObject SingleUserPanel;
	public GameObject AllUsersPanel;
	public RectTransform  UserListPanel;
	public Text PlayersText;
	public GameObject UserButton, Video1Button, Video2Button, Video3Button, Video4Button;
	public GameObject PlayButton, PauseButton, StopButton;
	private List<PhotonPlayer> playerList = new List<PhotonPlayer>();

	void Start(){

	}

	//This method is run once every frame. It checks if new devices have joined
	//and updates the menu accordingly.
	void Update(){

		if(PhotonNetwork.otherPlayers.Length != 0){
			foreach (PhotonPlayer player in PhotonNetwork.otherPlayers){
				if (playerList.Exists(x => x == player)){

				}
				else{
					playerList.Add(player);
					AddButton(player);
				}
			}
		}
		//Check if any of the users have paused their apps
		//It would likely indicate their headset has been taken off
		if(GameObject.Find("Paused(Clone)") != null){
			string signal = ( (int) GameObject.Find("Paused(Clone)").transform.position.x ).ToString();
			Debug.Log(signal + "paused");
			if (SingleUserPanel.transform.Find(signal).GetComponent<Text>()){
				Button paused_button = SingleUserPanel.transform.Find(signal).GetComponent<Button>();
				paused_button.GetComponent<Image>().color = Color.yellow;
				Text details = paused_button.transform.Find("TextDetails").GetComponent<Text>();
				details.text = "Paused/Headset removed";
			}
			Destroy(GameObject.Find("Paused(Clone)"));
		}
		//Check if any of the users have quit their apps
		//It would likely indicate their headset has been taken off
		if(GameObject.Find("Quit(Clone)") != null){
			string signal = ( (int) GameObject.Find("Quit(Clone)").transform.position.x ).ToString();
			Debug.Log(signal + "quit");
			if (SingleUserPanel.transform.Find(signal).GetComponent<Text>()){
				Button quit_button = SingleUserPanel.transform.Find(signal).GetComponent<Button>();
				quit_button.GetComponent<Image>().color = Color.red;
				Text details = quit_button.transform.Find("TextDetails").GetComponent<Text>();
				details.text = "Exited";
			}
			Destroy(GameObject.Find("Paused(Clone)"));
		}
	}
	//This method adds a button for each player detected. It then adds a listener
	//function to the button.
	void AddButton(PhotonPlayer player){
			GameObject user_button = (GameObject)Instantiate(UserButton);
			//Adds a button representing the user to the main panel
			user_button.transform.SetParent(UserListPanel, false);
			//Sets the text of that user to it's id#
			Text IDText = user_button.transform.Find("TextPlayerID").GetComponent<Text>();
			IDText.text = player.ID.ToString();
			user_button.name = player.ID.ToString();
			Button tempButton = user_button.GetComponent<Button>();
			tempButton.onClick.AddListener(() => SingleUserButtonClicked(player));
	}
	//This method hides the main panel and reveals and makes ready the panel for
	//each user
	void SingleUserButtonClicked(PhotonPlayer player){
		MainPanel.SetActive(false);
		SingleUserPanel.SetActive(true);
		int id = int.Parse(player.ID.ToString());
		Debug.Log ("Button clicked = " + id);

		Text IDTitleText = SingleUserPanel.transform.Find("PlayerIDTitleText").GetComponent<Text>();
		IDTitleText.text = player.ID.ToString();

		VideoTransmitter video_transmitter = new VideoTransmitter();

		Button tempButtonVideo1 = Video1Button.GetComponent<Button>();
		tempButtonVideo1.onClick.AddListener(() => video_transmitter.LoadScene("video1", id));
		Button tempButtonVideo2 = Video2Button.GetComponent<Button>();
		tempButtonVideo2.onClick.AddListener(() => video_transmitter.LoadScene("video2", id));
		Button tempButtonVideo3 = Video3Button.GetComponent<Button>();
		tempButtonVideo3.onClick.AddListener(() => video_transmitter.LoadScene("video3", id));
		Button tempButtonVideo4 = Video4Button.GetComponent<Button>();
		tempButtonVideo4.onClick.AddListener(() => video_transmitter.LoadScene("video4", id));

		Button tempButtonPlay = PlayButton.GetComponent<Button>();
		tempButtonPlay.onClick.AddListener(() => video_transmitter.Play(id));
		Button tempButtonPause = PauseButton.GetComponent<Button>();
		tempButtonPause.onClick.AddListener(() => video_transmitter.Pause(id));
		Button tempButtonStop = StopButton.GetComponent<Button>();
		tempButtonStop.onClick.AddListener(() => video_transmitter.Stop(id));
	}

	public void AllUsersButtonClicked(){
		MainPanel.SetActive(false);
		AllUsersPanel.SetActive(true);
	}

	public void BackToMenu(){
		MainPanel.SetActive(true);
		AllUsersPanel.SetActive(false);
		SingleUserPanel.SetActive(false);
	}

}
