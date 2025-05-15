using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public Color defaultColor;

    private bool hasBeenHit;
    private bool hasBeenHitWithSpell;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasBeenHit = false;
        hasBeenHitWithSpell = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckHasBeenHit()
    {
        return hasBeenHit;
    }

    public bool CheckHasBeenHitWithSpell()
    {
        return hasBeenHitWithSpell;
    }

    public void SetHasBeenHit(bool hasBeenHit)
    {
        this.hasBeenHit = hasBeenHit;
    }

    public void SetHasBeenHitWithSpell(bool hasBeenHitWithSpell)
    {
        this.hasBeenHitWithSpell = hasBeenHitWithSpell;
    }
}
