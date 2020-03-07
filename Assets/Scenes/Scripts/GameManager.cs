using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameObject Monster;

    public static Vector3 playerCord;
    public static bool playerIsRunning = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerCord = Player.transform.position;
        if (playerCord == Monster.transform.position) {
            Debug.Log("Hit");
        }
    }
}
