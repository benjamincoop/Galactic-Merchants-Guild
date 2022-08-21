using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _damage;
    private float _moveSpeed;
    private float _timeToLive;
    private bool _isClone = false;

    private float _time;

    // These setters should be invoked by the Weapon class when a new projectile is created
    public void SetDamage(float damage) { _damage = damage; }
    public void SetMoveSpeed(float speed) { _moveSpeed = speed; }
    public void SetTimeToLive(float ttl) { _timeToLive = ttl; }
    public void SetIsClone(bool clone) { _isClone = clone; }

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
                GetComponent<SpriteRenderer>().sprite = null;
                Destroy(this);
            }

            Move();
        }
    }

    void Move()
    {
        float translation = _moveSpeed * Time.deltaTime;
        transform.Translate(0, translation, 0);
    }
}
