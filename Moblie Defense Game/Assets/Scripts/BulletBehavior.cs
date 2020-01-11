using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public BulletStat bs { get; set; }

    public float activeTime = 3.0f;
    private float spawnTime;

    public GameObject character;
    
    public BulletBehavior()
    {
        bs = new BulletStat(0, 0);
    }

    public void spawn()
    {
        gameObject.SetActive(true);
        spawnTime = Time.time;
    }

	void Start () {

	}
	
	void Update () {
        if(Time.time - spawnTime < activeTime)
        {
            transform.Translate(Vector2.right * bs.speed * Time.deltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            gameObject.SetActive(false);
            other.GetComponent<MonsterStat>().attacked(bs.damage);
        }   
    }
}
