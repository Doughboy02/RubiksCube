using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCubes : MonoBehaviour
{
    public Side SideParent;
    public RubicCubeManager RubicCubeManager;
    public List<Material> PanelColors = new List<Material>(9);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClearPanelColorList()
    {
        PanelColors.Clear();
    }

    public IEnumerator CheckPanelColors()
    {
        ClearPanelColorList();
        GetComponent<BoxCollider>().enabled = true;

        yield return new WaitUntil(() => PanelColors.Count == 9);

        bool solved = true;

        foreach (Material mat in PanelColors)
        {
            if (mat.name != PanelColors[0].name) solved = false;
        }

        SideParent.SideSolved = solved;
        RubicCubeManager.CheckSolved();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PanelColors.Count == 9)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.tag == "Panel")
        {
            PanelColors.Add(other.GetComponent<Renderer>().material);
        }
    }
}
