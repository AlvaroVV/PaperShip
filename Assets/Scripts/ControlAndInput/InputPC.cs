using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : MonoBehaviour {

    private PlayerControllerPC player;

    public float axisThreshold = .25f;

    public string axisControlLeft;  
    public string ButtonShootLeft;

    public string axisControlRight;
    public string ButtonShootRight;

    void Start()
    {
        player = GetComponent<PlayerControllerPC>();
    }

    void Update()
    {
        float axisLeft = Input.GetAxis(axisControlLeft);
        float axisRight = Input.GetAxis(axisControlRight);

        if (axisLeft < -axisThreshold)
            player.MoveUpLeft();
        else if (axisLeft > axisThreshold)
            player.MoveDownLeft();

        if (axisRight < -axisThreshold)
            player.MoveUpRight();
        else if (axisRight > axisThreshold)
            player.MoveDownRight();

        if (Input.GetButtonDown(ButtonShootLeft))
            player.ThrowStoneLeft();
        if (Input.GetButtonDown(ButtonShootRight))
            player.ThrowStoneRight();
    }


}
