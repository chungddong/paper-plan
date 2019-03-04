using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonserList : MonoBehaviour
{
    public static MonserList instance;
    public GameObject 현미;
    public GameObject 핑크플라워;
    public GameObject 그린플라워;
    public GameObject 블루플라워;
    public GameObject 보스플라워;
    public GameObject 용암정령;
    public GameObject 리프불;
    public GameObject 리프라이언;
    public bool is몬스터Die = false;
   


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 몬스터활성화()
    {
       if(Playbutton.instance.몬스터번호 == 10)
        {
            현미.SetActive(true);
            transform.localScale = new Vector3(0.8f, 0.9f, 1);

        }
        if (Playbutton.instance.몬스터번호 == 11)
        {
            핑크플라워.SetActive(true);
            transform.localScale = new Vector3(1.4f, 1.45f, 1);
        }
        if (Playbutton.instance.몬스터번호 == 12)
        {
            그린플라워.SetActive(true);
            transform.localScale = new Vector3(1.45f, 1.38f, 1);
        }
        if (Playbutton.instance.몬스터번호 == 13)
        {
            블루플라워.SetActive(true);
            transform.localScale = new Vector3(1.6f, 1.25f, 1);
        }
        if (Playbutton.instance.몬스터번호 == 14)
        {
            리프불.SetActive(true);
            transform.localScale = new Vector3(1.3f, 1.35f, 1);
        }
        if (Playbutton.instance.몬스터번호 == 15)
        {
            리프라이언.SetActive(true);
            transform.localScale = new Vector3(1.6f, 1.6f, 1);
        }
        if (Playbutton.instance.몬스터번호 == 101)
        {
            보스플라워.SetActive(true);
            transform.localScale = new Vector3(1.2f, 1.15f, 1);
        }
        if (Playbutton.instance.몬스터번호 == 20)
        {
            용암정령.SetActive(true);
            transform.localScale = new Vector3(0.77f, 1f, 1);
        }
    }

    public void 몬스터비활성화()
    {
        if (Playbutton.instance.몬스터번호 == 10)
        {
            현미.SetActive(false);
        }
        if (Playbutton.instance.몬스터번호 == 11)
        {
            핑크플라워.SetActive(false);
        }
        if (Playbutton.instance.몬스터번호 == 12)
        {
            그린플라워.SetActive(false);
        }
        if (Playbutton.instance.몬스터번호 == 13)
        {
            블루플라워.SetActive(false);
        }
        if (Playbutton.instance.몬스터번호 == 14)
        {
            리프불.SetActive(false);
        }
        if (Playbutton.instance.몬스터번호 == 15)
        {
            리프라이언.SetActive(false);
        }
        if (Playbutton.instance.몬스터번호 == 101)
        {
             보스플라워.SetActive(false);
        }
        if (Playbutton.instance.몬스터번호 == 20)
        {
            용암정령.SetActive(false);
        }
    }

    public void 몬스터데미지주기(int 데미지)
    {
        if (Playbutton.instance.몬스터번호 == 10)
        {
            MonsterHpManager.MHPManager.MHP -= 데미지;
        }
        if (Playbutton.instance.몬스터번호 == 11)
        {
            핑크플라워HP.instance.MHP -= 데미지;
        }
        if (Playbutton.instance.몬스터번호 == 12)
        {
            그린플라워hp.instance.MHP -= 데미지;
        }
        if (Playbutton.instance.몬스터번호 == 13)
        {
            블루플라워HP.instance.MHP -= 데미지;
        }
        if (Playbutton.instance.몬스터번호 == 14)
        {
            리프불HP.instance.MHP -= 데미지;
        }
        if (Playbutton.instance.몬스터번호 == 15)
        {
            리프라이언HP.instance.MHP -= 데미지;
        }
        if (Playbutton.instance.몬스터번호 == 101)
        {
            보스플라워HP.instance.MHP -= 데미지;
        }
        if (Playbutton.instance.몬스터번호 == 20)
        {
            용암정령HP.instance.MHP -= 데미지;
        }
    }
    public void 몬스터체력초기화()
    {
        if (Playbutton.instance.몬스터번호 == 10)
        {
            MonsterHpManager.MHPManager.몬스터체력초기화();
        }
        if (Playbutton.instance.몬스터번호 == 11)
        {
            핑크플라워HP.instance.몬스터체력초기화();
        }
        if (Playbutton.instance.몬스터번호 == 12)
        {
            그린플라워hp.instance.몬스터체력초기화();
        }
        if (Playbutton.instance.몬스터번호 == 13)
        {
            블루플라워HP.instance.몬스터체력초기화();
        }
        if (Playbutton.instance.몬스터번호 == 14)
        {
            리프불HP.instance.몬스터체력초기화();
        }
        if (Playbutton.instance.몬스터번호 == 15)
        {
            리프라이언HP.instance.몬스터체력초기화();
        }
        if (Playbutton.instance.몬스터번호 == 101)
        {
            보스플라워HP.instance.몬스터체력초기화();
        }
        if (Playbutton.instance.몬스터번호 == 20)
        {
            용암정령HP.instance.몬스터체력초기화();
        }
    }

    public void is몬스터Die초기화()
    {
        is몬스터Die = false;
    }
}
