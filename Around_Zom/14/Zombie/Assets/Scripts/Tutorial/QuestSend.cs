using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSend : MonoBehaviour
{
    Npc_Ani aniAccept;
    Image DiaImg;
    float Distan;
    public GameObject[] QuestUI;//text 로
    //bool FirstThird;
    public GameObject DialoImg;
    int OptionIndex;
    public GameObject Coin;
    public GameObject Bullet;
    public GameObject Health;
    public GameObject Skip;
    bool go;
    GameObject Pack;

    private void Awake()
    {
    }

    public void goToFalse()// go to Tutorial
    {
        go = false;
        Skip.SetActive(false);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        go = false;
        Skip.SetActive(false);
        OptionIndex = 0;
        aniAccept = gameObject.GetComponent<Npc_Ani>();
        //DialoImg.gameObject.SetActive(false);
        DiaImg = DialoImg.GetComponent<Image>();
        DiaImg.color = new Color(0, 0, 0, 0);//투명화
        QuestUI[0].SetActive(false);
        QuestUI[1].SetActive(false);
        QuestUI[2].SetActive(false);
        QuestUI[3].SetActive(false);
        QuestUI[4].SetActive(false);
        QuestUI[5].SetActive(false);
        QuestUI[6].SetActive(false);
        QuestUI[7].SetActive(false);
        QuestUI[8].SetActive(false);
        QuestUI[9].SetActive(false);
        QuestUI[10].SetActive(false);
        QuestUI[11].SetActive(false);
        QuestUI[12].SetActive(false);

        Pack = gameObject.GetComponent<GameObject>();
        
 //       FirstThird = false;//1인칭

        //foreach (GameObject opt in QuestUI)
        //{
        //    opt.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            go = true;
            Skip.SetActive(true);//튜토리얼 신으로 되돌아가는거에서 go=false로 바꿔야함           
        }

        if(go)
        {
            return;
        }


        //ChangeEye();
        Distan = aniAccept.Distance();
        
        if(Distan<=5.0f)
        {
            //DialoImg.SetActive(true);
            DiaImg.color = new Color(0, 0, 0, 0.6196079f);//불투명화

            if (OptionIndex==0)
            {
                QuestUI[0].SetActive(true);
                //OnOffUI(OptionIndex); //인사말
                OptionIndex++;
            }

            else if(Input.GetKeyDown(KeyCode.Return) && OptionIndex ==1)
            {
                QuestUI[0].SetActive(false);
                QuestUI[1].SetActive(true);
                //OnOffUI(OptionIndex);//인덱스 1
            }

            else if (Input.GetKeyDown(KeyCode.W) && OptionIndex==1)
            {
                OptionIndex++;//2
                QuestUI[2].SetActive(true);
                QuestUI[1].SetActive(false);
                //OnOffUI(OptionIndex);//2-> 맞았습니다
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 2)
            {
                OptionIndex++;//3
                QuestUI[3].SetActive(true);
                QuestUI[2].SetActive(false);
                //OnOffUI(OptionIndex);//a키 눌러보세요 실행
            }

            else if (Input.GetKeyDown(KeyCode.A) && OptionIndex == 3)
            {
                QuestUI[3].SetActive(false);
                QuestUI[2].SetActive(true);
                //OnOffUI(2);//2->맞았습니다
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 3)
            {
                OptionIndex++;//4
                QuestUI[4].SetActive(true);
                QuestUI[2].SetActive(false);
                //OnOffUI(OptionIndex);//s키를 눌러보세요
            }

            else if (Input.GetKeyDown(KeyCode.S) && OptionIndex == 4)
            {
                QuestUI[4].SetActive(false);
                QuestUI[2].SetActive(true);
                //OnOffUI(2);//2->맞았습니다
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 4)
            {
                OptionIndex++;//5
                QuestUI[2].SetActive(false);
                QuestUI[5].SetActive(true);
                //OnOffUI(OptionIndex);//d키를 눌러보세요
            }

            else if (Input.GetKeyDown(KeyCode.D) && OptionIndex == 5)
            {
                QuestUI[2].SetActive(true);
                QuestUI[5].SetActive(false);
                //OnOffUI(2);//2->맞았습니다.
            }
           
            //3인칭 시점 전환

            else if(Input.GetKeyDown(KeyCode.Return) && OptionIndex ==5)
            {
                OptionIndex++;//6
                QuestUI[2].SetActive(false);
                QuestUI[6].SetActive(true);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha1) && OptionIndex == 6)
            {
                OptionIndex++;
                QuestUI[2].SetActive(true);
                QuestUI[6].SetActive(false);
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 7)
            {
                OptionIndex++;//7
                QuestUI[2].SetActive(false);
                QuestUI[7].SetActive(true);
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 8)
            {
                OptionIndex++;
                QuestUI[7].SetActive(false);
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 9)
            {
                OptionIndex++;
                QuestUI[8].SetActive(true);
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 10)
            {
                OptionIndex++;
                QuestUI[8].SetActive(false);
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 11)
            {               
                OptionIndex++;
                QuestUI[9].SetActive(true);//먼저 코인을 획득해볼까요?
                Pack = Instantiate(Coin);//코인 리스폰
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 12)
            {
                OptionIndex++;
                QuestUI[9].SetActive(false);
                QuestUI[2].SetActive(true);// 성공
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 13)
            {
                OptionIndex++;
                QuestUI[2].SetActive(false);
                QuestUI[10].SetActive(true);//헬스팩을 획득해볼까요?
                Pack = Instantiate(Health);//코인 리스폰
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 14)
            {
                OptionIndex++;
                QuestUI[10].SetActive(false);
                QuestUI[2].SetActive(true);// 성공
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 15)
            {
                OptionIndex++;
                QuestUI[2].SetActive(false);
                QuestUI[11].SetActive(true);//총알을 획득해볼까요?
                Pack = Instantiate(Bullet);
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 16)
            {
                OptionIndex++;
                QuestUI[11].SetActive(false);
                QuestUI[2].SetActive(true);// 성공
            }

            else if (Input.GetKeyDown(KeyCode.Return) && OptionIndex == 17)
            {
                OptionIndex++;
                QuestUI[2].SetActive(false);
                QuestUI[12].SetActive(true);// 뒤로가기
            }



        }
        else
            DiaImg.color = new Color(0, 0, 0, 0);//투명화
        //1번키를 눌러 시점을 변환하세요

        //3인칭

    }

}