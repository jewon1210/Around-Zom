using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    //public float[] score;
    static Scene_Manager instance;//반장역할<오브젝트 찾아준다>
    public static Scene_Manager control { get { return instance; } }//반장보호
    public Current CurPos;
    int Score; //넘어갈때 변화 없게
    public int Count_HpPack=0;
    public int Count_Grenade = 0;

    public enum Current
    {
        EmptyScene,
        StartScene,
        TutorialScene,
        OptionScene,
        Stage1Scene
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //score = new float[3];
        //score[0] = 0;
        //score[1] = 0;
        //score[2] = 0;
        Score = 0;
        instance = this;//니가 찾는 정보가 이 아이다! 라고 초기화     
    }

    // Start is called before the first frame update
    void Start()
    {
        CurPos = Current.StartScene;
        SceneManager.LoadScene("2Start Scene");
        HealthPackReset();
        GrenadeReset();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurPos == Current.Stage1Scene)
        {
            ScorePoint(GameManager.instance.ResultScore());
        }


        if (Input.GetKeyDown(KeyCode.F2))
        {
            Go_Stage2();
        }


        if (Input.GetKeyDown(KeyCode.F3))
        {
            Go_Stage3();
        }

    }

    public void ScoreZero()
    {
         Score =0;
    }
    
    public int ScoreResult()//다음스테이지 넘어갈때 점수 알려주는 함수
    {
        return Score;
    }

    public void ScorePoint(int num)
    {
        Score = num;
        //Debug.Log("ScorePoint함수"+Score);
    }

    public void Go_ToTheGame()
    {
        CurPos = Current.Stage1Scene;
        ScorePoint(0);
        SceneManager.LoadScene("3Stage1 Scene");
    }

    public void Go_Tutorial()//go to tutorial
    {
        CurPos = Current.TutorialScene;
        ScorePoint(0);
        SceneManager.LoadScene("Tutorial Scene");
    }

    public void Go_Option()//go to Option
    {
        CurPos = Current.OptionScene;
        SceneManager.LoadScene("Option Scene");
    }

    public void Go_Home()//go to Home
    {
        CurPos = Current.StartScene;
        ScorePoint(0);
        HealthPackReset();
        GrenadeReset();
        SceneManager.LoadScene("2Start Scene");
    }

    public void Go_Restart()//go to Restart
    {
        CurPos = Current.Stage1Scene;
        ScorePoint(0);
        HealthPackReset();
        GrenadeReset();
        SceneManager.LoadScene("3Stage1 Scene");
    }

    public void Go_Back()//go to Back
    {
        CurPos = Current.StartScene;
        SceneManager.LoadScene("2Start Scene");
    }

    public void Go_Stage2()//go to stage 2
    {
        SceneManager.LoadScene("4Stage2 Scene");
    }

    public void Go_Stage3()//go to stage 3
    {
        SceneManager.LoadScene("5Stage3 Scene");
    }

    public void Go_Ending()
    {
        SceneManager.LoadScene("6Ending Scene");
    }

    public void Exit_Game()
    {
#if UNITY_EDITOR
        //에디터에 play버튼을 끄는 역활
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //빌드에서는 가능하지만 에디터에서는 안된다.
        Application.Quit();
#endif
    }

    public void UserDB_HealthPack(int Value)//헬스팩 개수 저장
    {
        Count_HpPack = Value;
    }

    public int KnowingHpPackCount()//개수 알려주기
    {
        return Count_HpPack;
    }

    public void HealthPackReset()//개수초기화
    {
        Count_HpPack = 0;
    }

    public void UserDB_GrenadePack(int Value)//수류탄 개수 저장
    {
        Count_Grenade += Value;
    }

    public int KnowingGrenadeCount()// Grenade 개수 알려주기
    {
        return Count_Grenade;
    }

    public void GrenadeReset()// Grenade 개수초기화
    {
        Count_Grenade = 0;
    }

}