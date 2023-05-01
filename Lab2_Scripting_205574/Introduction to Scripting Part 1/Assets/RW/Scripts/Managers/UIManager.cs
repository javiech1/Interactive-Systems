using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text sheepSaveText;
    public Text sheepDroppedText;
    public GameObject gameOverWindow;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdateSheepSave(){
        sheepSaveText.text = GameStateManager.Instance.sheepSaved.ToString();
    }
    public void UpdateSheepDropped(){
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow(){
        gameOverWindow.SetActive(true);
    }
}
