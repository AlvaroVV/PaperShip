using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPC : MonoBehaviour {

    public float speed = 1;

    public SpriteRenderer boat;
    public GameObject leftSensor;
    public GameObject rightSensor;

    private GameObject PlayerLeft;
    private GameObject PlayerRight;

	private ResolutionManager ResManager;

    public GameObject WaterWave;

    void Start()
    {
		ResManager = ResolutionManager.Instance;
        PlayerLeft = GameObject.FindGameObjectWithTag("PlayerLeft");
        PlayerRight = GameObject.FindGameObjectWithTag("PlayerRight");
    }

    public void MoveUpLeft()
    {
		if(PlayerLeft.transform.position.y <  ResManager.GetCameraPosition().y + ResManager.GetCameraHeight()/2)
			PlayerLeft.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void MoveDownLeft()
	{
		if (PlayerLeft.transform.position.y > ResManager.GetCameraPosition().y - ResManager.GetCameraHeight() / 2)
			PlayerLeft.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    public void MoveUpRight()
	{
		if (PlayerRight.transform.position.y < ResManager.GetCameraPosition().y + ResManager.GetCameraHeight() / 2)
			PlayerRight.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void MoveDownRight()
	{
		if (PlayerRight.transform.position.y > ResManager.GetCameraPosition().y - ResManager.GetCameraHeight() / 2)
			PlayerRight.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    public void ThrowStoneLeft()
    {
        Vector3 vector;
        if ((PlayerLeft.transform.position.y <= boat.transform.position.y + boat.sprite.bounds.extents.y)
            && (PlayerLeft.transform.position.y >= boat.transform.position.y - boat.sprite.bounds.extents.y))
        {
            vector = new Vector3(leftSensor.transform.position.x,
                                    PlayerLeft.transform.position.y,
                                    PlayerLeft.transform.position.z);
        }
        else
        {
            vector = new Vector3(ResolutionManager.Instance.GetCameraPosition().x,
                                PlayerLeft.transform.position.y,
                                PlayerLeft.transform.position.z);
        }

        Instantiate(WaterWave, vector, Quaternion.identity);

    }

    public void ThrowStoneRight()
    {
        Vector3 vector;
        if ((PlayerRight.transform.position.y <= boat.transform.position.y + boat.sprite.bounds.extents.y)
            && (PlayerRight.transform.position.y >= boat.transform.position.y - boat.sprite.bounds.extents.y))
        {
            vector = new Vector3(rightSensor.transform.position.x,
                                    PlayerRight.transform.position.y,
                                    PlayerRight.transform.position.y);
        }
        else
        {
            vector = new Vector3(ResolutionManager.Instance.GetCameraPosition().x,
                                PlayerRight.transform.position.y,
                                PlayerRight.transform.position.z);
        }

        Instantiate(WaterWave, vector, Quaternion.identity);
    }
    
}
