using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window {

    private int peopleInside;

    public Window() {

    }

    Window(int startPeopleInside) {
        peopleInside = startPeopleInside;
    }

    public virtual void ComingInside(int incPeopleInside) {
        Debug.Log("WINDOW");
    }

    public virtual void ComingOutside(int decPeopleInside) {

    }

    public bool isFree() {
        return true;
    }
}
