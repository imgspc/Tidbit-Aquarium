using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidbitInstance : MonoBehaviour
{
    Rigidbody rb;
    Material[] legMaterialArray = new Material[2];
    MeshRenderer bodyRenderer;

    [SerializeField]
    GameObject[] bodyTypes;

    [SerializeField]
    SkinnedMeshRenderer[] skinnedMeshRenderers;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Initialize(string name, float age, float health, float happiness, float hue, int type)
    {
        gameObject.name = name;

        Color bodyColor = Color.HSVToRGB(hue, happiness, 1f - age);
        Color legColor = Color.HSVToRGB(hue, happiness, Mathf.Clamp(1f - (age + 0.2f), 0f, 1f));

        bodyTypes[type - 1].SetActive(true);

        bodyRenderer = bodyTypes[type - 1].GetComponent<MeshRenderer>();
        bodyRenderer.material.color = bodyColor;

        legMaterialArray = skinnedMeshRenderers[0].materials;

        legMaterialArray[0].color = bodyColor;
        legMaterialArray[1].color = legColor;

        skinnedMeshRenderers[0].materials = legMaterialArray;
        skinnedMeshRenderers[1].materials = legMaterialArray;

        InvokeRepeating("Move", Random.Range(0f, 1f), health * happiness * 2f);
    }


    void Move()
    {
        rb.AddRelativeForce(new Vector3(0f, Random.Range(-2f, 2f), 0f), ForceMode.Impulse);
        rb.AddTorque(new Vector3(0f, 0f, Random.Range(-0.1f, 0.1f)), ForceMode.Impulse);
    }
}
