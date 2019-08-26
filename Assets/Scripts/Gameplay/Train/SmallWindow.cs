using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallWindow : Window {

    private int peopleInside;
    private int MAXPEOPLE = 75;
    private int MINPEOPLE = 0;

    public SmallWindow(int startPeopleInside) {
        peopleInside = startPeopleInside;
    }

    public void ComingInside(int incPeopleInside) {
        if(peopleInside + incPeopleInside < MAXPEOPLE)
         peopleInside += incPeopleInside;
    }

    public void ComingOutside(int decPeopleInside) {
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
