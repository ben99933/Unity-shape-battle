using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public int id;
    public Level level;
    public int monsterLevel;
    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> objList = new List<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {
        level = Levels.GetLevel(id);
        monsterLevel = level.monsterLevel;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Spawn(GameObject g, int lv, Vector3 position, int amount,float spawnTime)
    {
        StartCoroutine(SpawnUnit(g, lv, position, amount, spawnTime));
    }

    IEnumerator SpawnUnit(GameObject g, int lv, Vector3 position, int amount, float SpawnTime) {
        for (int i = 1;i<= amount; i++) {
            GameObject gb;
            gb = (GameObject)Instantiate(g, position, Quaternion.AngleAxis(0, Vector3.back));
            gb.name = g.name;
            gb.GetComponent<Unit>().level = lv;
            gb.transform.parent = GameObject.Find("Unit").transform;
            gb.name += i;
            enemyList.Add(gb);
            yield return new WaitForSeconds(SpawnTime);
        }
        
    }



}
