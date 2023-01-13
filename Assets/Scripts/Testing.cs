using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Unit unit;
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T)) 
        {
            unit.GetMoveAction().GetValidActionPositionList();
        }
    }
}
