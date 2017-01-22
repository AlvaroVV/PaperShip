using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorBoat : MonoBehaviour {

    public BoatController boatController;
    public float timeToReset = 2;
    public SensorSide sensorside;
    public enum SensorSide
    {
        LEFT,
        RIGHT,
    }
    private bool sensorActive;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wave") && !sensorActive)
        {
            sensorActive = true;
            if (sensorside == SensorSide.LEFT)
                boatController.SetActiveLeftSensor(true);
            else
                boatController.SetActiveRightSensor(true);

            if (boatController.ReadyToJump())
                boatController.Jump();

            StartCoroutine(TimeToReset());

        }
    }

    IEnumerator TimeToReset()
    {
        yield return new WaitForSeconds(timeToReset);
        sensorActive = false;
        if (sensorside == SensorSide.LEFT)
            boatController.SetActiveLeftSensor(false);
        else
            boatController.SetActiveRightSensor(false);
    }
	
}
