using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showItem(int i)
    {
        switch (i)
        {
            case 0:
                UIController.CreateDialogue("-城市通行证-");
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
