using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class BoardCreateController : MonoBehaviour
{

    public Grid gridPrefab;
    public TMP_InputField currentInputField;


    private const float startScale = 10;
    private List<Grid> activeGrids = new List<Grid>();
    private float baseMainY = -5;

    [Inject] private DiContainer diContainer;

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
            if(activeGrids.Count>0)
            {
                foreach(Grid grid in activeGrids)
                {
                    Destroy(grid.gameObject);
                }
                activeGrids.Clear();
            }

            GetComponent<BoardMatchController>().SetInputValue((int)currentInput);
            float currentScale = (Mathf.Abs(baseMainY) * 2) / currentInput;
            float startPosValue = baseMainY + currentScale / 2;
            for (int y = 0; y < currentInput; y++)
            {
                for (int x = 0; x < currentInput; x++)
                {
                    Vector3 spawnPos = new Vector3(startPosValue + x * currentScale, startPosValue + y * currentScale, 0);

                    Grid grid = diContainer.InstantiatePrefabForComponent<Grid>(gridPrefab);

                    grid.transform.position = spawnPos;
                    grid.GetComponent<Grid>().SetScale(currentScale);
                    grid.GetComponent<Grid>().SetGridPosition(x,y);
                    activeGrids.Add(grid.GetComponent<Grid>());

                    GetComponent<BoardMatchController>().AddGrid(x,y, grid.GetComponent<Grid>());
                }

            }

        }
        else
        {

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