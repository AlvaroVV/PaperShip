﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour {

	public void DestroyMySelf()
    {
        Destroy(gameObject);
    }
}
