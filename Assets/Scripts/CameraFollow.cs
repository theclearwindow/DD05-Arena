using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    public List<GameObject> others = new List<GameObject>();
    public int selection;
    private int timer = 0;

    public int cameraSwitchTime = 500;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Target"))
        {
            others.Add(go);
        }
        selection = 0;
    }

    private void Update()
    {
        timer += 1;

        //Automatically
        if (timer > cameraSwitchTime)
        {
            //Debug.Log("Selection " + selection);
            //Debug.Log("others.Count " +others.Count);
            if (selection + 1 == others.Count)
            {
                selection = 0;
            }
            if (selection < others.Count - 1 && others[selection] != null)
            {
                 selection++;
                 offset = new Vector3(Random.Range(-15, 15), Random.Range(8, 20), Random.Range(-15, 15));
            }
            timer = 0;
        }

        //if a player dies while the camera is on it.
        if (others[selection] == null)
        {
            others.RemoveAt(selection);
            if (selection == others.Count)
            {
                selection--;
                offset = new Vector3(Random.Range(-15, 15), Random.Range(8, 20), Random.Range(-15, 15));
            }
            timer = 0;
        }

        //For player control.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selection < others.Count - 1)
            {
                if (others[selection] != null)
                {
                    selection++;
                    offset = new Vector3(Random.Range(-15, 15), Random.Range(8, 20), Random.Range(-15, 15));
                }
            }
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selection > 0)
            {
                if (others[selection] != null)
                {
                    selection--;
                    offset = new Vector3(Random.Range(-15, 15), Random.Range(8, 20), Random.Range(-15, 15));
                }
            }
            timer = 0;
        }
        target = others[selection];

        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target.transform);
    }
    // Update is called once per frame
    void LateUpdate()
    {
    //    Vector3 desiredPosition = target.transform.position + offset;
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    //    transform.position = smoothedPosition;

    //    transform.LookAt(target.transform);
    }
}
