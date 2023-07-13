//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Inputs/GameInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""0d96567e-d644-41d3-b48a-fa0a0a4c554d"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""UI"",
            ""id"": ""873e1eeb-97ac-48f1-9692-c84fd88545c8"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""7cf0a281-4ace-4bb9-afa5-7c3a2d604172"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f1c675c9-5a75-40a2-a9c7-db542bf7c885"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c2f4f9a-90c7-42a0-9a01-76818bfce349"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e44f6462-4c4f-4341-8c1c-ed73f294e335"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""84979082-c69d-47db-afda-a3dc64211635"",
            ""actions"": [
                {
                    ""name"": ""GoBack"",
                    ""type"": ""Button"",
                    ""id"": ""fd8b9e08-b841-4416-b552-6c15cba7e59e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkipMenu"",
                    ""type"": ""Button"",
                    ""id"": ""146fc28e-f559-4e8d-9fd3-8e60da4f86e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5ae2b6fe-98c9-4702-a289-dc53bf331aed"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15c7d26e-5d4e-43d0-a9dd-b83f5a48fd53"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cheats"",
            ""id"": ""01e4a1b7-8e95-4240-a616-d0b163dd1921"",
            ""actions"": [
                {
                    ""name"": ""AddPoints"",
                    ""type"": ""Button"",
                    ""id"": ""0b5f22f5-6586-4af4-8e38-55d4ed43343b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkipToWin"",
                    ""type"": ""Button"",
                    ""id"": ""22763042-2f49-4ac4-a870-e25bff01cef4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1a13db48-3bbf-4587-8c86-cd0f228394ba"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddPoints"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6e2e892-862a-4fc8-b776-1d2c7d2946fb"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipToWin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        m_UI_Select = m_UI.FindAction("Select", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_GoBack = m_Menu.FindAction("GoBack", throwIfNotFound: true);
        m_Menu_SkipMenu = m_Menu.FindAction("SkipMenu", throwIfNotFound: true);
        // Cheats
        m_Cheats = asset.FindActionMap("Cheats", throwIfNotFound: true);
        m_Cheats_AddPoints = m_Cheats.FindAction("AddPoints", throwIfNotFound: true);
        m_Cheats_SkipToWin = m_Cheats.FindAction("SkipToWin", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    public struct GameplayActions
    {
        private @GameInputs m_Wrapper;
        public GameplayActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    private readonly InputAction m_UI_Select;
    public struct UIActions
    {
        private @GameInputs m_Wrapper;
        public UIActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputAction @Select => m_Wrapper.m_UI_Select;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Select.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_GoBack;
    private readonly InputAction m_Menu_SkipMenu;
    public struct MenuActions
    {
        private @GameInputs m_Wrapper;
        public MenuActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @GoBack => m_Wrapper.m_Menu_GoBack;
        public InputAction @SkipMenu => m_Wrapper.m_Menu_SkipMenu;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @GoBack.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnGoBack;
                @GoBack.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnGoBack;
                @GoBack.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnGoBack;
                @SkipMenu.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSkipMenu;
                @SkipMenu.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSkipMenu;
                @SkipMenu.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSkipMenu;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GoBack.started += instance.OnGoBack;
                @GoBack.performed += instance.OnGoBack;
                @GoBack.canceled += instance.OnGoBack;
                @SkipMenu.started += instance.OnSkipMenu;
                @SkipMenu.performed += instance.OnSkipMenu;
                @SkipMenu.canceled += instance.OnSkipMenu;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // Cheats
    private readonly InputActionMap m_Cheats;
    private ICheatsActions m_CheatsActionsCallbackInterface;
    private readonly InputAction m_Cheats_AddPoints;
    private readonly InputAction m_Cheats_SkipToWin;
    public struct CheatsActions
    {
        private @GameInputs m_Wrapper;
        public CheatsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @AddPoints => m_Wrapper.m_Cheats_AddPoints;
        public InputAction @SkipToWin => m_Wrapper.m_Cheats_SkipToWin;
        public InputActionMap Get() { return m_Wrapper.m_Cheats; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CheatsActions set) { return set.Get(); }
        public void SetCallbacks(ICheatsActions instance)
        {
            if (m_Wrapper.m_CheatsActionsCallbackInterface != null)
            {
                @AddPoints.started -= m_Wrapper.m_CheatsActionsCallbackInterface.OnAddPoints;
                @AddPoints.performed -= m_Wrapper.m_CheatsActionsCallbackInterface.OnAddPoints;
                @AddPoints.canceled -= m_Wrapper.m_CheatsActionsCallbackInterface.OnAddPoints;
                @SkipToWin.started -= m_Wrapper.m_CheatsActionsCallbackInterface.OnSkipToWin;
                @SkipToWin.performed -= m_Wrapper.m_CheatsActionsCallbackInterface.OnSkipToWin;
                @SkipToWin.canceled -= m_Wrapper.m_CheatsActionsCallbackInterface.OnSkipToWin;
            }
            m_Wrapper.m_CheatsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AddPoints.started += instance.OnAddPoints;
                @AddPoints.performed += instance.OnAddPoints;
                @AddPoints.canceled += instance.OnAddPoints;
                @SkipToWin.started += instance.OnSkipToWin;
                @SkipToWin.performed += instance.OnSkipToWin;
                @SkipToWin.canceled += instance.OnSkipToWin;
            }
        }
    }
    public CheatsActions @Cheats => new CheatsActions(this);
    public interface IGameplayActions
    {
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnGoBack(InputAction.CallbackContext context);
        void OnSkipMenu(InputAction.CallbackContext context);
    }
    public interface ICheatsActions
    {
        void OnAddPoints(InputAction.CallbackContext context);
        void OnSkipToWin(InputAction.CallbackContext context);
    }
}
