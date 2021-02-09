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
    public float rotateSpeed = 5.0f;

    // 애니메이터 컨트롤러 변수
    Animator animator;
    public bool isSleep;
    public bool isFeed;
    public bool isPraise;
    public bool isWalk;

    Vector3 initPetPosition;
    Vector3 nowPetPosition;
    [SerializeField] private Text textValue;

    //치킨 변수
    public GameObject myPrefab;
    public GameObject chicken;
    Animator animator_chicken;
    GameObject gameobj_chicken;
    Transform transform_chicken;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        // Pet초기 상태
        //zTranslation = nowPetPosition.z;
        initPetPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        nowPetPosition = this.transform.position;
        //textValue.text = nowPetPosition.ToString();
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
    }

    public void FeedControl()
    {
        // 밥먹기

        Debug.Log("Feed Clicked");
        //int fullness = animator.GetInteger("fullness");
        //animator.SetInteger("fullness", (int)fullness + 10);
        SetActiveCondition("isFeed", isFeed);
        if (animator.GetBool("isFeed")) {
            SetChicken();
        }
    }

    public void PraiseControl()
    {
        //칭찬
        SetActiveCondition("isPraise", isPraise);
    }

    public void WalkControl()
    {
        // 걷기
        SetActiveCondition("isWalk", isWalk);
    }
    
    //먹이 버튼 눌렀을 때 치킨 세팅
    public void SetChicken()
    {
        Debug.Log("chicken made0");
        //make chicken
        //chicken = Instantiate(myPrefab, new Vector3(0, 0, 10), Quaternion.identity) as GameObject;
        Vector3 v = new Vector3(0, 0, 3);
        chicken = Instantiate(myPrefab, transform.position + v, Quaternion.identity) as GameObject;
        Debug.Log("chicken made");
        Debug.Log(chicken);
        //set chicken tag
        chicken.gameObject.tag = "Player";

        //set chicken things
        /*
        gameobj_chicken = GameObject.FindGameObjectWithTag("Player");
        animator_chicken = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        transform_chicken = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        */
    }

}
