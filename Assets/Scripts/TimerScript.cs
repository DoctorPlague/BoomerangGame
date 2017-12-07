using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    public Text timerLabel;
    public Text speedLabel;
    public Image ScreenOverlay;
    public BoomerangController Boomerang;
    private float time;

    void Update()
    {
        if (ScreenOverlay.isActiveAndEnabled == false)
        {
            time += Time.deltaTime;
            float seconds = time % 60;//Use the euclidean division for the seconds.  
            float fraction = (time * 100) % 100;

            //update the label values
            timerLabel.text = "Time Elapsed: " + (short)seconds + "." + (short)fraction;
            speedLabel.text = "Speed: " + Boomerang.fSpeed;
        }
    }

}
