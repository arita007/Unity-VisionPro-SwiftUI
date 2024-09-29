using System.Collections.Generic;
using AOT;
using PolySpatial.Samples;
using UnityEngine;

#if UNITY_VISIONOS && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace Samples.PolySpatial.SwiftUI.Scripts
{
    // This is a driver MonoBehaviour that connects to SwiftUISamplePlugin.swift via
    // C# DllImport. See SwiftUISamplePlugin.swift for more information.
    public class SwiftUIDriver : MonoBehaviour
    {
        void OnEnable()
        {
            SetNativeCallback(CallbackFromNative);
        }

        void OnDisable()
        {
            SetNativeCallback(null);
        }
        
        /// <summary>
        /// Close all SwiftUI windows
        /// </summary>
        public void ForceCloseWindow()
        {
            
        }
        
        delegate void CallbackDelegate(string command);

        // This attribute is required for methods that are going to be called from native code
        // via a function pointer.
        [MonoPInvokeCallback(typeof(CallbackDelegate))]
        static void CallbackFromNative(string command)
        {
            Debug.Log("Callback from native: " + command);
        }

        public void UpdateSwiftUIWindow(string windowName, bool show)
        {
            if (show)
            {
                OpenSwiftUIWindow(windowName);
            }
            else
            {
                CloseSwiftUIWindow(windowName);
            }
        }

        public void UpdateInjectSwiftUIWindow(bool show)
        {
            UpdateInjectView(show);
        }

        public void UpdateInjectSwiftUIWindowPos(Vector3 pos)
        {
            UpdateInjectViewPos(pos.x, pos.y, pos.z);
        }


#if UNITY_VISIONOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        static extern void SetNativeCallback(CallbackDelegate callback);

        [DllImport("__Internal")]
        static extern void OpenSwiftUIWindow(string name);

        [DllImport("__Internal")]
        static extern void CloseSwiftUIWindow(string name);
        
        [DllImport("__Internal")]
        static extern void UpdateInjectView(bool show);
        
        [DllImport("__Internal")]
        static extern void UpdateInjectViewPos(float x, float y, float z);
#else
        static void SetNativeCallback(CallbackDelegate callback) {}
        static void OpenSwiftUIWindow(string name) {}
        static void CloseSwiftUIWindow(string name) {}

        static void UpdateInjectView(bool show)
        {
        }

        static void UpdateInjectViewPos(float x, float y, float z)
        {
        }
#endif
 
    }
}
