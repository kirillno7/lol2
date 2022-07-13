using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyClone;
    [SerializeField] Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        var clone = Instantiate(EnemyClone, position, Quaternion.identity);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
