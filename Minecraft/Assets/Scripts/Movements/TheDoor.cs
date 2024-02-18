using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoor : MonoBehaviour
{
    public GameObject Pivot, Porte;
    public int Angle = 120;
    private int CurAngle;
    public bool ouverture = false;
    void Update()
    {
        if(ouverture)
        {
            if(CurAngle < Angle)
            {   
                CurAngle += 1; 
                Porte.transform.RotateAround(Pivot.transform.position, Vector3.up, CurAngle*Time.deltaTime);
            }
        }
        else
        {
            if(CurAngle != 0)
            {   
                CurAngle -= 1; 
                Porte.transform.RotateAround(Pivot.transform.position, -Vector3.up, CurAngle*Time.deltaTime);
            }
        }

        if(CurAngle == 0)
        {
            Porte.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void OnTriggerEnter()
    {
       ouverture = true;
    }

    void OnTriggerExit()
    {
        ouverture = false;
    }
}
