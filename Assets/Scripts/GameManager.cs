using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // The instance of the GameManager class. Accessible to all objects.

    public bool Paused = false;
    public float Fuel = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (Paused)
            {
                Paused = false;
            }
            else
            {
                Paused = true;
            }
        }
    }
}
