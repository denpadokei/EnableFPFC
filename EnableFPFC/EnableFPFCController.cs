using IPA.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnableFPFC
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class EnableFPFCController : MonoBehaviour
    {
        // These methods are automatically called by Unity, you should remove any you aren't using.
        #region Monobehaviour Messages
        private FirstPersonFlyingController firstPersonFlyingController;
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            Plugin.Log?.Debug($"{name}: Awake()");
        }
        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        private void Start()
        {
            if (!Environment.GetCommandLineArgs().Any(x => x.ToUpper() == "FPFC")) {
                return;
            }
            this.firstPersonFlyingController = Instantiate(Resources.FindObjectsOfTypeAll<FirstPersonFlyingController>().FirstOrDefault());
            if (this.firstPersonFlyingController == null) {
                return;
            }
            var cams = Resources.FindObjectsOfTypeAll<Camera>();
            foreach (var cam in cams) {
                if (cam.name == "MainCamera") {
                    cam.enabled = false;
                    this.firstPersonFlyingController.GetField<Camera, FirstPersonFlyingController>("_camera").enabled = true;
                }
            }
        }
        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            Plugin.Log?.Debug($"{name}: OnDestroy()");
            if (this.firstPersonFlyingController != null) {
                Destroy(this.firstPersonFlyingController);
                this.firstPersonFlyingController = null;
            }
        }
        #endregion
    }
}
