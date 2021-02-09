using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChicken : MonoBehaviour
{
    // 펫의 이동 속도, 회전 속도
    public float zTranslation = 0;
    public float yRotation = 0;
    public float moveSpeed = 0.0008f;
    public float rotateSpeed = 10.0f;
    private float dampSpeed = 0.3f;
    bool firstbehaved = false;
    public float time = 0;

    Animator animator;
    GameObject obj;

    Animator aniRed;

    // Start is called before the first frame update
    void Start()
    {
        //치킨세팅
        animator = gameObject.GetComponent<Animator>();
        obj = GameObject.FindGameObjectWithTag("Player");
        animator.SetBool("Live", true);
        //StartCoroutine(WaitForIt());
        //Red불러오기
        //aniRed = GameObject.Find("Red").Getcomponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            PetMoveToFront();
        }
        
        
        

        if (!animator.GetBool("Live"))
        {
            //StartCoroutine(WaitSec());
            Destroy(obj, 0.5f);
        }
    }

    public void PetMoveToFront()
    {
        // 직진
        Vector3 v = new Vector3(0, 0, 1);
        zTranslation -= moveSpeed;
        transform.position = Vector3.Lerp(transform.position, transform.position+v, Time.deltaTime * dampSpeed);
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2f);
    }
}
