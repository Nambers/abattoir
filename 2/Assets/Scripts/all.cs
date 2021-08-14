using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class all : MonoBehaviour {
    public bool dier = false;
    GameObject abc;
    public GameObject g2;
    public GameObject g1;
    public GameObject unkind;
    public GameObject kind;
    public bool only_c = false;
    public GameObject boom;
    public int winner;
    public bool start = false;
    public GameObject servant;
    public GameObject servant_b;
    public GameObject centerControl;
    public void die (int win) {
        if (win == 1) {
            abc = g2;
        } else {
            abc = g1;
        }
        boom.transform.position = abc.transform.position;
        abc.transform.localScale = new Vector3 (0f, 0f, 0f);
        boom.GetComponent<ParticleSystem> ().Play ();
        winner = win;
        dier = true;
        Invoke ("PauseGame", 3F);
    }
    public bool IsGamePaused;

    void Start ()

    {

    }

    void Update () {

        if (Input.GetKey (KeyCode.Escape))

        {
            PauseGame ();
        }

    }
    void OnGUI () {

        if (!IsGamePaused || start)

            return;
        if (dier) {

            ///自动布局，按照区域

            Time.timeScale = 0;
            GUILayout.BeginArea (new Rect ((Screen.width - 100) / 2, (Screen.height - 200) / 2, 100, 200));

            ///横向

            GUILayout.BeginVertical ();

            GUILayout.TextArea ("玩家" + winner + "赢了", GUILayout.Height (50));
            if (GUILayout.Button ("退出到主菜单", GUILayout.Height (50)))

            {
                centerControl.GetComponent<go> ().back2menu ();
            }
            if (GUILayout.Button ("退出游戏", GUILayout.Height (50)))

            {

                Application.Quit ();

            }

            GUILayout.TextArea ("More detail in: https://github.com/Nambers/", GUILayout.Width (100), GUILayout.Height (50));

            GUILayout.EndVertical ();

            GUILayout.EndArea ();
            return;
        }

        ///自动布局，按照区域

        GUILayout.BeginArea (new Rect ((Screen.width - 100) / 2, (Screen.height - 200) / 2, 100, 200));

        ///横向

        GUILayout.BeginVertical ();

        if (IsGamePaused)

        {

            if (GUILayout.Button ("继续游戏", GUILayout.Height (50))) {

                StartGame ();

            }

        }
        if (GUILayout.Button ("退出到主菜单", GUILayout.Height (50)))

        {
            centerControl.GetComponent<go> ().back2menu ();
        }
        if (GUILayout.Button ("退出游戏", GUILayout.Height (50)))

        {

            Application.Quit ();

        }

        GUILayout.TextArea ("More detail: https://github.com/Nambers/", GUILayout.Width (100), GUILayout.Height (50));

        GUILayout.EndVertical ();

        GUILayout.EndArea ();

    }

    public void StartGame () {
        IsGamePaused = false;
        Time.timeScale = 1;
    }

    void PauseGame () {
        IsGamePaused = true;
        Time.timeScale = 0;
    }
}