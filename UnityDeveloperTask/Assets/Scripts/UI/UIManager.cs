using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
     // private
     Collectible col;

     // public
     public EventChannel SpeedUpdateUI;
     public EventChannel CollectibleUpdateUI;
     public Text SpeedText;
     public Text AppleCollectibleText;
     public Text CakeCollectibleText;
     public Text SodaCollectibleText;
     public Animation AppleStarAnim;
     public Animation CakeStarAnim;
     public Animation SodaStarAnim;

     void Start()
     {
          SpeedUpdateUI.OnEventRaised += DoUpdateSpeedText;
          GameManager.Instance.OnUpdatingCollectibles += DoUpdateCollectibleText;
     }
     public void FasterButton()
     {
        GameManager.Instance.PlayerController.IncreaseSpeed();
     }

     public void SlowerButton()
     {
          GameManager.Instance.PlayerController.DecreaseSpeed();
     }

     void DoUpdateSpeedText()
     {
          if(SpeedText)
          {
               SpeedText.text = GameManager.Instance.PlayerController.agent.speed.ToString();
          }
     }

     void DoUpdateCollectibleText(Collectible col)
     {
          
          switch(col.CollectibleType.CollectibleName)
          {
               case "Apple":
                    AppleCollectibleText.text = GameManager.Instance.AppleScore.ToString();
                    AppleStarAnim.Play();
                    break;
               case "Soda":
                    SodaCollectibleText.text = GameManager.Instance.SodaScore.ToString();
                    SodaStarAnim.Play();
                    break;
               case "Cake":
                    CakeCollectibleText.text = GameManager.Instance.CakeScore.ToString();
                    CakeStarAnim.Play();
                    break;
          }
     }

     public void ExitGame()
     {
          Application.Quit();
     }

}
