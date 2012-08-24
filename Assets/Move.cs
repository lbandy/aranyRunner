using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    CharacterController controller;
    public float runSpeed = 4.0f;
    public float jumpHeight = 10f;

	void Start () {
        controller = GetComponent<CharacterController>();
	    
	}


    bool jump = false;
    bool up = true;

    float startX;
    float startY;
    float jumpVelocity = 10.0f;

	void Update () {
        if (!jump && Input.GetButtonDown("Jump"))
        {
            jump = true;
            up = true;
            startX = transform.position.x;
            startY = transform.position.y;
            jumpVelocity = jumpHeight;
        }
	
	}

    float moveVelocity;

    void FixedUpdate()
    {
        if (collided)
        {
            if (moveLeft)
            {
                controller.Move(Vector3.left * runSpeed * Time.fixedDeltaTime * 0.5f);
                moveVelocity = controller.velocity.x;
            }
            else
            {
                controller.Move(Vector3.right * runSpeed * Time.fixedDeltaTime * 0.5f);
                moveVelocity = controller.velocity.x;
            }
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    controller.Move(Vector3.left * runSpeed * Time.fixedDeltaTime);
                    moveVelocity = controller.velocity.x;
                }

                else
                {
                    controller.Move(Vector3.right * runSpeed * Time.fixedDeltaTime);
                    moveVelocity = controller.velocity.x;
                }
        }
        else if (jump)
        {
            controller.Move(new Vector3(moveVelocity,0,0) * Time.fixedDeltaTime);
        }
        
    

        if (jump)
        {
            if (up)
            {
                if (jumpVelocity > 0)
                {
                    controller.Move(Vector3.up * Time.fixedDeltaTime * jumpVelocity);
                    jumpVelocity -= 0.1f;
                }

                else
                {
                    up = false;
                    jumpVelocity = 0;
                }
            }
            else
            {
                if (jumpVelocity < jumpHeight)
                {
                    controller.Move(Vector3.down * Time.fixedDeltaTime * jumpVelocity);
                    jumpVelocity += 0.1f;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x,startY,transform.position.z);
                    jump = false;
                }
            }

        }
    }

    bool collided = false;
    bool moveLeft = false;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.name == "ColliderLeft")
        {
            collided = true;
            moveLeft = false;
            Invoke("ResetCollided", 1);
        }

        else if (hit.transform.name == "ColliderRight")
        {
            collided = true;
            moveLeft = true;
            Invoke("ResetCollided", 1);
        }

    }

    void ResetCollided()
    {
        collided = false;
    }
}
