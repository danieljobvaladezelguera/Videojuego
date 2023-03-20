using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    public Vector3 offset;
    private Transform target;
    public float sensible = 5f;

    public float lerpValue = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("User").transform;
    }

    void LateUpdate(){
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensible, Vector3.up) * offset;
        transform.LookAt(target);
    }
}
