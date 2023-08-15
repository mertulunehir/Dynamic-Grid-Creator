using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BoardCreateController : MonoBehaviour
{
    public Grid gridPrefab;
    public TMP_InputField currentInputField;


    private const float startScale = 10;

    private float baseMainY = -5;



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
            float currentScale = (Mathf.Abs(baseMainY) * 2) / currentInput;
            float startPosValue = baseMainY + currentScale / 2;

            for (int y = 0; y < currentInput; y++)
            {
                for (int x = 0; x < currentInput; x++)
                {
                    Vector3 spawnPos = new Vector3(startPosValue + x * currentScale, startPosValue + y * currentScale, 0);
                    GameObject grid = Instantiate(gridPrefab.gameObject, spawnPos, gridPrefab.transform.rotation);
                    grid.GetComponent<Grid>().SetScale(currentScale);
                }


            }

        }


    }


}