using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource _source;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private ParticleSystem _moveParticles, _landParticles;
    [SerializeField] private AudioClip[] _footsteps;
    [SerializeField] private float _maxTilt = .1f;
    [SerializeField] private float _tiltSpeed = 1;
    [SerializeField, Range(1f, 3f)] private float _maxIdleSpeed = 2;
    [SerializeField] private float _maxParticleFallSpeed = -40;

    private IPlayerController _player;
    private bool _playerGrounded;
    private ParticleSystem.MinMaxGradient _currentGradient;
    private Vector2 _movement;

    [SerializeField] private float _timeBetweenFootsteps = 0.5f;
    private float _footStepTimer;

    void Awake() 
    {
        _player = GetComponentInParent<IPlayerController>();
        _footStepTimer = _timeBetweenFootsteps;

        // Kick dust on direction change
        InputHandler _inputHandler = ServiceLocator.Instance.Get<InputManager>().Inputs();
        _inputHandler.Move().performed += _ => KickDust();
    }

    void Update() {
        if (_player == null) return;

        // Flip the sprite
        if (_player.Input.X != 0) transform.localScale = new Vector3(_player.Input.X > 0 ? 1 : -1, 1, 1);

        // Lean while running
        var targetRotVector = new Vector3(0, 0, Mathf.Lerp(-_maxTilt, _maxTilt, Mathf.InverseLerp(-1, 1, _player.Input.X)));
        // _anim.transform.rotation = Quaternion.RotateTowards(_anim.transform.rotation, Quaternion.Euler(targetRotVector), _tiltSpeed * Time.deltaTime);

        // Speed up idle while running
        // _anim.SetFloat(IdleSpeedKey, Mathf.Lerp(1, _maxIdleSpeed, Mathf.Abs(_player.Input.X)));

        // Footstep sound loop
        _footStepTimer -= Time.deltaTime;
        if ((_player.Input.X != 0 || _player.Input.Y != 0) && _footStepTimer < 0f) 
        {
            // _anim.SetTrigger(GroundedKey);
            // _source.PlayOneShot(_footsteps[Random.Range(0, _footsteps.Length)]);
        }

        if (_footStepTimer < 0f)
        {
            _footStepTimer = _timeBetweenFootsteps;
        }

        // Play landing effects and begin ground movement effects
        // if (!_playerGrounded && _player.Grounded) 
        // {
        //     _playerGrounded = true;
        //     _moveParticles.Play();
        //     _landParticles.transform.localScale = Vector3.one * Mathf.InverseLerp(0, _maxParticleFallSpeed, _movement.y);
        //     SetColor(_landParticles);
        //     _landParticles.Play();
        // }
        // else if (_playerGrounded && !_player.Grounded) 
        // {
        //     _playerGrounded = false;
        //     _moveParticles.Stop();
        // }

        // Detect ground color
        var groundHit = Physics2D.Raycast(transform.position, Vector3.down, 2, _groundMask);
        if (groundHit && groundHit.transform.TryGetComponent(out SpriteRenderer r)) 
        {
            _currentGradient = new ParticleSystem.MinMaxGradient(r.color * 0.9f, r.color * 1.2f);
            SetColor(_moveParticles);
        }

        _movement = _player.RawMovement; // Previous frame movement is more valuable
    }

    private void OnDisable() 
    {
        _moveParticles.Stop();
    }

    private void OnEnable() 
    {
        _moveParticles.Play();
    }

    void SetColor(ParticleSystem ps) 
    {
        var main = ps.main;
        main.startColor = _currentGradient;
    }

    void KickDust()
    {
        if(!_moveParticles.isPlaying) {
            _moveParticles.Play();
            return;
        }

        if(_moveParticles.isPlaying) {
            _moveParticles.Stop();
            _moveParticles.Play();
        }
    }

    #region Animation Keys

    // private static readonly int GroundedKey = Animator.StringToHash("Grounded");
    private static readonly int IdleSpeedKey = Animator.StringToHash("IdleSpeed");
    // private static readonly int JumpKey = Animator.StringToHash("Jump");

    #endregion
}
