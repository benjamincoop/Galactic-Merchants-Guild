using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingBody : MonoBehaviour
{
    /// <summary>
    /// The object around which this object orbits
    /// </summary>
    public GameObject OrbitalParent;
    /// <summary>
    /// The distance at which this object orbits
    /// </summary>
    public Vector3 OrbitalRadius;
    /// <summary>
    /// The speed at which this object orbits
    /// </summary>
    public float OrbitalSpeed;

    private float _time = 0f;

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

        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 orbitalVector = Vector3.zero;

        _time += OrbitalSpeed * Time.deltaTime;
        transform.position = Vector3.Scale(new Vector3(Mathf.Cos(_time), Mathf.Sin(_time), 1), OrbitalRadius);

        if (OrbitalParent)
        {
            transform.position += new Vector3(OrbitalParent.transform.position.x, OrbitalParent.transform.position.y, 0);
        }
    }
}
