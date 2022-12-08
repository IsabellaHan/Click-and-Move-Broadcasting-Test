using UnityEngine;
using UnityEngine.UI;

public class OffScreenIndicator : MonoBehaviour
{
    // private
    Transform target;
    Vector3 offset;
    Renderer rend;
    Collectible col;

    // public
    public Image Img;
   
    public void SetNewCollectible()
    {
        col = GameManager.Instance.CurrentCollectible;
        target = col.transform;
        Img.sprite = col.CollectibleType.UISprite;
        rend = col.rd;
    }

    void Update()
    {
        if(target)
        {
            if(rend.isVisible)
            {
                Img.enabled = false;
            }
            else
            {
                Img.enabled = true;
            }

            float minX = Img.GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;

            float minY = Img.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;

            Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

            if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            {
                if(pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            Img.transform.position = pos;
        }
    }
}
