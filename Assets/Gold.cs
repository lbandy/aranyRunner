using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {
    public float fallSpeed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.y > 0)
        {
            rigidbody.MovePosition(transform.position + (Vector3.down * Time.fixedDeltaTime));
            Debug.Log(transform.position.y);
        }
	
	}
}
