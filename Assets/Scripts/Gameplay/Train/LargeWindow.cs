using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeWindow : Window {

    private int peopleInside;
    private int MAXPEOPLE = 150;
    private int MINPEOPLE = 0;

    public LargeWindow(int peopleInside) {
        this.peopleInside = peopleInside;
    }

    public override void ComingInside(int incPeopleInside) {
        Debug.Log("LARGA WINDOW");
        if (peopleInside + incPeopleInside < MAXPEOPLE)
            peopleInside += incPeopleInside;
    }

    public override void ComingOutside(int decPeopleInside) {
        Debug.Log("LARGA WINDOW");
        if (peopleInside - decPeopleInside > MINPEOPLE)
            peopleInside -= decPeopleInside;
    }

    bool isFree() {
        return peopleInside < MAXPEOPLE;
    }

    public int getPeopleFree() {
        return MAXPEOPLE - peopleInside;
    }
}
