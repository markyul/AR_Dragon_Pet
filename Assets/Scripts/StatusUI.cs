using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [SerializeField] private Text fullnessValue;
    [SerializeField] private Text tiredValue;
    [SerializeField] private Text happyValue;

    [SerializeField] private Image fullnessGaugeBar;
    [SerializeField] private Image tiredGaugeBar;
    [SerializeField] private Image happyGaugeBar;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TiredBar();
        FullnessBar();
        HappyBar();
    }
    // 포만도 게이지 보여주기
    public void FullnessBar()
    {

        fullnessGaugeBar.fillAmount = animator.GetInteger(fullnessValue.name) / 100f;
        fullnessValue.text = animator.GetInteger(fullnessValue.name).ToString();
        //Debug.Log(animator.GetInteger(fullnessValue.name) + "status");
    }
    // 피로도 게이지 보여주기
    public void TiredBar()
    {

        tiredGaugeBar.fillAmount = animator.GetInteger(tiredValue.name) / 100f;
        tiredValue.text = animator.GetInteger(tiredValue.name).ToString();
        //Debug.Log(animator.GetInteger(tiredValue.name) + "status");
    }
    // 기분 게이지 보여주기
    public void HappyBar()
    {

        happyGaugeBar.fillAmount = animator.GetInteger(happyValue.name) / 100f;
        happyValue.text = animator.GetInteger(happyValue.name).ToString();
        //Debug.Log(animator.GetInteger(happyValue.name) + "status");
    }
}
