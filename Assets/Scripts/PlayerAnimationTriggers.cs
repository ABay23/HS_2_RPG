using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player _player => GetComponentInParent<Player>();

    private void AnimationTriggered()
    {
        _player.AnimationTriggered();
    }
}
