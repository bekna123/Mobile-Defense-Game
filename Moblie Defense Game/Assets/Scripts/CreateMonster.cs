using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour {

    public List<GameObject> respawnSpotList= new List<GameObject>();

    public GameObject monster1Prefab;
    public GameObject monster2Prefab;

    private GameObject monsterPrefab;

    private IEnumerator coroutine;

    private int spawnCount = 0;

    void Start () {
        monsterPrefab = monster1Prefab;
        coroutine = process();
        StartCoroutine(process());
	}

    IEnumerator process()
    {
        while (true)
        {
            if (GameManager.instance.round > GameManager.instance.totalRound) StopCoroutine(coroutine);
            if (spawnCount < GameManager.instance.spawnNumber) { Create(); }
            if(spawnCount == GameManager.instance.spawnNumber &&
               GameObject.FindGameObjectWithTag("Monster") == null)
            {
                if (GameManager.instance.totalRound == GameManager.instance.round)
                {
                    GameManager.instance.gameClear();
                    GameManager.instance.round += 1;
                }
                else
                {
                    GameManager.instance.clearRound();
                    spawnCount = 0;

                    if (GameManager.instance.round == 4)
                    {
                        monsterPrefab = monster2Prefab;
                        GameManager.instance.spawnTime = 2.0f;
                        GameManager.instance.spawnNumber = 10;
                    }
                }
            }
            if (spawnCount == 0) yield return new WaitForSeconds(GameManager.instance.roundReadyTime);
            else yield return new WaitForSeconds(GameManager.instance.spawnTime);

        }
    }
	
	void Create()
    {
        int index = Random.Range(0, 4);
        GameObject respawnSpot = respawnSpotList[index];
        Instantiate(monsterPrefab, respawnSpot.transform.position, Quaternion.identity);
        spawnCount += 1;
    }
}
