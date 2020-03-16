using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : BaseAI
{
    public GameObject[] others;
    public CopyPasteAI otherAI;
    public float[] otherHealth;

    [Range(0, 180)]
    public float FOV = 14.6f;

    [Range(0, 20)]
    public float visionRange = 10f;

    void Start()
    {
        //Find others
        others = GameObject.FindGameObjectsWithTag("Target");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calculates angle from self to each target, and normalizes it. (making it between -1 and 1 max)
        Vector3 a = this.transform.forward;
        foreach (GameObject other in others)
        {
            //If it finds itself in the array, skip.
            if (other == this.gameObject) continue;
            

            Vector3 b = other.transform.position - this.transform.position;
            float angle = Vector3.SignedAngle(b, a, Vector3.up);
            //Debug.Log(angle + other.name);

            //Shoots a raycast to the target if it is in range, in it's field of View and if it has the tag "Target".
            //If you want you can seperate this line into different 'if' statements.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, b, out hit, visionRange) && Mathf.Abs(angle) < FOV && hit.transform.tag == "Target")
            {
                //======Put what you want to happen if a target is in it's field of view here=======================

                //GetComponent<BaseAI>().GetStats();

                //==================================================================================================
                //Debug.Log("hit" + other.name);
                Debug.DrawRay(transform.position, b * hit.distance, Color.red, 0.1f);
            }
        }
    }

    //Just a calculation thing for the visual stuff
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}