using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public float ProjectileMovementSpeed;
    public float ProjectileTimeToLive;
    public bool IsClone;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Paused)
        {
            return;
        }

        if (IsClone)
        {
            _time += Time.deltaTime;
            if (_time > ProjectileTimeToLive)
            {
                GetComponent<SpriteRenderer>().sprite = null;
                Destroy(this);
            }

            HandleMovement();
        }
    }

    void HandleMovement()
    {
        float translation = ProjectileMovementSpeed * Time.deltaTime;
        transform.Translate(0, translation, 0);
    }
}
