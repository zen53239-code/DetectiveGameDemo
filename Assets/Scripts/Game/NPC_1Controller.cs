using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_1Controller : MonoBehaviour
{
    Animator animator;
    GameObject Cit_1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Cit_1 = GameObject.Find("Cit_1");
        animator = Cit_1.GetComponent<Animator>();
        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator move()
    {
        animator.SetFloat("action", 1);
        Vector3 left = new Vector3(0, 0, 0);
        Vector3 right = new Vector3(0, 180, 0);
        var newposition = new Vector3(-1 * speed, 0,0);
        bool walk = true;
        while (true)
        {
            if(Cit_1.transform.position .x<0)
            {
                walk=false;
                Cit_1.transform.rotation = Quaternion.Euler(right);
            }
            if (Cit_1.transform.position.x>12)
            {
                walk = true;
                Cit_1.transform.rotation = Quaternion.Euler(left);
            }
            if (walk)
            {
                Cit_1.transform.position += newposition * Time.deltaTime;
            }
            else
            {
                Cit_1.transform.position += newposition * Time.deltaTime*-1;
            }
            yield return null;
        }
    }
}
