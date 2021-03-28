using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum FaceDirection {up, down, left, right};
    public enum Status { close, open };
    public FaceDirection faceDirection;
    public Status status;
    public GameObject left, right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetDoor();
    }
    void SetDoor() {
        Vector3 p = gameObject.transform.position;
        if (status == Status.close) {
            switch (faceDirection)
            {
                case FaceDirection.up:
                    left.transform.position = new Vector3(1, 0, 0) + p;
                    right.transform.position = new Vector3(-1, 0, 0) + p;
                    left.transform.rotation = Quaternion.Euler(0, 0, 180);
                    right.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case FaceDirection.down:
                    left.transform.position = new Vector3(-1, 0, 0) + p;
                    right.transform.position = new Vector3(1, 0, 0) + p;
                    left.transform.rotation = Quaternion.Euler(0, 0, 0);
                    right.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case FaceDirection.left:
                    left.transform.position = new Vector3(0, 1, 0) + p;
                    right.transform.position = new Vector3(0, -1, 0) + p;
                    left.transform.rotation = Quaternion.Euler(0, 0, -90);
                    right.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                case FaceDirection.right:
                    left.transform.position = new Vector3(0, -1, 0) + p;
                    right.transform.position = new Vector3(0, 1, 0) + p;
                    left.transform.rotation = Quaternion.Euler(0, 0, 90);
                    right.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
            }
        } else if (status == Status.open) {
            switch (faceDirection)
            {
                case FaceDirection.up:
                    left.transform.position = p + new Vector3(0.85F, 0.15F, 0);
                    right.transform.position = p + new Vector3(-0.85F, 0.15F, 0);
                    left.transform.rotation = Quaternion.Euler(0, 0, -90);
                    right.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case FaceDirection.down:
                    left.transform.position = p + new Vector3(-0.85F, -0.15F, 0);
                    right.transform.position = p + new Vector3(0.85F, -0.15F, 0);
                    left.transform.rotation = Quaternion.Euler(0, 0, 90);
                    right.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                case FaceDirection.left:
                    left.transform.position = p + new Vector3(-0.15F, 0.85F, 0);
                    right.transform.position = p + new Vector3(-0.15F, -0.85F, 0);
                    left.transform.rotation = Quaternion.Euler(0, 0, 0);
                    right.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case FaceDirection.right:
                    left.transform.position = p + new Vector3(0.15F, -0.85F, 0);
                    right.transform.position = p + new Vector3(0.15F, 0.85F, 0);
                    left.transform.rotation = Quaternion.Euler(0, 0, 180);
                    right.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
            }
        }
        
    }
}
