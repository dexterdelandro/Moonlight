using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Candle : MonoBehaviour
{
    public float maxTime = 30f;
    private float curTime;
    private bool lit;
    public bool held;
    private GameObject player;
    public bool justPickedUp;
    private float startYLength;
    private float lastHeight;
    public Camera cam;
    private GameObject monster;
    public float stunDist = 1f;
    public float playerMaxUnstunNoticeDist = 3f; //Mouthful i know
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        lit = false;
        held = false;
        curTime = maxTime;
        justPickedUp = false;
        startYLength = transform.localScale.y;
        lastHeight = transform.localScale.y;
        monster = GameObject.Find("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.paused)
        {
            if (held)
            {
                transform.position = cam.transform.position + cam.transform.forward * 8f;
                if (Input.GetKeyDown(KeyCode.E) && !justPickedUp)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, Vector3.down, out hit))
                    {
                        transform.position = new Vector3(hit.point.x, hit.point.y + transform.localScale.y, hit.point.z);
                    }
                    held = false;
                    player.GetComponent<PickUpCandle>().holding = false;
                    player.GetComponent<PickUpCandle>().justDropped = true;
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (curTime > 0f)
                    {
                        lit = !lit;
                        if (lit)
                        {
                            transform.GetChild(0).gameObject.SetActive(true);
                        }
                        else
                        {
                            transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                }
            }
            if (lit)
            {
                if (curTime > 0f)
                {
                    if (Vector3.Distance(monster.transform.position, transform.position) < stunDist)
                    {
                        monster.GetComponent<ArriveAtPoint>().curState = MonsterState.Stunned;
                        monster.GetComponent<NavMeshAgent>().enabled = false;
                        monster.GetComponent<Animator>().SetInteger("battle", 3);
                        monster.GetComponent<Animator>().SetInteger("moving", 0);
                        Debug.Log("Stunned");
                        //monster.GetComponent<THC1_ctrl>().battle_state = 3;
                    }
                    else if (monster.GetComponent<ArriveAtPoint>().curState == MonsterState.Stunned)
                    {
                        UnStun();
                    }
                    curTime -= Time.deltaTime;
                    if (curTime <= 0f)
                    {
                        if (monster.GetComponent<ArriveAtPoint>().curState == MonsterState.Stunned)
                        {
                            UnStun();
                        }
                        curTime = 0f;
                        lit = false;
                        transform.GetChild(0).gameObject.SetActive(false);
                        Destroy(gameObject);
                    }
                    float height = startYLength * (curTime / maxTime);
                    transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, transform.position.y - (lastHeight - height) / 2, transform.position.z);
                    lastHeight = height;
                }
            }
            else if (monster.GetComponent<ArriveAtPoint>().curState == MonsterState.Stunned)
            {
                UnStun();
            }
            justPickedUp = false;
        }
    }

    private void UnStun()
    {
        monster.GetComponent<ArriveAtPoint>().curState = MonsterState.Patrolling;
        monster.GetComponent<NavMeshAgent>().enabled = true;
        if (Vector3.Distance(player.transform.position, monster.transform.position) < playerMaxUnstunNoticeDist)
        {
            monster.GetComponent<ArriveAtPoint>().NewPosition(player.transform.position);
        }
        else
        {
            monster.GetComponent<Animator>().SetInteger("battle", 0);
            monster.GetComponent<Animator>().SetInteger("moving", 0);
        }
    }
}
