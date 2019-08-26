using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train {
    public Vagon vagonLeft;
    public Vagon vagonMiddle;
    public Vagon vagonRight;

    public Train() {
        vagonLeft = new Vagon(0);
        vagonMiddle = new Vagon(1);
        vagonRight = new Vagon(2);
    }
}
