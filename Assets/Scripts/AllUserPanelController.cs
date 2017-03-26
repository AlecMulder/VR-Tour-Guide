using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
//This file controls functions related to the main menu, including functions
//that load videos

public class AllUserPanelController : MonoBehaviour {
	public GameObject MainPanel;
	public GameObject SingleUserPanel;
	public GameObject AllUsersPanel;
	public RectTransform VideoPanel;
	public GameObject Video1Button, Video2Button, Video3Button, Video4Button;
	public GameObject Video5Button, Video6Button, Video7Button, Video8Button;
	public GameObject Video9Button, Video10Button, Video11Button, Video12Button;
	public GameObject Video13Button, Video14Button, Video15Button, Video16Button;
	public GameObject Video17Button;

	public GameObject PlayButton, PauseButton, StopButton;

	//Hopefully I end up using this for something big, right now it just keeps
	//of who's already been added to the MainPanel
	private List<PhotonPlayer> playerList = new List<PhotonPlayer>();

	void Start(){

	}

	void Update(){

	}

	//Hides the main panel and reveals the panel that controls all users
	public void AllUsersButtonClicked(){
		MainPanel.SetActive(false);
		AllUsersPanel.SetActive(true);
		int id = 0;

		VideoTransmitter video_transmitter = new VideoTransmitter();

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
		Button tempButtonVideo10 = Video2Button.GetComponent<Button>();
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

	//Deactivates all and single user panels and activates the main panel
	public void BackToMenu(){
		MainPanel.SetActive(true);
		AllUsersPanel.SetActive(false);
		SingleUserPanel.SetActive(false);
	}

}
