using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    public float MoveSpeed;
    public float TimeToLive;
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
            if (_time > TimeToLive)
            {
                GetComponent<SpriteRenderer>().sprite = null;
                Destroy(this);
            }

            Move();
        }
    }

    void Move()
    {
        float translation = MoveSpeed * Time.deltaTime;
        transform.Translate(0, translation, 0);
    }
}
