using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class UpdateStatus : MonoBehaviour
{
    public bool isSleep;
    public bool isFeed;
    public bool isPraise;
    public bool isWalk;
    float time = 0;
    Animator animator;
    Stopwatch sw = new Stopwatch();

    public void SetActiveCondition(string conditionName, bool activeCondition)
    {
        activeCondition = animator.GetBool(conditionName);
        activeCondition = !activeCondition;
        animator.SetBool(conditionName, activeCondition);
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isSleep = animator.GetBool("isSleep");
        isFeed = animator.GetBool("isFeed");
        isPraise = animator.GetBool("isPraise");
        isWalk = animator.GetBool("isWalk");

        float tired = animator.GetInteger("tired");
        float fullness = animator.GetInteger("fullness");
        float happy = animator.GetInteger("happy");

        // 잠잘때 피로도가 1씩 감소
        if (isSleep)
        {
            sw.Start(); // 초를 재기 시작
            if ((sw.ElapsedMilliseconds * 0.001) > 1)
            {
                if(tired > 0)
                    animator.SetInteger("tired", (int)tired - 1);
                sw.Reset();
                
            }
        }
        
        // 먹을때 포만도와 기분이 1씩 증가
        if (isFeed)
        {
            animator.SetInteger("fullness", (int)fullness + 10);
        }

        // 산책할때 피로도와 기분이 1씩 증가, 포만도가 1씩 감소
        if (isWalk)
        {
            sw.Start(); // 초를 재기 시작
            if ((sw.ElapsedMilliseconds * 0.001) > 1)
            {
                if(tired < 100)
                    animator.SetInteger("tired", (int)tired + 1);
                if(happy < 100)
                    animator.SetInteger("happy", (int)happy + 1);
                if(fullness > 0)
                    animator.SetInteger("fullness", (int)fullness - 1);
                sw.Reset();
            }

        }

        // 칭찬할때 기분 1씩 증가
        if (isPraise)
        {
            sw.Start(); // 초를 재기 시작
            if ((sw.ElapsedMilliseconds * 0.001) > 1)
            {
                if(happy < 100)
                    animator.SetInteger("happy", (int)happy + 1);
                sw.Reset();
            }
        }

    }
}