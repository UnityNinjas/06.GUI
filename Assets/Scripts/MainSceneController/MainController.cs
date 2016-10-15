using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

public class MainController : MonoBehaviour
{
    public StandaloneInputModule standaloneInput;

    [Header("Level 2")]
    public Transform door;
    public Light lightOnDoor;
    public Collider2D colliderOnDoor;
    public ParticleSystem hackEffect;
    [Space(10)]
    [Header("Level 3")]
    public GameObject laserOnDoor;

    public Transform finishDoor;
    public Collider2D colliderOnFinishDoor;
    public ParticleSystem hackEffectFinish;

    public void Start()
    {
        SoundManager.instance.MusicPlay(Clip.Rain);
        Object.DontDestroyOnLoad(SoundManager.instance);
    }

    public void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            Hud.instance.ToggleEscapeMenu();
        }
    }

    public void OnDoorLockerClicked()
    {
        this.hackEffect.Emit(2);
        StartCoroutine(OpenDoor(this.door, this.colliderOnDoor));
    }

    public void OnFinishDoorLockerClicked()
    {
        StartCoroutine(OpenDoor(this.finishDoor, this.colliderOnDoor));
        this.colliderOnFinishDoor.isTrigger = true;
        this.hackEffectFinish.Emit(2);
    }

    private IEnumerator OpenDoor(Transform door, Collider2D collider)
    {
        while (door.rotation.y > 0)
        {
            door.Rotate(new Vector3(0, -5f));
            yield return new WaitForEndOfFrame();
        }

        collider.enabled = false;
        this.lightOnDoor.color = Color.green;
    }
}