using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOverlayScript : MonoBehaviour {

    public Image ScreenOverlay;

	public void SetOverlayEnabled(bool _b)
    {
        ScreenOverlay.enabled = _b;
    }
}
