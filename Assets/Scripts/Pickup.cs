using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string Type;
    public string[] Claimants;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        // Destroy projectile if it collides with a valid target
        if (Claimants.Contains(collider.gameObject.tag))
        {
            Destroy(this.gameObject);
        }
    }
}
