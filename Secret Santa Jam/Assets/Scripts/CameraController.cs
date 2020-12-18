using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public RubicCubeManager RubicCubeManager;
    public Transform Camera;
    public int RotateSpeed = 40;
    public bool IsUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!RubicCubeManager.Rotating)
        {
            if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.LeftControl))
            {
                RubicCubeManager.Rotating = true;
                StartCoroutine(RotateUpDown());
            }
            else if (Input.GetMouseButtonDown(1))
            {
                RubicCubeManager.Angled = !RubicCubeManager.Angled;
                int direction = 1;

                if (Input.GetKey(KeyCode.LeftShift)) direction = -1;

                RubicCubeManager.Rotating = true;
                StartCoroutine(RotateToSide(direction, 45));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RubicCubeManager.Rotating = true;
                StartCoroutine(RotateToSide(1, 180));
            }
        }
    }

    public IEnumerator RotateToSide(int direction, int rotateAmount)
    {
        int num = RotateSpeed;
        for (int i = 0; i < num; i++)
        {
            transform.RotateAround(transform.position, transform.up, rotateAmount / (float)num * direction);
            yield return new WaitForSeconds(.01f);
        }

        RubicCubeManager.Rotating = false;

        yield return null;
    }

    public IEnumerator RotateUpDown()
    {
        IsUp = !IsUp;
        int direction = IsUp ? 1 : -1; 

        int num = RotateSpeed;
        for (int i = 0; i < num; i++)
        {
            Camera.transform.RotateAround(transform.position, Camera.right, 90 / (float)num * direction);
            yield return new WaitForSeconds(.01f);
        }

        RubicCubeManager.Rotating = false;

        yield return null;
    }
}
