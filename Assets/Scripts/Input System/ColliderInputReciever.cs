using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInputReciever : InputReciever
{
    //private DebugInputHandler Debugger;
    private Vector3 clickPosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;
                OnInputRecieved();
            }
        }
    }

    public override void OnInputRecieved()
    {
        foreach (var handler in inputHandlers)
        {
            //Debugger.ProcessInput(clickPosition, null, null);
            handler.ProcessInput(clickPosition, null, null);
        }
    }
}