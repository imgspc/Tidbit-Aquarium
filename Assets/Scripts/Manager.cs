using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{

    [SerializeField]
    GameObject tidbitPrefab;

    [SerializeField]
    Transform spawnPos;

    [SerializeField]
    TextAsset names;

    [SerializeField]
    string[] nameArray;

    void Start()
    {
        PrepRandomNameList();

        InstanceRandomTidbit();
        InstanceRandomTidbit();
        InstanceRandomTidbit();
    }

    void PrepRandomNameList()
    {
        nameArray = names.ToString().Split("\n"[0]);
    }

    void InstanceRandomTidbit()
    {
        GameObject host = Instantiate(tidbitPrefab, spawnPos.position + new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-1.5f, 1.5f), 0f), spawnPos.rotation);

        host.GetComponent<TidbitInstance>().Initialize(nameArray[Random.Range(0, nameArray.Length)], 0f, 1f, 1f, Random.Range(0f, 1f), Random.Range(1, 7));

    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            Application.Quit();
        }

    }
}
