using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagesprict : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class CubeScript : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (Destroy(EnemyPrefab))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
