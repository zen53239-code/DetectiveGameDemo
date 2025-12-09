using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public RectTransform joystick;
    static RectTransform talkbutton;
    static GameObject dialogue;
    public Canvas canvas;
    static GameObject dialoguetransform;
    public static float dialoguepos;
    public GameObject bagWindow;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.Find("Joystick").GetComponent<RectTransform>();
        joystick.anchoredPosition = new Vector2(300,300);
        talkbutton = GameObject.Find("talk").GetComponent<RectTransform>();
        talkbutton.anchoredPosition = new Vector2(Screen.width/2-400,-300);
        talkbutton.gameObject.SetActive(false);
        canvas= GameObject.Find("Canvas").GetComponent<Canvas>();
        //Dialogue
        dialogue = Resources.Load<GameObject>("Prefab/Dialogue");
        GameObject emptyObj = new GameObject("dialoguetransform");
        emptyObj.AddComponent<RectTransform>();
        emptyObj.transform.SetParent(canvas.transform, false);
        dialoguetransform = emptyObj;
        dialoguepos =- Screen.height * 4 / 10;
        //bag
        bagWindow= GameObject.Find("Bag_window");
        bagWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void OpenTalk()
    {
        talkbutton.gameObject.SetActive(true);
    }
    public static void CloseTalk()
    {
        talkbutton.gameObject.SetActive(false);
    }
    public static void CreateDialogue(string Content)
    {
        GameObject NewDialogue = Instantiate(dialogue, Vector3.zero, Quaternion.identity);
        NewDialogue.GetComponent<RectTransform>().SetParent(dialoguetransform.GetComponent<RectTransform>(), false);
        NewDialogue.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, dialoguepos);
        NewDialogue.GetComponent<Dialogue>().DialogueContent.text = Content;
    }
    public void openBagWindow()
    {
        bagWindow.SetActive(true);
    }
    public void closeBagWindow()
    {
        bagWindow.SetActive(false);
    }
}
