using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagesprict : MonoBehaviour
{
    [SerializeField] GameObject CountPrefab = default;

    private GameObject Wall01;
    // Start is called before the first frame update
    void Start()
    {
        Wall01 = GameObject.Find(CountPrefab.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            Wall01.SetActive(false);
        }
        
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (EnemyPrefab != null) { Destroy(gameObject); }
    //}
}
