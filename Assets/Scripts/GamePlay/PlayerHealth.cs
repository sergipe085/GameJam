using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : Health {
    private PostProcessVolume volume;
    Vignette vignette;
    LensDistortion lensDistortion;

    private void Awake() {
        volume = FindObjectOfType<PostProcessVolume>().GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out lensDistortion);
    }

    public override void TakeDamage(float damage, GameObject damageCauser)
    {
        base.TakeDamage(damage, damageCauser);
    }

    public override void Die(GameObject deathCauser)
    {
        base.Die(deathCauser);

        PlayerController.instance.DisableController();

        PostProcessEffects();
        CameraController.instance.StartScreenShake(0.05f, 0.1f, 0.98f);
        StartCoroutine(GameController.instance.GameOver(false, 1.0f));
    }

    private void Update() {
        if (IsDead()) {
            PostProcessEffects();
        }
    }

    private void PostProcessEffects() {
        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.4f, Time.deltaTime * 3);
        lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, 50, Time.deltaTime * 3);
    }
}