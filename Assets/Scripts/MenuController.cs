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
	public RectTransform  UserListPanel, VideoPanel;
	public GameObject UserButton;
	public GameObject Video1Button, Video2Button, Video3Button, Video4Button;
	public GameObject Video5Button, Video6Button, Video7Button, Video8Button;
	public GameObject Video9Button, Video10Button, Video11Button, Video12Button;
	public GameObject Video13Button, Video14Button, Video15Button, Video16Button;
	public GameObject Video17Button;

	public GameObject PlayButton, PauseButton, StopButton;

	//Hopefully I end up using this for something big, right now it just keeps track
	//of who's already been added to the MainPanel
	private List<PhotonPlayer> player_list = new List<PhotonPlayer>();

	void Start(){

	}
	//This method is run once every frame.
	void Update(){
/*
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
		}*/
	}
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
		Button tempButton = user_button.GetComponent<Button>();
		tempButton.onClick.AddListener(() => SingleUserButtonClicked(player));
	}
	//Turns the button on the main page that represents the player that left the
	//game red, waits, then removes it and closes the page that represents that player.
	void RemoveUserButton(PhotonPlayer player){
		Debug.Log("So their button is going away");
		BackToMenu();
		foreach (Transform user_button in UserListPanel)
    {
			if(player.ID.ToString() == user_button.name){
				StartCoroutine(TurnRedWaitDestroy(user_button));
			}
    }
	}
	//
	private IEnumerator TurnRedWaitDestroy(Transform user_button){
		user_button.GetComponent<Image>().color = Color.red;
		yield return StartCoroutine(WaitForRealSeconds(5));
		Destroy(user_button.gameObject);
  }
	private static IEnumerator WaitForRealSeconds(float time){
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + time){
				yield return null;
		}
	}
	//Deactivates all and single user panels and activates the main panel
	public void BackToMenu(){
		MainPanel.SetActive(true);
		AllUsersPanel.SetActive(false);
		SingleUserPanel.SetActive(false);
	}
	//Hides the main panel and reveals the panel that controls all users
	public void AllUsersButtonClicked(){
		MainPanel.SetActive(false);
		AllUsersPanel.SetActive(true);
	}
	void LaunchVideoClick(){

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
		/*
		int video_number = 17;
		for (int i = 1; i <= video_number; i++){
			GameObject video_button = (GameObject)Instantiate(VideoButton);
			video_button.transform.SetParent(VideoPanel);
			Button temp_video_button = video_button.GetComponent<Button>();
			temp_video_button.onClick.AddListener(() => video_transmitter.LoadScene(i, id));
			//temp_video_button.text(id);
		}
		*/
		Button tempButtonVideo1 = Video1Button.GetComponent<Button>();
		tempButtonVideo1.onClick.AddListener(() => video_transmitter.LoadScene(1, id));
		Button tempButtonVideo2 = Video2Button.GetComponent<Button>();
		tempButtonVideo2.onClick.AddListener(() => video_transmitter.LoadScene(2, id));
		Button tempButtonVideo3 = Video3Button.GetComponent<Button>();
		tempButtonVideo3.onClick.AddListener(() => video_transmitter.LoadScene(3, id));
		Button tempButtonVideo4 = Video4Button.GetComponent<Button>();
		tempButtonVideo4.onClick.AddListener(() => video_transmitter.LoadScene(4, id));
		Button tempButtonVideo5 = Video5Button.GetComponent<Button>();
		tempButtonVideo5.onClick.AddListener(() => video_transmitter.LoadScene(5, id));

		Button tempButtonVideo6 = Video6Button.GetComponent<Button>();
		tempButtonVideo6.onClick.AddListener(() => video_transmitter.LoadScene(6, id));
		Button tempButtonVideo7 = Video7Button.GetComponent<Button>();
		tempButtonVideo7.onClick.AddListener(() => video_transmitter.LoadScene(7, id));
		Button tempButtonVideo8 = Video8Button.GetComponent<Button>();
		tempButtonVideo8.onClick.AddListener(() => video_transmitter.LoadScene(8, id));
		Button tempButtonVideo9 = Video9Button.GetComponent<Button>();
		tempButtonVideo9.onClick.AddListener(() => video_transmitter.LoadScene(9, id));
		Button tempButtonVideo10 = Video10Button.GetComponent<Button>();
		tempButtonVideo10.onClick.AddListener(() => video_transmitter.LoadScene(10, id));

		Button tempButtonVideo11 = Video11Button.GetComponent<Button>();
		tempButtonVideo11.onClick.AddListener(() => video_transmitter.LoadScene(11, id));
		Button tempButtonVideo12 = Video12Button.GetComponent<Button>();
		tempButtonVideo12.onClick.AddListener(() => video_transmitter.LoadScene(12, id));
		Button tempButtonVideo13 = Video13Button.GetComponent<Button>();
		tempButtonVideo13.onClick.AddListener(() => video_transmitter.LoadScene(13, id));
		Button tempButtonVideo14 = Video14Button.GetComponent<Button>();
		tempButtonVideo14.onClick.AddListener(() => video_transmitter.LoadScene(14, id));
		Button tempButtonVideo15 = Video15Button.GetComponent<Button>();
		tempButtonVideo15.onClick.AddListener(() => video_transmitter.LoadScene(15, id));

		Button tempButtonVideo16 = Video16Button.GetComponent<Button>();
		tempButtonVideo16.onClick.AddListener(() => video_transmitter.LoadScene(16, id));
		Button tempButtonVideo17 = Video17Button.GetComponent<Button>();
		tempButtonVideo17.onClick.AddListener(() => video_transmitter.LoadScene(17, id));

		Button tempButtonPlay = PlayButton.GetComponent<Button>();
		tempButtonPlay.onClick.AddListener(() => video_transmitter.Play(id));
		Button tempButtonPause = PauseButton.GetComponent<Button>();
		tempButtonPause.onClick.AddListener(() => video_transmitter.Pause(id));
		Button tempButtonStop = StopButton.GetComponent<Button>();
		tempButtonStop.onClick.AddListener(() => video_transmitter.Stop(id));
	}

}
