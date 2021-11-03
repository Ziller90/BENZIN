// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Vehicle"",
            ""id"": ""a0d2b900-b75b-42a4-b94e-78bbfaaf9daf"",
            ""actions"": [
                {
                    ""name"": ""CarControl"",
                    ""type"": ""Value"",
                    ""id"": ""1acd45cd-d6cc-45fb-ad05-645d0b4f69d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GunControl"",
                    ""type"": ""Value"",
                    ""id"": ""773da908-30d1-4dd2-ba3f-ef2bce78743e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GunIsShooting"",
                    ""type"": ""Button"",
                    ""id"": ""ce370daa-7395-490e-8a8f-7af8cdaa05ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CarIsBraking"",
                    ""type"": ""Button"",
                    ""id"": ""03020cbd-4f23-475a-903f-98fefab5b0bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db9951dc-803c-440d-9649-d8d03147771a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControlScheme"",
                    ""action"": ""CarControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af097b19-e798-4557-b554-9f510c5ec2e0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControlScheme"",
                    ""action"": ""GunControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ad3c11c-e7ac-4806-b997-97e589726b53"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControlScheme"",
                    ""action"": ""GunIsShooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""438a5588-5f82-4bd1-b0bd-65137124c26e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CarIsBraking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""XboxControlScheme"",
            ""bindingGroup"": ""XboxControlScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Vehicle
        m_Vehicle = asset.FindActionMap("Vehicle", throwIfNotFound: true);
        m_Vehicle_CarControl = m_Vehicle.FindAction("CarControl", throwIfNotFound: true);
        m_Vehicle_GunControl = m_Vehicle.FindAction("GunControl", throwIfNotFound: true);
        m_Vehicle_GunIsShooting = m_Vehicle.FindAction("GunIsShooting", throwIfNotFound: true);
        m_Vehicle_CarIsBraking = m_Vehicle.FindAction("CarIsBraking", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Vehicle
    private readonly InputActionMap m_Vehicle;
    private IVehicleActions m_VehicleActionsCallbackInterface;
    private readonly InputAction m_Vehicle_CarControl;
    private readonly InputAction m_Vehicle_GunControl;
    private readonly InputAction m_Vehicle_GunIsShooting;
    private readonly InputAction m_Vehicle_CarIsBraking;
    public struct VehicleActions
    {
        private @InputMaster m_Wrapper;
        public VehicleActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CarControl => m_Wrapper.m_Vehicle_CarControl;
        public InputAction @GunControl => m_Wrapper.m_Vehicle_GunControl;
        public InputAction @GunIsShooting => m_Wrapper.m_Vehicle_GunIsShooting;
        public InputAction @CarIsBraking => m_Wrapper.m_Vehicle_CarIsBraking;
        public InputActionMap Get() { return m_Wrapper.m_Vehicle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VehicleActions set) { return set.Get(); }
        public void SetCallbacks(IVehicleActions instance)
        {
            if (m_Wrapper.m_VehicleActionsCallbackInterface != null)
            {
                @CarControl.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnCarControl;
                @CarControl.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnCarControl;
                @CarControl.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnCarControl;
                @GunControl.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnGunControl;
                @GunControl.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnGunControl;
                @GunControl.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnGunControl;
                @GunIsShooting.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnGunIsShooting;
                @GunIsShooting.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnGunIsShooting;
                @GunIsShooting.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnGunIsShooting;
                @CarIsBraking.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnCarIsBraking;
                @CarIsBraking.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnCarIsBraking;
                @CarIsBraking.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnCarIsBraking;
            }
            m_Wrapper.m_VehicleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CarControl.started += instance.OnCarControl;
                @CarControl.performed += instance.OnCarControl;
                @CarControl.canceled += instance.OnCarControl;
                @GunControl.started += instance.OnGunControl;
                @GunControl.performed += instance.OnGunControl;
                @GunControl.canceled += instance.OnGunControl;
                @GunIsShooting.started += instance.OnGunIsShooting;
                @GunIsShooting.performed += instance.OnGunIsShooting;
                @GunIsShooting.canceled += instance.OnGunIsShooting;
                @CarIsBraking.started += instance.OnCarIsBraking;
                @CarIsBraking.performed += instance.OnCarIsBraking;
                @CarIsBraking.canceled += instance.OnCarIsBraking;
            }
        }
    }
    public VehicleActions @Vehicle => new VehicleActions(this);
    private int m_XboxControlSchemeSchemeIndex = -1;
    public InputControlScheme XboxControlSchemeScheme
    {
        get
        {
            if (m_XboxControlSchemeSchemeIndex == -1) m_XboxControlSchemeSchemeIndex = asset.FindControlSchemeIndex("XboxControlScheme");
            return asset.controlSchemes[m_XboxControlSchemeSchemeIndex];
        }
    }
    public interface IVehicleActions
    {
        void OnCarControl(InputAction.CallbackContext context);
        void OnGunControl(InputAction.CallbackContext context);
        void OnGunIsShooting(InputAction.CallbackContext context);
        void OnCarIsBraking(InputAction.CallbackContext context);
    }
}
