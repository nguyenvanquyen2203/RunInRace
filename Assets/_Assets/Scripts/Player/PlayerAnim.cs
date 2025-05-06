using UnityEngine;

public class PlayerAnim : MonoBehaviour, IGameStateObserver
{
    private PlayerMovement playerMove;
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        playerMove = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        playerMove.jumpEvent.AddListener(JumpState);
        playerMove.slideEvent.AddListener(SlideState);
        PlayerState.Instance.deathEvt.AddListener(DeathState);
        GameManager.Instance.AddObserver(this);
    }
    public void JumpState()
    {
        anim.Play("Jump");
    }
    public void SlideState() => anim.Play("Slide");
    public void DeathState() => anim.Play("Death");

    public void StartState()
    {
        anim.Play("Running");
    }

    public void OverState()
    {
        throw new System.NotImplementedException();
    }
}
