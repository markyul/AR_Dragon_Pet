using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControll : MonoBehaviour
{
    public Transform[] points;
    public int nextIndex;
    Vector3 targetPosition;
    Vector3 initPosition;
    public Transform red;
    public float speed=0.5f;
    public float rotateSpeed = 0.7f;
    public bool isWalk;
    Animator animator;
    Quaternion rot;
    Quaternion initRot;


    // Start is called before the first frame update
    void Start()
    {
        red = red.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        points = GameObject.Find("TargetPointsGroup").GetComponentsInChildren<Transform>();
        nextIndex = 2;
        initPosition = transform.position;
        initRot = transform.rotation;
        Debug.Log(initRot);
    }

    // Update is called once per frame
    void Update()
    {
        isWalk = animator.GetBool("isWalk");
        if(isWalk){
            if(speed > 2 && nextIndex != 1){
                nextIndex = (nextIndex++ > points.Length) ? 1: nextIndex;
                targetPosition = points[nextIndex].position;
                speed = 0.5f;
                rotateSpeed = 0.7f;
                
            }
            else if(nextIndex == 1 && transform.position == initPosition && transform.rotation == initRot){
                nextIndex = 2;
                animator.SetBool("isWalk", !isWalk);
                isWalk = animator.GetBool("isWalk");
                Debug.Log(transform.position);
            }

            if(nextIndex == 1){
                    Debug.Log(initRot);
                    Debug.Log(transform.eulerAngles);
                    speed += speed * 0.03f;
                    rotateSpeed += rotateSpeed * 0.01f;
                    transform.position = Vector3.Lerp(transform.position, initPosition, Time.deltaTime*speed);
                    rot = Quaternion.LookRotation(initPosition - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotateSpeed);
            }
            else{
                speed += speed * 0.03f;
                rotateSpeed += rotateSpeed * 0.01f;
                Debug.Log(transform.position);

                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*speed);
                rot = Quaternion.LookRotation(targetPosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotateSpeed);
            }
        }

    }
}
