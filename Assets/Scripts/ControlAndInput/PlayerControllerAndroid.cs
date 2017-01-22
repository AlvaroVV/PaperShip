using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerAndroid : MonoBehaviour {

    public float speed = 1;
    public Text text_1;
    public Text text_2;
    public Text text_3;

    public SpriteRenderer boat;
    public GameObject leftSensor;
    public GameObject rightSensor;

    private GameObject PlayerLeft;
    private GameObject PlayerRight;

    private Vector3 positionLeft;
    private Vector3 positionRight;

    public GameObject WaterWave;

    void Start()
    {
        PlayerLeft = GameObject.FindGameObjectWithTag("PlayerLeft");
        PlayerRight = GameObject.FindGameObjectWithTag("PlayerRight");

        positionLeft = PlayerLeft.transform.position;
        positionRight = PlayerRight.transform.position; 
    }


    public void TouchLeft(Touch touch)
    {
        if((touch.position.y> PlayerLeft.transform.position.y) || (touch.position.y < PlayerLeft.transform.position.y))
        {
            Vector3 vector = Camera.main.ScreenToWorldPoint(touch.position);
            MoveLeft(vector);
        }
        

    }

    private void MoveLeft(Vector3 position)
    {
        //PlayerLeft.transform.position = new Vector3(PlayerLeft.transform.position.x,position.y,PlayerLeft.transform.position.z);
        positionLeft = new Vector3(PlayerLeft.transform.position.x,
                                    position.y,
                                    PlayerLeft.transform.position.z);
    }

    private void ShootLeft()
    {

    }

    public void TouchRight(Touch touch)
    {
        if ((touch.position.y > PlayerRight.transform.position.y) || (touch.position.y < PlayerRight.transform.position.y))
        {
            Vector3 vector = Camera.main.ScreenToWorldPoint(touch.position);
            MoveRight(vector);
        }
    }

    private void MoveRight(Vector3 position)
    {
        positionRight = new Vector3(PlayerRight.transform.position.x,
                                  position.y,
                                  PlayerRight.transform.position.z);
    }

    void Update()
    {
        MoveTo(PlayerLeft, positionLeft);
    }

    private void MoveTo(GameObject player, Vector3 position)
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, position, Time.deltaTime * 2);
    }

    /*
    private IEnumerator MoveTo(GameObject player, Vector3 position)
    {
        while (player.transform.position != position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, position, Time.deltaTime * 2);
            yield return null;
        }
    }
    */
}
