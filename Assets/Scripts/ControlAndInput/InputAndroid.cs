using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAndroid : MonoBehaviour {

    private PlayerControllerAndroid player;
    private float _cameraWidth;
    private Vector3 _camPosition;
    void Start()
    {
        player = GetComponent<PlayerControllerAndroid>();
        _cameraWidth = ResolutionManager.Instance.GetCameraWidth();
        _camPosition = ResolutionManager.Instance.GetCameraPosition();
    }
    
    void Update()
    {
        int nTouches = Input.touchCount;

        for(int i = 0; i<nTouches; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                //Lado Izquierdo
                if (touch.position.x < Screen.width * 0.2)
                    player.TouchLeft(touch);
                else if (touch.position.x > Screen.width * 0.8)
                    player.TouchRight(touch);
            }
        }
    }
}
