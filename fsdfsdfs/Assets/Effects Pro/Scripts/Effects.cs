// License: https://en.wikipedia.org/wiki/MIT_License
// The code in this script is written by Arnab Raha
// Code may be redistributed in source form, provided all the comments at the top here are kept intact

using UnityEngine;

public enum Fx {Greyscale, Sepia, Negative};

[ExecuteInEditMode]
[RequireComponent(typeof (Camera))]
public class Effects : MonoBehaviour {

	[Header ("Contrast & Brightness")]

	[Tooltip ("Turn on/off contrast and brightness adjustments")]
	public bool on = true;
	
	[Range (-50.0f, 100.0f)]
	public float contrast = 0.0f;

	[Range (-100.0f, 100.0f)]
	public float brightness = 0.0f;
	
	[Header ("Color Adjustments")]

	[Tooltip ("Choose the effect type to apply it on the renderer")]
	public Fx effectType = Fx.Greyscale;
    
    [Range (0.0f, 1.0f)]
    [Tooltip ("Style strength for the image effect (not applicable for 'Negative')")]
	public float styleStrength = 0.0f;

	private Shader _shader;
	private Shader _cAndB;

	private Material _gMat;
	private Material _cb;

	void Start () {
		_cAndB = Shader.Find ("Hidden/Contrast&Brightness");
		_cb = new Material (_cAndB);
		_cb.hideFlags = HideFlags.HideAndDontSave;
		CheckHwSupport ();
	}

	Material Material {
		get {
			if (_gMat == null) {
                _gMat = new Material (_shader);
                _gMat.hideFlags = HideFlags.HideAndDontSave;
            }
            return _gMat;
		}
	}

    void OnDisable () {
    	if (_gMat) {
	        DestroyImmediate (_gMat);
	    }
    }

    void OnRenderImage (RenderTexture source, RenderTexture destination) {
		SetFx (effectType);
		if (on) {
			RenderTexture renderTemp = RenderTexture.GetTemporary(source.width, source.height);
			float brig = brightness / 175;
			float cont = contrast * 2.0f;

			_cb.SetFloat ("_Cont", cont);
			_cb.SetFloat ("_Bright", brig);

			Graphics.Blit (source, renderTemp, _cb);

	        Material.SetTexture ("_MainTex", renderTemp);
	        Material.SetFloat ("_Strength", styleStrength);

	        Graphics.Blit (renderTemp, destination, Material);
			RenderTexture.ReleaseTemporary (renderTemp);
		} else {
			Material.SetFloat ("_Strength", styleStrength);
			Graphics.Blit (source, destination, Material);
		}
	}

	/// <summary>
	/// Set image effect to apply it on the renderer.
	/// </summary>
	/// <param name="effect">Effect.</param>
    public void SetFx (Fx effect) {
    	effectType = effect;
		if (effect == Fx.Greyscale) {
			_shader = Shader.Find ("Hidden/Greyscale");
		} else if (effect == Fx.Sepia) {
			_shader = Shader.Find ("Hidden/Sepia");
		} else {
			_shader = Shader.Find ("Hidden/Negative");
		}
		Material.shader = _shader;
    }

	/// <summary>
	/// Disables all the image effects associated with Effects.
	/// </summary>
    public void DisableFx () {
		if (enabled)
			this.enabled = false;
    }

	/// <summary>
	/// Enables all the image effects associated with Effects,
	/// </summary>
    public void EnableFx () {
		if (!enabled)
			this.enabled = true;
    }

    private bool CheckHwSupport () {
        if (!_cAndB || !_cAndB.isSupported) {
        	enabled = false;
        	Debug.LogError ("Some of the shaders are not supproted on this platform");
        	return false;
        }
        return true;
    }
}