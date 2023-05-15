using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public AudioSource firstHit, keyPickup, stickThrown, foodPickup, potionPickup, treasurePickup, level1, level2, level3, lowOnHealth, warrior, wizard, valkyrie, elf;

    private AudioSource playerType;
    private PlayerSO _playerSO;
    private PlayerMovement _player;
    private bool _isFirstHit = true;
    private bool _isFirstKey = true;
    private bool _isFirstAttack = true;
    private bool _canWarn = true;

    private void Awake()
    {
        _player = gameObject.GetComponent<PlayerMovement>();
        _playerSO = _player.BasePlayer;

        switch (_playerSO.name)
        {
            case "Elf":
                playerType = elf;
                break;

            case "Valkyrie":
                playerType = valkyrie;
                break;

            case "Wizard":
                playerType = wizard;
                break;

            case "Warrior":
                playerType = warrior;
                break;

            default:
                Debug.Log("Player Type: " + _playerSO.name);
                break;
        }
    }

    private void Update()
    {
        if (_player.isThrowing && _isFirstAttack)
        {
            _isFirstAttack = false;
            stickThrown.Play();
        }

        if(_player.playerHealth < 200)
        {
            if (_canWarn)
            {
                _canWarn = false;
                StartCoroutine(HealthWarning());               
            }
            
        }

        if (_player.playerHealth > 200)
            _canWarn = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<EnemyMovement>())
        {
            if (_isFirstHit)
            {
                _isFirstHit = false;
                firstHit.Play();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            if (_isFirstKey)
            {
                _isFirstKey = false;
                keyPickup.Play();
            }
        }


    }


    private IEnumerator HealthWarning()
    {
        playerType.Play();
        yield return new WaitForSeconds(playerType.clip.length);
        lowOnHealth.Play();
    }
}
