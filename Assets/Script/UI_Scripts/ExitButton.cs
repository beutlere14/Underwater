
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExitButton : MonoBehaviour
{
 
    //the button this is attached to
    public Button button1;

 

    // Start is called before the first frame update
    void Start()
    {
      // adding the listender so it can be clicked
        button1.onClick.AddListener(taskonclick);


    }

    //To load the main level
    void taskonclick()
    {
        quitGame();
    }



    public void quitGame()
    {
        Application.Quit();
    }

   
}
