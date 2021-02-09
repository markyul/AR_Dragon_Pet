using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PetManager : MonoBehaviour
{
    // 펫의 상태
    public int fullness = 50;   // 보통
    public int tired = 50;      // 보통
    public int happy = 50;      // 보통
    
    // 펫의 이동 속도, 회전 속도
    public float zTranslation = 0;
    public float yRotation = 0; 
    public float moveSpeed = 0.0008f;
    public float rotateSpeed = 10.0f;

    // 애니메이터 컨트롤러 변수
    Animator animator;
    public bool isSleep;
    public bool isFeed;
    public bool isPraise;
    public bool isWalk;

    Vector3 pos;
    [SerializeField] private Text textValue;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        // Pet초기 상태
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isWalk") == true){
            // while(yRotation != -180.0f){
            //     PetMoveToLeft();
            // }
            PetMoveToFront();
            pos = this.transform.position;
            //Debug.Log(pos);
            textValue.text = pos.ToString();
        }
    }

    // 동작 수행에 필요한  함수들
    public void SetActiveCondition(string conditionName, bool activeCondition)
    {
        activeCondition = animator.GetBool(conditionName);
        activeCondition = !activeCondition;
        animator.SetBool(conditionName, activeCondition);
    }
    
    public void SleepControl()
    {
        // 잠자기
        SetActiveCondition("isSleep", isSleep);
        // tired 연산
        if(isSleep) {
            tired -= 30;
            if(tired < 0)
                tired = 0;
        }
    }

    public void FeedControl()
    {
        // 밥먹기
        SetActiveCondition("isFeed", isFeed);
        // fullness, happy 연산
        if(isFeed) {
            fullness +=30;
            happy += 20;
            if(100 < fullness)
                fullness = 100;
            if(100 < happy)
                happy = 100;
        }
    }

    public void PraiseControl()
    {
        //칭찬
        SetActiveCondition("isPraise", isPraise);
        // happy 연산
        if(isPraise){
            happy +=20;
            if(100 < happy)
                happy = 100;
        }
    }

    public void WalkControl()
    {
        // 걷기
        SetActiveCondition("isWalk", isWalk);
        if(isWalk){
            // pet상태 연산
        }
    }

    public void PetMoveToFront()
    {
        // 직진
        zTranslation -= moveSpeed;
        transform.position = new Vector3(0,0,zTranslation);
    }

    public void PetMoveToLeft()
    {
        // 왼쪽으로 회전 후 앞으로 약간 이동
        yRotation -= rotateSpeed;
        transform.Rotate(0,yRotation,0);
        PetMoveToFront();
    }

    public void PetMoveToRight()
    {
        // 오른쪽으로 회전 후 앞으로 약간 이동
        yRotation += rotateSpeed;
        transform.Rotate(0,yRotation,0);
        PetMoveToFront();
    }

    public void PetFly()
    {
        // 나는 애니메이션이 있지만 혹시 좌표 설정이 필요할까봐 넣어뒀어요
    }

}
