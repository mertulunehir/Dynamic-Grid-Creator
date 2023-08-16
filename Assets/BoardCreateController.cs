using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BoardCreateController : MonoBehaviour
{
    public static BoardCreateController Instance;
    public Grid gridPrefab;
    public TMP_InputField currentInputField;


    private const float startScale = 10;
    private List<Grid> activeGrids = new List<Grid>();
    private float baseMainY = -5;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        baseMainY = -Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0f, 0f)).x;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CreateBoardButton()
    {
        float currentInput = int.Parse(currentInputField.text);

        if (currentInput >= 2)
        {
            GetComponent<BoardMatchController>().SetInputValue((int)currentInput);
            GetComponent<BoardMatchController>().input = (int)currentInput;
            float currentScale = (Mathf.Abs(baseMainY) * 2) / currentInput;
            float startPosValue = baseMainY + currentScale / 2;
            int currentID = 0;
            for (int y = 0; y < currentInput; y++)
            {
                for (int x = 0; x < currentInput; x++)
                {
                    Vector3 spawnPos = new Vector3(startPosValue + x * currentScale, startPosValue + y * currentScale, 0);
                    GameObject grid = Instantiate(gridPrefab.gameObject, spawnPos, gridPrefab.transform.rotation);
                    grid.GetComponent<Grid>().SetScale(currentScale);
                    grid.GetComponent<Grid>().SetGridPosition(x,y);
                    activeGrids.Add(grid.GetComponent<Grid>());

                    GetComponent<BoardMatchController>().AddGrid(x,y, grid.GetComponent<Grid>());
                    currentID++;
                }

            }

        }


    }

    public void ResetGrids()
    {
        Invoke("ResetWithDelay", 0.4f);  
    }

    public void ResetWithDelay()
    {
        foreach (Grid grid in activeGrids)
        {
            grid.ResetGrid();
        }
    }

}