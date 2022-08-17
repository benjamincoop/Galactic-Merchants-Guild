using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // The instance of the GameManager class. Accessible to all objects.

    private bool _mapMode = false; // hi/low camera zoom level

    public bool Paused = false;

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
        if (Input.GetKeyDown("m"))
        {
            if (_mapMode)
            {
                GetComponent<Camera>().orthographicSize = 10;
                _mapMode = false;
            }
            else
            {
                GetComponent<Camera>().orthographicSize = 60;
                _mapMode = true;
            }
        }
    }
}
