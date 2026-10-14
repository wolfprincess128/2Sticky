using UnityEngine;

public class PlayerController : MonoBehaviour
{
   float xInput;
   float zInput;
   public float baseSpeed;

   Transform playerMove;
   Vector3 playerPos;
    void Start()
    {
        playerMove = this.gameObject.GetComponent<Transform>();
        //setting the players tranform to the objects transform

    }

    void Update()
    {
        xInput = Input.GetAxis("Vertical");
        zInput = Input.GetAxis("Horizontal");
        //these map controls based on keys associated with hor and ver movement
        //for example left key would make the zInput Equal -1 and the right 1 (with easing)

        if (xInput != 0)
        {
            playerPos.x += xInput;
            // If the player has held a dir key it will translate the player by that amount per frame
        }
        if (zInput != 0)
        {
            playerPos.z -= zInput;
        }

        playerMove.Translate(playerPos * baseSpeed * Time.deltaTime);
        //This does the actual translation on the literal object of the player's transform
        //delta time scales movement between frames which keeps the movement speed constant
        // you can use playerPos.Normalized to make the speed consisetent but i like it unnormalized
        playerPos = Vector3.zero;
        //this resets the position so it doesnt accumulate values from previous frames exponentially
    }
}
