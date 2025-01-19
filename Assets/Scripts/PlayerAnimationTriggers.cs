using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player _player => GetComponentInChildren<Player>();

    private void AnimationTriggered()
    {
        _player.AnimationTriggered();
    }
}
