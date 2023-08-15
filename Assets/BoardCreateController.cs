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
    private const int baseMainY = -5;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CreateBoardButton()
    {

        Debug.Log(currentInputField.text);
        float currentScreenWidth = Screen.width;
        float currentScreenHeight = Screen.height;
        float widthHeightRatio = currentScreenWidth / currentScreenHeight;

        Debug.Log(widthHeightRatio);


        float currentInput = int.Parse(currentInputField.text);
        if (currentInput >= 2)
        {
            float currentScale = (startScale*2*widthHeightRatio) / currentInput;

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