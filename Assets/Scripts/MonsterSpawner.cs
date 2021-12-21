using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]

    private GameObject[] MonsterReference;

    private GameObject SpawnMonster;

    [SerializeField]

    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());   
    }


    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            randomIndex = Random.Range(0, MonsterReference.Length);
            randomSide = Random.Range(0, 2);
            SpawnMonster = Instantiate(MonsterReference[randomIndex]);

            //Right
            if (randomSide == 0)
            {
                SpawnMonster.transform.position = leftPos.position;
                SpawnMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                SpawnMonster.transform.position = rightPos.position;
                SpawnMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                SpawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
