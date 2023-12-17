
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonBase : MonoBehaviour
{
    //scene name we want to open
    public string sceneName;

    //the button this is attached to
    public Button button1;

    //text that could be on a UI but we want it blank
   

    // Start is called before the first frame update
    void Start()
    {
      // adding the listender so it can be clicked
        button1.onClick.AddListener(taskonclick);

     
       
    }

    //To load the main level
    void taskonclick()
    {
        SceneManager.LoadScene(sceneName);
    }





    // Update is called once per frame
    void Update()
    {
 
    }

   
}
