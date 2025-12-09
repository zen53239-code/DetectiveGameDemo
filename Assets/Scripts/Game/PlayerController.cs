using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talknode
{
    public Vector3 pos;
    public int talknum;
    public talknode(Vector3 position,int num)
    {
        pos=position;
        talknum=num;
    }
}
public class PlayerController : MonoBehaviour
{
    Joystick joystick;
    Animator animator;
    GameObject player;
    Rigidbody2D rigidbody_player;
    public float speed;
    GameObject[] tipicons=new GameObject[3];
    bool[] havetalk=new bool[3];
    public talknode[] node=new talknode[3];
    int currentnodenum = 0;
    //Npc
    NPC_2Controller npc_2;
    // Start is called before the first frame update
    void Start()
    {
        joystick=GameObject.Find("Joystick").GetComponent<Joystick>();
        player = GameObject.Find("Player");
        tipicons[0] = GameObject.Find("tip_0");
        tipicons[1] = GameObject.Find("tip_1");
        tipicons[2] = GameObject.Find("tip_2");
        rigidbody_player = player.GetComponent<Rigidbody2D>();
        animator=player.GetComponent<Animator>();
        node[0] = new talknode(GameObject.Find("Police_1").transform.position,0);
        node[1] = new talknode(GameObject.Find("Cit_2").transform.position,1);
        node[2] = new talknode(GameObject.Find("King").transform.position,2);
        npc_2 = GameObject.Find("NPCController").GetComponent<NPC_2Controller>();
        StartCoroutine(move());
        StartCoroutine(detect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator move()
    {
        Vector3 left = new Vector3(0,0,0);
        Vector3 right = new Vector3(0, 180,0);
        while (true)
        {
            float x=joystick.Input.x;
            float y=joystick.Input.y;
            if (x != 0 ||y != 0)
            {
                if (x > 0)
                {
                    player.transform.rotation = Quaternion.Euler(right);
                }
                else
                {
                    player.transform.rotation = Quaternion.Euler(left);

                }
                var newposition = new Vector2(x * speed, y * speed );
                rigidbody_player.MovePosition((Vector2)player.transform.position+ newposition*Time.deltaTime);
                //player.transform.position += (Vector3)newposition * Time.deltaTime;
                //rigidbody_player.velocity = newposition * Time.deltaTime;
                animator.SetFloat("action", 1);
            }
            else
            {
                animator.SetFloat("action", 0);

            }
            //yield return new WaitForSeconds(0.3f);
            yield return null;
        }
    }
    IEnumerator detect()
    {
        float distance;
        while (true)
        {
            bool showbutton = false;
            for(int i = 0; i < 3; i++)
            {
                if (!havetalk[i])
                {
                    distance = Vector3.Distance(player.transform.position, node[i].pos);
                    if (distance < 1)
                    {
                        showbutton = true;
                        currentnodenum = i;
                        break;
                    }
                }
            }
            if (showbutton)
            {
                UIController.OpenTalk();
            }
            else
            {
                UIController.CloseTalk();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void starttalk()
    {
        switch (currentnodenum)
        {
            case 0:
                StartCoroutine(talk_0());
                break;
            case 1:
                StartCoroutine(talk_1());
                break;
            case 2:
                StartCoroutine(talk_2());
                break;
        }
    }
    IEnumerator talk_0()
    {
        UIController.CloseTalk();
        tipicons[currentnodenum].SetActive(false);
        havetalk[currentnodenum] = true;
        UIController.CreateDialogue("警员:欢迎你，侦探");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("警员:沿这条路笔直走就能到市中心");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("警员:国王陛下已经那里在等你了");
    }
    IEnumerator talk_1()
    {
        UIController.CloseTalk();
        tipicons[currentnodenum].SetActive(false);
        havetalk[currentnodenum] = true;
        UIController.CreateDialogue("商贩:快来看看今天的报纸！");
        yield return null;
    }
    IEnumerator talk_2()
    {
        UIController.CloseTalk();
        tipicons[currentnodenum].SetActive(false);
        havetalk[currentnodenum] = true;
        UIController.CreateDialogue("国王:欢迎来到A王国,侦探");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("国王:最近市中心区域发生了很多起凶杀案");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("国王:但是凶手一直没被抓住");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("国王:你也许能在现场找到些线索");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("国王:往北走一条街就能到达森林公园");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("国王:第一起凶杀案就是在那里发生的");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("国王:警员会带你去那里的");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("我:给我两天时间,我一定能抓到凶手");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("国王:祝你好运，侦探");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("-获得物品:城市通行证-");
        yield return new WaitForSeconds(1.5f);
        UIController.CreateDialogue("警员:跟我来，侦探");
        yield return new WaitForSeconds(1f);
        npc_2.StartMove();
        yield return new WaitForSeconds(5f);
        UIController.CreateDialogue("警员:第一起凶杀案发生在十天前");
        yield return new WaitForSeconds(5f);
        UIController.CreateDialogue("警员:死者是在森林公园的仓库中被发现的");
        yield return new WaitForSeconds(5f);
        UIController.CreateDialogue("警员:死者是森林公园的保洁人员");
        yield return new WaitForSeconds(5f);
        UIController.CreateDialogue("警员:法医结果显示死因是头部遭钝器击打");
        yield return new WaitForSeconds(5f);
        UIController.CreateDialogue("警员:现场只发现了死者，没找到凶器");
        yield return new WaitForSeconds(5f);
        UIController.CreateDialogue("警员:我们到了");
        yield return new WaitForSeconds(5f);
        UIController.CreateDialogue("警员:请进吧，侦探");
        yield return null;
    }
}
