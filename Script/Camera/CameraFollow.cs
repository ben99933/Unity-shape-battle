using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    Vector3 offset;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Player");
    }
    void Start()
    {
        target = GameObject.Find("Player");
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Camera.main.orthographicSize = 6.5F;
        transform.position = target.transform.position + offset;
    }
    public void ChangeTarget(GameObject t) {
        target = t;
    }
    public void ChangeTarget(string objectName)
    {
        target = GameObject.Find(objectName);
    }
}
