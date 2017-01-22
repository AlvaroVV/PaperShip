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

    public SpriteRenderer SpriteLeft;
    public SpriteRenderer SpriteRight;
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
        Vector3 vector = Camera.main.ScreenToWorldPoint(touch.position);
        text_1.text = "Max: "+ SpriteLeft.sprite.bounds.max.x;
        text_3.text = "Extends: " + SpriteLeft.sprite.bounds.extents.y;
        if ((vector.y > PlayerLeft.transform.position.y + SpriteLeft.sprite.bounds.extents.y) || (vector.y < PlayerLeft.transform.position.y - SpriteLeft.sprite.bounds.extents.y))
        {
            MoveLeft(vector);
        }
        else
            ShootLeft();
        

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
        Vector3 vector;
        if ((PlayerLeft.transform.position.y <= boat.transform.position.y + boat.sprite.bounds.extents.y)&&(
            PlayerLeft.transform.position.y >= boat.transform.position.y - boat.sprite.bounds.extents.y))
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

    public void TouchRight(Touch touch)
    {
        Vector3 vector = Camera.main.ScreenToWorldPoint(touch.position);
        text_2.text = vector.ToString();
        if ((vector.y > PlayerRight.transform.position.y + SpriteRight.sprite.bounds.extents.y) || (vector.y < PlayerRight.transform.position.y - SpriteRight.sprite.bounds.extents.y))
        {
            MoveRight(vector);
        }
        else
            ShootRight();
    }

    private void ShootRight()
    {
        Vector3 vector;
        if ((PlayerRight.transform.position.y <= boat.transform.position.y + boat.sprite.bounds.extents.y) && (
            PlayerRight.transform.position.y >= boat.transform.position.y - boat.sprite.bounds.extents.y))
        {
            vector = new Vector3(rightSensor.transform.position.x,
                                   PlayerRight.transform.position.y,
                                   PlayerRight.transform.position.z);
        }
        else
        {
            vector = new Vector3(ResolutionManager.Instance.GetCameraPosition().x,
                                PlayerRight.transform.position.y,
                                PlayerRight.transform.position.z);
        }

        Instantiate(WaterWave, vector, Quaternion.identity);
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
        MoveTo(PlayerRight, positionRight);
    }

    private void MoveTo(GameObject player, Vector3 position)
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, position, Time.deltaTime * speed);
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
