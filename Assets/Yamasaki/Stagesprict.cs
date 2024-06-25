using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagesprict : MonoBehaviour
{
    [SerializeField] GameObject CountPrefab = default;
    [SerializeField] GameObject WallPrefab = default;

    private GameObject Wall01;
    private GameObject Walla1;
    // Start is called before the first frame update
    void Start()
    {
        Wall01 = GameObject.Find(CountPrefab.name);
        Walla1 = GameObject.Find(WallPrefab.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Walla1 == false)
        {
            Wall01.SetActive(false);
        }
        
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (EnemyPrefab != null) { Destroy(gameObject); }
    //}
}
