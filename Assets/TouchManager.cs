using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Camera mainCam;
    private RaycastHit2D raycastHit;
    private Grid currentClickedGrid;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
    }

    #region Mouse Input
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (raycastHit.collider != null)
                if (raycastHit.collider.GetComponent<Grid>() != null)
                {
                    currentClickedGrid = raycastHit.collider.GetComponent<Grid>();
                    currentClickedGrid.OnGridSelect();
                }
                else
                {
                    currentClickedGrid = null; 
                }
            else
            {
                currentClickedGrid = null;
            }
        }
        
    }
    #endregion
}
