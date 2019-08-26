using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPerson : MonoBehaviour {

    public Slider sliderStrength;
    public float speed;
    private Vector3 startPosition;
    Main m;
    // Use this for initialization
    void Start() {
        startPosition = transform.position;
        m = new Main();
        Debug.Log("HWWIWI" + m.getScale());
        sliderStrength.gameObject.SetActive(false);
        Application.targetFrameRate = 60;
    }

	// Update is called once per frame
	void Update () {
        Movement();
        Actions();
        Passives();
        sliderStrength.value = (float)m.getScale();
        if(m.getScale() == 0) {
            sliderStrength.gameObject.SetActive(false);
        }
	}

    private void OnTriggerStay2D(Collider2D collision) {
        m.setCurrentDoor(null);
        if (collision.gameObject.name == "LeftDoorV") {
            m.setCurrentDoor(m.train.vagonLeft.leftDoor);
        }
        if (collision.gameObject.name == "LeftDoorV2") {
            m.setCurrentDoor(m.train.vagonMiddle.leftDoor);
        }
        if (collision.gameObject.name == "LeftDoorV3") {
            m.setCurrentDoor(m.train.vagonRight.leftDoor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        m.setCurrentDoor(null);
    }

    void Movement () {
        //Debug.Log("Movement");
        Vector3 position = transform.position;
        Vector3 positionSlider = sliderStrength.transform.position;
        if (Input.GetKey(KeyCode.A) && position.x > -12) {
            //Debug.Log("Pressed A");
            transform.position = new Vector3(position.x - speed, position.y, position.z);
            sliderStrength.transform.position = new Vector3(positionSlider.x - speed, positionSlider.y, positionSlider.z);
            m.setScale(0);
        }
        if (Input.GetKey(KeyCode.D) && position.x < 12) {
            //Debug.Log("Pressed D");
            transform.position = new Vector3(position.x + speed, position.y, position.z);
            sliderStrength.transform.position = new Vector3(positionSlider.x + speed, positionSlider.y, positionSlider.z);
            m.setScale(0);
        }
    }

    void Actions () {
        double ss = m.getScale();
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Pressed E OPEEEEEEEEEEEEEEEEEEEEEEM");
            m.FusRoDah();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Pressed Space " + ss);
            if(ss < 1 && m.getCurrentDoor() != null) {
                m.setScale(ss + 0.05);
                m.PushingToVagon();
                sliderStrength.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Pressed Enter");
        }

        if (Input.GetKeyDown(KeyCode.RightShift)) {
            Debug.Log("Pressed RightShift");
        }
    }

    void Passives() {
        double ss = m.getScale();
        if (ss > 0) {
            //Debug.Log(ss);
            m.setScale(ss - 0.005);
        }
        if(ss < 0) {
            m.setScale(0);
        }
    }
}
