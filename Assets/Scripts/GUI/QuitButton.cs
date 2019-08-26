using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour {
    public Button quitButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        quitButton.onClick.AddListener(quitPressed);
    }

    void quitPressed() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
