using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer GambitSpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        float xAmount = direction.x * GameParameters.PlayerMoveSpeed;
        float yAmount = direction.y * GameParameters.PlayerMoveSpeed;
        
        GambitSpriteRenderer.transform.Translate(xAmount,yAmount,0.0f);
    }
}
