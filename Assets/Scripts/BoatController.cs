using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Mueve el barco al punto _targetY
public class BoatController : MonoBehaviour {

	public float _targetY = 0f;
	public float _speed = 1f;
	bool _isJumping = false;
	public float _jumpScaleIncrement = 0.01f;
	public float _maxSize = 1.4f;
	public float _timeOnAir = 1f;    

	Collider2D _collider;
	SpriteRenderer _spriteRenderer;

    private bool leftSensor;
    private bool rightSensor;

	void Start(){
		_collider = GetComponent<Collider2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}
	}

    /*
	void FixedUpdate () {
		float step = _speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, _targetY), step);
	}
    */

	public void Jump(){
		if(!_isJumping){
			StartCoroutine(JumpCycle());
		}
	}

	IEnumerator JumpCycle(){
		_isJumping = true;

		_collider.enabled = false;

		float initLocalScaleX = transform.localScale.x;
		while(transform.localScale.x < _maxSize){
			transform.localScale += new Vector3(_jumpScaleIncrement, _jumpScaleIncrement, 0);
			yield return null;
		}

		yield return new WaitForSeconds(_timeOnAir);

		while(transform.localScale.x > initLocalScaleX){
			transform.localScale -= new Vector3(_jumpScaleIncrement, _jumpScaleIncrement, 0);
			yield return null;
		}

		_collider.enabled = true;
		_isJumping = false;

	}

    public void SetActiveLeftSensor(bool active)
    {
        Debug.Log("IZQ");
        leftSensor = active;
    }

    public void SetActiveRightSensor(bool active)
    {
        Debug.Log("DER");
        rightSensor = active;
    }

    public bool ReadyToJump()
    {
       
        return (rightSensor && leftSensor);
    }

}
