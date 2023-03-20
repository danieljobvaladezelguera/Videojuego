using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_plataforma : MonoBehaviour
{
    CharacterController player;
    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundName;

    Quaternion actualRot;
    Quaternion lastRot;

    void Start()
    {
        player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded){
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, player.height / 4.2f, -transform.up, out hit)){
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                actualRot = groundedIn.transform.rotation;

                if (lastGroundPosition != lastGroundPosition && groundName == lastGroundName){
                    this.transform.position += groundPosition - lastGroundPosition;
                }
                if (actualRot != lastRot && groundName == lastGroundName){
                    var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                }
                lastGroundName = groundName;
                lastGroundPosition = groundPosition;

            }

        }else if (true){
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
        }
    }
    private void OnDrawGizmos()
    {
        
        //Gizmos.DrawSphere(transform.position, player.height / 4.2f);
    }
}
