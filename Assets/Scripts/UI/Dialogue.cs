using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text DialogueContent;
    void Start()
    {
        StartCoroutine(Dialogue_Destroy());
    }
    public IEnumerator Dialogue_Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
