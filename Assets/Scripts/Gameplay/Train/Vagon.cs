using System;
using System.Collections;
using System.Collections.Generic;

public class Vagon {
    public LargeWindow middleWindow;
    public SmallWindow leftWindow;
    public SmallWindow rightWindow;
    public Door leftDoor;
    public Door rightDoor;
    static Random rnd = new Random();

    private int mWPeople = rnd.Next(30, 90);
    private int lWPeople = rnd.Next(15, 45);
    private int rWPeople = rnd.Next(15, 45);
    private int lDPeopleInside = rnd.Next(20, 60);
    private int rDPeopleInside = rnd.Next(20, 60);
    private int lDPeopleOutside = rnd.Next(150, 270);
    private int rDPeopleOutside = rnd.Next(150, 270);


    public Vagon(int num) {
        middleWindow = new LargeWindow(mWPeople);
        leftWindow = new SmallWindow(lWPeople);
        rightWindow = new SmallWindow(rWPeople);
        leftDoor = new Door(lDPeopleInside, num * 2, leftWindow, middleWindow);
        rightDoor = new Door(rDPeopleInside, num * 2 + 1, rightWindow, middleWindow);
    }
}
