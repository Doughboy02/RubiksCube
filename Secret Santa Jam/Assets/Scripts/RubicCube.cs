using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicCube : MonoBehaviour
{
    public GameObject CubeCasing;
    public Material SelectedMaterial;

    private Material DefaultMaterial;

    // Start is called before the first frame update
    void Start()
    {
        DefaultMaterial = CubeCasing.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCube()
    {
        CubeCasing.GetComponent<Renderer>().material = SelectedMaterial;
    }

    public void ChangeMaterialBack()
    {
        CubeCasing.GetComponent<Renderer>().material = DefaultMaterial;
    }
}
