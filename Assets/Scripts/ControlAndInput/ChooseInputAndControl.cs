using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseInputAndControl : MonoBehaviour {

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            GetComponent<InputAndroid>().enabled = true;
            GetComponent<PlayerControllerAndroid>().enabled = true;
        }
        else
        {
            GetComponent<InputPC>().enabled = true;
            GetComponent<PlayerControllerPC>().enabled = true;
        }

    }

}
