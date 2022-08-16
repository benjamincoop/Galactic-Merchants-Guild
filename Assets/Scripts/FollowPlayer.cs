using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public Vector3 PlayerOffset;

    // Start is called before the first frame update
    void Start()
    {
        if(Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        if(PlayerOffset == null)
        {
            PlayerOffset = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Player.transform.position.x + PlayerOffset.x,
            Player.transform.position.y + PlayerOffset.y,
            Player.transform.position.z + PlayerOffset.z
        );
    }
}
