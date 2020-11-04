using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class go : MonoBehaviour
{
    //对象
    public GameObject mainCamera;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject player;
    public GameObject T;
    public GameObject all;
    public GameObject boom;
    private int mode=0;
    public GameObject light1, light2, light3, light4;
    private bool a=true, b, c, d=true;
    // Use this for initialization
    void Start()
    {
        boom.GetComponent<ParticleSystem>().Stop();
        player.active = false;
        mainCamera.active = true;
        camera1.active = false;
        camera2.active = false;
        camera3.active = false;
        camera4.active = false;
        all.GetComponent<all>().IsGamePaused = true;
        all.GetComponent<all>().start = true;
        light1.GetComponent<Light>().intensity = 0;
        light2.GetComponent<Light>().intensity = 0;
        light3.GetComponent<Light>().intensity = 0;
        light4.GetComponent<Light>().intensity = 0;
        Time.timeScale = 0;
    }
    void OnGUI()

    {
        if (!all.GetComponent<all>().start) return;


        if (mode == 0)
        {
            GUILayout.BeginArea(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2 + 70, 300, 200));

            ///横向

            GUILayout.BeginVertical();



            if (GUILayout.Button("一般模式", GUILayout.Height(50), GUILayout.Width(100)))
            {
                mainCamera.active = false;
                player.active = true;
                mode = 1;
                return;
            }

            if (GUILayout.Button("冲撞模式", GUILayout.Height(50), GUILayout.Width(100)))
            {
                mode = 2;
                mainCamera.active = false;
                player.active = true;

                return;
            }
            GUILayout.TextArea("wsad和上下左右箭头控制行动,f和/控制攻击\n一般模式---普通\n冲撞模式---只能撞击\n击败对手或将其击下地面", GUILayout.Width(300), GUILayout.Height(50));
            GUILayout.EndVertical();

            GUILayout.EndArea();
        }
        else
        {
            GUILayout.BeginArea(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 200, 400));

            ///横向

            GUILayout.BeginVertical();

            if (GUILayout.Button("玩家1，角色1", GUILayout.Height(40), GUILayout.Width(100))) { a = true; b = false;if (c) { c = false;d = true; } }
            if (GUILayout.Button("玩家1，角色2", GUILayout.Height(40), GUILayout.Width(100))) { b = true; a = false; if (d) { d = false; c = true; } }
            if (GUILayout.Button("玩家2，角色1", GUILayout.Height(40), GUILayout.Width(100))) { c = true; d = false; if (a) { a = false; b = true; } }
            if (GUILayout.Button("玩家2，角色2", GUILayout.Height(40), GUILayout.Width(100))) { d = true; c = false; if (b) { b = false; a = true; } }
            if (a) { light1.GetComponent<Light>().intensity = 100; } else { light1.GetComponent<Light>().intensity = 0; }
            if (b) { light2.GetComponent<Light>().intensity = 100; }
            else
            {
                light2.GetComponent<Light>().intensity = 0;
            }

            if (c) { light3.GetComponent<Light>().intensity = 100; } else { light3.GetComponent<Light>().intensity = 0; }
            if (d) { light4.GetComponent<Light>().intensity = 100; } else { light4.GetComponent<Light>().intensity = 0; }
            if (GUILayout.Button("确定", GUILayout.Height(40), GUILayout.Width(100))) {
                if (a) all.GetComponent<all>().g1 = GameObject.Find("player1");
                if (b) all.GetComponent<all>().g1 = GameObject.Find("player1_b");
                if (c) all.GetComponent<all>().g2 = GameObject.Find("player2");
                if (d) all.GetComponent<all>().g2 = GameObject.Find("player2_b");
                if (a) { all.GetComponent<all>().kind = all.GetComponent<all>().g1; all.GetComponent<all>().unkind = all.GetComponent<all>().g2; }
                if (b) { all.GetComponent<all>().kind = all.GetComponent<all>().g2; all.GetComponent<all>().unkind = all.GetComponent<all>().g1; }
                
                if (mode == 1) {
                    Time.timeScale = 1;
                    all.GetComponent<all>().start = false;
                    if (all.GetComponent<all>().g1.name == "player1") camera1.active = true;
                    if (all.GetComponent<all>().g1.name == "player2") camera2.active = true;
                    if (all.GetComponent<all>().g1.name == "player1_b") camera3.active = true;
                    if (all.GetComponent<all>().g1.name == "player2_b") camera4.active = true;
                    if (all.GetComponent<all>().g2.name == "player1") camera1.active = true;
                    if (all.GetComponent<all>().g2.name == "player2") camera2.active = true;
                    if (all.GetComponent<all>().g2.name == "player1_b") camera3.active = true;
                    if (all.GetComponent<all>().g2.name == "player2_b") camera4.active = true;
                    all.GetComponent<all>().StartGame();
                    all.GetComponent<all>().g1.transform.position = new Vector3(-131f, -58.6f, 582.8f);
                    all.GetComponent<all>().g2.transform.position = new Vector3(713.7f, -58.6f, -269.5f);
                    T.transform.localScale = new Vector3(0f, 0f, 0f);
                    GameObject.Find("servant1").transform.position = new Vector3(all.GetComponent<all>().kind.transform.position.x, all.GetComponent<all>().kind.transform.position.y, all.GetComponent<all>().kind.transform.position.z+20f);
                    GameObject.Find("servant_b1").transform.position = new Vector3(all.GetComponent<all>().unkind.transform.position.x, all.GetComponent<all>().unkind.transform.position.y, all.GetComponent<all>().unkind.transform.position.z-20f);
                    return;
                }
                if (mode == 2)
                {
                    Time.timeScale = 1;
                    all.GetComponent<all>().only_c = true;
                    all.GetComponent<all>().start = false;
                    if (all.GetComponent<all>().g1.name == "player1") camera1.active = true;
                    if (all.GetComponent<all>().g1.name == "player2") camera2.active = true;
                    if (all.GetComponent<all>().g1.name == "player1_b") camera3.active = true;
                    if (all.GetComponent<all>().g1.name == "player2_b") camera4.active = true;
                    if (all.GetComponent<all>().g2.name == "player1") camera1.active = true;
                    if (all.GetComponent<all>().g2.name == "player2") camera2.active = true;
                    if (all.GetComponent<all>().g2.name == "player1_b") camera3.active = true;
                    if (all.GetComponent<all>().g2.name == "player2_b") camera4.active = true;
                    all.GetComponent<all>().StartGame();
                    all.GetComponent<all>().g1.transform.position = new Vector3(-131f, -58.6f, 582.8f);
                    all.GetComponent<all>().g2.transform.position = new Vector3(713.7f, -58.6f, -269.5f);
                    T.transform.localScale = new Vector3(0f, 0f, 0f);
                    
                    GameObject.Find("servant1").transform.position = new Vector3(all.GetComponent<all>().kind.transform.position.x, all.GetComponent<all>().kind.transform.position.y, all.GetComponent<all>().kind.transform.position.z + 20f);
                    GameObject.Find("servant_b1").transform.position = new Vector3(all.GetComponent<all>().unkind.transform.position.x, all.GetComponent<all>().unkind.transform.position.y, all.GetComponent<all>().unkind.transform.position.z-20f);
                    return;
                }
            }
            GUILayout.EndVertical();

            GUILayout.EndArea();
        }
    }
        // Update is called once per frame
        void Update()
    {
        
        
    }

}
