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
        EntranceScene, //무덤 입구 맵
        DungeonScene// 던전 내부 맵
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;//니가 찾는 정보가 이 아이다! 라고 초기화     
    }

    // Start is called before the first frame update
    void Start()
    {
        CurPos = Current.StartScene;
        SceneManager.LoadScene("2Start Scene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            GoToCastle();
        }
        
    }

    public void GoToDungeon()
    {
       SceneManager.LoadScene("3Dungeon Entrance Scene");
    }

    public void GoToLobby()//go to Home
    {
        CurPos = Current.StartScene;
        SceneManager.LoadScene("2Start Scene");
    }

    public void GoToRestart()//go to Restart
    {
        CurPos = Current.EntranceScene;
        SceneManager.LoadScene("3Dungeon Entrance Scene");
    }

    public void GoToBack()//go to Back
    {
        CurPos = Current.StartScene;
        SceneManager.LoadScene("2Start Scene");
    }

    public void GoToCastle()//go to stage 2
    {
        SceneManager.LoadScene("4Dungeon Stage Scene");
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
}