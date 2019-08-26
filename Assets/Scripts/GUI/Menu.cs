using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button startButton;
    public Button quitButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        startButton.onClick.AddListener(playPressed);
        quitButton.onClick.AddListener(quitPressed);
	}

    void playPressed () {
        SceneManager.LoadScene("Game");
    }

    void quitPressed () {
        Application.Quit();
    }
}
