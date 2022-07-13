using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] List<Transform> Positions;

    void Start()
    {
        foreach (var pos in Positions)
        {
            Instantiate(Prefab, pos.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
