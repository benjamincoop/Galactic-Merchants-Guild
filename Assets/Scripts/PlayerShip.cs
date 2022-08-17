using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : Ship
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    new void Update()
    {
        if (!GameManager.Instance.Paused)
        {
            base.Update();

            Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            if (Input.GetButton("Fire1") && Fuel > 0)
            {
                FireWeapon();
            }
        }
    }
}