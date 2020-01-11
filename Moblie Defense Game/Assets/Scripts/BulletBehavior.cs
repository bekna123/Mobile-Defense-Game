using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public BulletStat bs { get; set; }

    public float activeTime = 3.0f;

    public GameObject character;
    
    public BulletBehavior()
    {
        bs = new BulletStat(0, 0);
    }

    public void spawn()
    {
        gameObject.SetActive(true);
    }

    private IEnumerator BulletInactive(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        StartCoroutine(BulletInactive(activeTime));
    }

    

    void Start () {

	}
	
	void Update () {
        transform.Translate(Vector2.right * bs.speed * Time.deltaTime);
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
