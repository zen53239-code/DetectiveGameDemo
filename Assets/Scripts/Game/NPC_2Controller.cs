using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2Controller : MonoBehaviour
{
    Animator animator;
    GameObject Police_2;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Police_2 = GameObject.Find("Police_2");
        animator = Police_2.GetComponent<Animator>();
    }

    public void StartMove()
    {
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        animator.SetFloat("action", 1);
        Vector3 left = new Vector3(0, 0, 0);
        Vector3 right = new Vector3(0, 180, 0);
        var newposition = new Vector3(0.7f * speed, 0.7f * speed, 0);
        Police_2.transform.rotation = Quaternion.Euler(right);
        while (true)
        {
            if (Police_2.transform.position.x >18.3f)
            {
                break;
            }
            Police_2.transform.position += newposition * Time.deltaTime ;
            yield return null;
        }
        newposition = new Vector3(0, 1f * speed, 0);
        Police_2.transform.rotation = Quaternion.Euler(left);
        while (true)
        {
            if (Police_2.transform.position.y>10.5f)
            {
                break;
            }
            Police_2.transform.position += newposition * Time.deltaTime;
            yield return null;
        }
        newposition = new Vector3(-0.7f * speed, 0.7f * speed, 0);
        while (true)
        {
            if (Police_2.transform.position.x <17.7f)
            {
                break;
            }
            Police_2.transform.position += newposition * Time.deltaTime;
            yield return null;
        }
        newposition = new Vector3(0, 1f * speed, 0);
        while (true)
        {
            if (Police_2.transform.position.y > 12f)
            {
                break;
            }
            Police_2.transform.position += newposition * Time.deltaTime;
            yield return null;
        }
        animator.SetFloat("action", 0);

    }
}
