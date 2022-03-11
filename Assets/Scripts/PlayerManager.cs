using UnityEngine;

public class PlayerManager : BaseManager
{
    private AIManager _aiManager;
    [SerializeField] protected CanvasGroup _buttonGroup;
    protected override void Start()
    {
        base.Start();
        _aiManager = GetComponent<AIManager>();
        if (_aiManager == null)
        {
            Debug.LogError("AIManager not found");
        }

        if (_buttonGroup == null)
        {
            Debug.LogError("CanvasGroup _buttonGroup not attached");
        }
        
    }

    public override void TakeTurn()
    {
        _buttonGroup.interactable = true;
    }

    protected override void EndTurn()
    {
        _buttonGroup.interactable = false;
        _aiManager.TakeTurn();
    }

    public void Splash()
    {
        _aiManager.DealDamage(40.3f);
        EndTurn();
    }

    public void IronTail()
    {
        _aiManager.DealDamage(10f);
        EndTurn();
    }

    public void Rest()
    {
        Heal(30f);
        EndTurn();
    }

    public void SelfDestruct()
    {
        DealDamage(_maxHealth);
        _aiManager.DealDamage(80f);
        EndTurn();
    }
}
