using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    bool target = false;

    [SerializeField]
    int monsterSpeed = 1;

    float digTime = -1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the monster is chasing else he is digging.
        if (target == false)
        {
            Debug.Log("Chasing");
            MoveTowardsPlayer();
        }
        else {
            //Sets the digging time for the monster checking to see if the monster is already digging(-1)
            if (digTime == -1)
            {
                digTime = 5f;
            }
            Dig();
        }
        

    }

    private void Dig() {
        //Waits 5 full seconds before returning to chasing the player
        if (digTime > 0f)
        {
            Debug.Log("Digging: " + digTime);
            digTime = digTime - Time.deltaTime;
        }
        else {
            //Only called when the 5 seconds are over
            digTime = -1f;
            target = false;
        }
    }

    //Checks the position of the player and if in different area the monster will move to thier last known position
    private void MoveTowardsPlayer() {
        
        //Gets the player coords and sets the y so the monster wont change elevation
        Vector3 targetPos = GameManager.playerCord;
        targetPos.y = transform.position.y;

        if (GameManager.playerIsRunning == true) {
            monsterSpeed = monsterSpeed * 2;
        }

        //Moves the monster and if the position is reaches stops chasing
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * monsterSpeed);

        if (transform.position.x == GameManager.playerCord.x && transform.position.z == GameManager.playerCord.z) {
            target = true;
        }
        
    }
}
