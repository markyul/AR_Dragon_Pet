using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatChicken : MonoBehaviour
{
    public string _targetName = "Player";
    Transform _target;
    private float dampSpeed = 0.4f;  // 따라가는 속도

    public GameObject chicken;
    Animator animator_chicken;
    GameObject gameobj_chicken;
    Transform transform_chicken;
    public bool isFeed;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        isFeed = animator.GetBool("isFeed");
        if (isFeed)
        {
            FindChicken();
            FollowTarget();
            EatTarget();
        }
        else
        {
            Debug.Log("!!!FollowTarget");
        }
    }

    public void FindChicken()
    {
        Debug.Log("FindChicken");
        chicken = GameObject.FindGameObjectWithTag("Player");
        //set chicken tag
        chicken.gameObject.tag = "Player";

        //set chicken things
        gameobj_chicken = GameObject.FindGameObjectWithTag("Player");
        animator_chicken = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        transform_chicken = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FollowTarget()
    {
        Debug.Log("FollowTarget");
        animator.SetBool("followTarget", true);
        //TargetFind();
        transform.position = Vector3.Lerp(transform.position, transform_chicken.position, Time.deltaTime * dampSpeed);

        // 방향을 봄
        transform.LookAt(transform_chicken);
    }

    void EatTarget()
    {
        Debug.Log("EatTarget");
        var heading = transform_chicken.position - this.transform.position;

        //Debug.Log(heading.sqrMagnitude + "");

        if (heading.sqrMagnitude < 1f)
        {
            Debug.Log("Set_false");
            //Debug.Log(heading.sqrMagnitude + "");

            animator.SetBool("followTarget", false);//걷기 멈춰
            animator.SetBool("byteChicken", true);//물엇

            animator_chicken.SetBool("Live", false);
            animator.SetBool("isFeed", !isFeed);

            animator.SetBool("byteChicken", false);

            //포만감 업데이트
            int fullness = animator.GetInteger("fullness");
            animator.SetInteger("fullness", (int)fullness + 10);
        }
    }
}
