using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    public CheckCubes CheckCubesPanel;
    public RubicCubeManager Manger;
    public bool SideSolved = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnCubes(int direction)
    {
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, GetComponent<BoxCollider>().size / 2,
            transform.forward.normalized, transform.rotation, .1f);

        foreach(RaycastHit hit in hits)
        {
            if (!hit.transform.tag.Contains("Side") && !hit.transform.tag.Contains("Panel"))
                hit.transform.parent = CheckCubesPanel.transform;
        }

        StartCoroutine(Rotate(transform.position, transform.forward, direction));
    }

    public void CheckColors()
    {
        StartCoroutine(CheckCubesPanel.CheckPanelColors());
    }

    private IEnumerator Rotate(Vector3 pivot, Vector3 axis, int direction)
    {
        int num = 10;
        for (int i = 0; i < num; i++)
        {
            transform.RotateAround(pivot, axis, 90 / (float)num * direction);
            yield return new WaitForSeconds(.01f);
        }

        CheckCubesPanel.transform.DetachChildren();
        Manger.CheckColors();
        
        yield return null;
        RubicCubeManager.Rotating = false;
    }
}
