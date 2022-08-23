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
    private bool _isHoming = false;
    private float _trackingDistance;
    private bool _isClone = false;

    private float _time;
    private List<GameObject> _homingTargets;

    // These properties should be set by the Weapon class when a new projectile is created and can be read by the target of a collision
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
    public bool IsHoming
    {
        get { return _isHoming; }
        set { _isHoming = value; }
    }
    public float TrackingDistance
    {
        get { return _trackingDistance; }
        set { _trackingDistance = value; }
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

        // create list of homing targets
        if (_isHoming && _homingTargets == null)
        {
            _homingTargets = new List<GameObject>();

            foreach (string tag in Targets)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
                {
                    _homingTargets.Add(obj);
                }
            }
        }

        // destroy when time to live expires
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

        // homing projectile logic
        if (_isHoming && _homingTargets.Count > 0)
        {
            // find the nearest homing target
            GameObject closest = null;
            float smallestDistance = _trackingDistance;

            foreach(GameObject target in _homingTargets)
            {
                if(target != null)
                {
                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;
                        closest = target;
                    }
                }
            }

            // track the target
            if(closest)
            {
                // update rotation
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, closest.transform.position - transform.position);
                transform.rotation = rotation;
                // update position
                transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, translation);
            } else
            {
                _isHoming = false;
                _homingTargets = null;
            }

            return;
        }

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
