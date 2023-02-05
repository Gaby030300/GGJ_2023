using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform pickupPoint;
    private Transform player;

    [SerializeField] private float pickupDistance;
    [SerializeField] private float minDistance;

    public bool isReadyToThrow;
    public bool isPicked;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        pickupPoint = GameObject.Find("Pickup Point").transform;

    }
    private void Update()
    {
        PickObject();
    }

    void PickObject()
    { 
        
        pickupDistance = Vector3.Distance(player.position, transform.position);

        if(pickupDistance <= minDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) && isPicked == false && pickupPoint.childCount < 1)
            {
                GetComponent<Rigidbody>().useGravity = false;

                rb.constraints = RigidbodyConstraints.FreezeAll;

                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = pickupPoint.position;
                transform.rotation = Quaternion.identity;
                this.transform.parent = GameObject.Find("Pickup Point").transform;

                isPicked = true;
            }

            else if (Input.GetKeyDown(KeyCode.E) && isPicked == true)
            {
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;

                rb.constraints = RigidbodyConstraints.None;

                isPicked = false;
                isReadyToThrow = false;
            }

        }

    }


}
