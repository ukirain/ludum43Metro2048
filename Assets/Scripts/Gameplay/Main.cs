using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Train train;
    int[] perron = { 0, 0, 0, 0, 0, 0 };
    private double scaleStrength = 0;
    private Door currentDoor;
	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 30;
    }
	
    public Main() {
        train = new Train();
        System.Random rnd = new System.Random();
        for (int i = 0; i < 6; i++) {
            perron[i] = rnd.Next(200, 500);
        }
        scaleStrength = 0.01;
        stats();
        currentDoor = null;
    }

	// Update is called once per frame
	void Update () {
        
	}

    public void PushingToVagon() {
        if (currentDoor != null) {
            Door door = currentDoor;
            int numDoor = door.getNum();
            if (perron[numDoor] > 0) {
                int peopleToDoor = (int)System.Math.Round(perron[numDoor] * scaleStrength * 0.1);
                if (!door.ComingInside(peopleToDoor)) {
                    Debug.Log("Hey Stop");
                }
                else {
                    perron[numDoor] -= peopleToDoor;
                }
            }
            //Debug.Log("People" + perron[numDoor]);
            stats();
        } else {
            Debug.Log("Error: currentDoor isnt pick");
        }
    }

    public void FusRoDah() { //орем, громко орем
        if (currentDoor != null) {
            Door door = currentDoor;
            LargeWindow lwnd = door.getLwnd();
            SmallWindow swnd = door.getSwnd();
            Debug.Log("FUS");
            stats();
            if (lwnd.isFree()) {
                door.ComingToWindow(lwnd, System.Math.Min(door.getPeopleInside(), lwnd.getPeopleFree()));
                Debug.Log("Ro2 " + door.getPeopleInside() + " Ro2 " + lwnd.getPeopleFree());
            }
            if (door.getPeopleInside() != 0) {
                if (swnd.isFree()) {
                    door.ComingToWindow(swnd, System.Math.Min(door.getPeopleInside(), lwnd.getPeopleFree()));
                    Debug.Log("Ro3 " + door.getPeopleInside() + " Ro2 " + lwnd.getPeopleFree());
                }
            }
            Debug.Log("Ro" + door.getPeopleInside());
            stats();
        } else {
            Debug.Log("Error: currentDoor isnt pick");
        }
    }


    public double getScale() {
        return scaleStrength;
    }

    public void setScale(double pScaleStrength) {
        scaleStrength = pScaleStrength;
    }

    void stats() {
        Debug.Log("Perron: " + perron[0] + " " + perron[1] + " " + perron[2] + " " + perron[3] + " " + perron[4] + " "
             + perron[5] + " ");
        Debug.Log("Doors: ");
        Debug.Log(train.vagonLeft.leftDoor.getPeopleInside());
        Debug.Log(train.vagonLeft.rightDoor.getPeopleInside());
        Debug.Log(train.vagonMiddle.leftDoor.getPeopleInside());
        Debug.Log(train.vagonMiddle.rightDoor.getPeopleInside());
        Debug.Log(train.vagonRight.leftDoor.getPeopleInside());
        Debug.Log(train.vagonRight.rightDoor.getPeopleInside());

        Debug.Log("Windows: ");
        Debug.Log(train.vagonLeft.leftWindow.getPeopleFree());
        Debug.Log(train.vagonLeft.middleWindow.getPeopleFree());
        Debug.Log(train.vagonMiddle.leftWindow.getPeopleFree());
        Debug.Log(train.vagonMiddle.rightWindow.getPeopleFree());
        Debug.Log(train.vagonRight.rightWindow.getPeopleFree());
        Debug.Log(train.vagonRight.leftWindow.getPeopleFree());
    }

    public Door getCurrentDoor() {
        return currentDoor;
    }

    public void setCurrentDoor(Door door) {
        currentDoor = door;
    }
}
