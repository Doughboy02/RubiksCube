using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubicCubeManager : MonoBehaviour
{
    public Camera camera;
    public static bool Rotating = false;
    public static bool CubeSolved = false;
    public static GameObject SelectedCube;
    public static bool IsTimerCounting = false;

    public bool MixCube = false;
    public int MixAmount = 10;
    public float Timer = 0;

    public KeyCode TurnLeft = KeyCode.A;
    public KeyCode TurnRight = KeyCode.D;
    public KeyCode TurnUp = KeyCode.W;
    public KeyCode TurnDown = KeyCode.S;

    public Side Top;
    public Side Left;
    public Side Right;
    public Side Front;
    public Side Back;
    public Side Bottom;

    public Text SolvedText;
    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //SelectCube();
        ControlCube();

        if (IsTimerCounting)
        {
            Timer += Time.deltaTime;

            float minutes = Mathf.Floor(Timer / 60);
            float seconds = Mathf.RoundToInt(Timer % 60);

            string minsStr = minutes.ToString();
            string secStr = seconds.ToString();

            if (minutes < 10)
            {
                minsStr = "0" + minutes.ToString();
            }
            if (seconds < 10)
            {
                secStr = "0" + Mathf.RoundToInt(seconds).ToString();
            }

            TimerText.text = minsStr + ":" + secStr;
        }
        
        if (MixCube)
        {
            MixCube = false;
            StartCoroutine(MixRubicCube(MixAmount));
        }
    }

    public void ResetTimer()
    {
        Timer = 0;
    }

    public void ToggleMixCube()
    {
        MixCube = true;
    }

    public IEnumerator MixRubicCube(int rotationAmount)
    {
        int randomNum = 0;
        for (int i=0; i<rotationAmount; i++)
        {
            randomNum = Random.Range(0, 6);

            switch (randomNum)
            {
                case 0:
                    Rotating = true;
                    SimpleRotate(Left);
                    break;

                case 1:
                    Rotating = true;
                    SimpleRotate(Right);
                    break;

                case 2:
                    Rotating = true;
                    SimpleRotate(Top);
                    break;

                case 3:
                    Rotating = true;
                    SimpleRotate(Bottom);
                    break;

                case 4:
                    Rotating = true;
                    SimpleRotate(Front);
                    break;

                case 5:
                    Rotating = true;
                    SimpleRotate(Back);
                    break;
            }

            yield return new WaitUntil(() => !Rotating);
        }       
    }

    private void ControlCube()
    {
        if (!Rotating)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Rotating = true;
                IsTimerCounting = true;
                SimpleRotate(Left);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Rotating = true;
                IsTimerCounting = true;
                SimpleRotate(Right);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Rotating = true;
                IsTimerCounting = true;
                SimpleRotate(Back);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Rotating = true;
                IsTimerCounting = true;
                SimpleRotate(Front);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Rotating = true;
                IsTimerCounting = true;
                SimpleRotate(Top);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Rotating = true;
                IsTimerCounting = true;
                SimpleRotate(Bottom);
            }
        }
    }

    private void SimpleRotate(Side side)
    {
        int direction = 1;
        if (Input.GetKey(KeyCode.LeftShift)) direction = -1;

        side.TurnCubes(direction);
    }

    public void CheckColors()
    {
        Top.CheckColors();
        Bottom.CheckColors();
        Right.CheckColors();
        Left.CheckColors();
        Front.CheckColors();
        Back.CheckColors();
    }

    public void CheckSolved()
    {
        CubeSolved = (Top.SideSolved && Bottom.SideSolved && Right.SideSolved && Left.SideSolved && Front.SideSolved && Back.SideSolved);

        if (CubeSolved)
        {
            SolvedText.text = "Solved!!!";
            IsTimerCounting = false;
        }
        else
        {
            SolvedText.text = "";
        }
    }

    public void SelectCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                if (SelectedCube != null && SelectedCube != hit.transform.gameObject)
                {
                    SelectedCube.GetComponent<RubicCube>().ChangeMaterialBack();
                }

                SelectedCube = hit.transform.gameObject;
                SelectedCube.GetComponent<RubicCube>().SelectCube();
            }
        }
    }
}
