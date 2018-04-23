using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02AI : MonoBehaviour {

    public GameObject target; //the enemy's target
    public float moveSpeed = 3; //move speed
    public float rotationSpeed = 300; //speed of turning

    void Start()
    {
		target = GameObject.FindGameObjectWithTag ("Player");
    }

    void Update()
    {
        if(target != null){
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);
        }
    }
}



