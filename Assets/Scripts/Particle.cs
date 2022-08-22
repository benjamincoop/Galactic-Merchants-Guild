using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private float _time;
    private float _timeToLive;

    public static GameObject CreateParticle(
        string spriteTexture,
        Vector3 position,
        float scale,
        float timeToLive = 1,
        Vector3 force = new Vector3(),
        float torque = 0
    )
    {
        GameObject particle = new GameObject();
        particle.transform.position = position;
        particle.transform.localScale = new Vector3(scale, scale, 1);

        SpriteRenderer sr = particle.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.sprite = Resources.Load<Sprite>(spriteTexture);

        Rigidbody2D rb = particle.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.gravityScale = 0;
        rb.AddForce(force, ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Impulse);

        Particle p = particle.AddComponent<Particle>() as Particle;
        p.TimeToLive = timeToLive;

        return particle;
    }

    public float TimeToLive
    {
        get { return _timeToLive; }
        set { _timeToLive = value; }
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

        _time += Time.deltaTime;
        if (_time > _timeToLive)
        {
            Destroy(this.gameObject);
        }
    }
}
