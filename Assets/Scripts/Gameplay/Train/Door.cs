using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door {

    private int peopleInside;
    private int MAXPEOPLE = 100;
    private int MINPEOPLE = 0;
    private int n = 0;
    private SmallWindow swnd;
    private LargeWindow lwnd;

    public Door(int startPeopleInside, int num, SmallWindow pswnd, LargeWindow plwnd) {
        peopleInside = startPeopleInside;
        n = num;
        swnd = pswnd;
        lwnd = plwnd;
    }

    public bool ComingInside(int peopleOutside) {
        if (peopleInside + peopleOutside < MAXPEOPLE) {
            peopleInside += peopleOutside;
            Debug.Log("People inside: " + peopleInside);
            return true;
        } else {
            Debug.Log("So many people at door");
            peopleOutside = MAXPEOPLE - peopleInside;
            peopleInside = MAXPEOPLE;
            return false;
        }
    }

    public void ComingOutside(int decPeopleInside) {
        if (peopleInside - decPeopleInside > MINPEOPLE) {
            peopleInside -= decPeopleInside;
        } else {
            peopleInside = 0;
            Debug.Log("Zero people at door");
        }
    }

    public void ComingToWindow(Window selectedWindow, int peopleTransfeting) {
        selectedWindow.ComingInside(peopleTransfeting);
        ComingOutside(peopleTransfeting);
    }

    public int getNum() {
        return n;
    }

    public int getPeopleInside() {
        return peopleInside;
    }

    public SmallWindow getSwnd() {
        return swnd;
    }

    public LargeWindow getLwnd() {
        return lwnd;
    }
}
