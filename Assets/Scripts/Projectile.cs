using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _damage;
    private float _moveSpeed;
    private float _timeToLive;
    private string[] _targets;
    private bool _isClone = false;

    private float _time;

    // These properties should be set by the Weapon class when a new projectile is created and read by the target of a collision
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }
    public float TimeToLive
    {
        get { return _timeToLive; }
        set { _timeToLive = value; }
    }
    public string[] Targets
    {
        get { return _targets; }
        set { _targets = value; }
    }
    public bool IsClone
    {
        get { return _isClone; }
        set { _isClone = value; }
    }


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

        if (_isClone)
        {
            _time += Time.deltaTime;
            if (_time > _timeToLive)
            {
                Destroy(this.gameObject);
            }

            Move();
        }
    }

    void Move()
    {
        float translation = _moveSpeed * Time.deltaTime;
        transform.Translate(0, translation, 0);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        // Destroy projectile if it collides with a valid target
        if(_targets.Contains(collider.gameObject.tag))
        {
            Destroy(this.gameObject);
        }
    }
}
