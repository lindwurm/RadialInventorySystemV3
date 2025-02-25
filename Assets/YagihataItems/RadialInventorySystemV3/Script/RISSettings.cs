﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDKBase;
using YagihataItems.YagiUtils;

namespace YagihataItems.RadialInventorySystemV3
{
    public class RISSettings : MonoBehaviour, IEditorExtSettings
    {
        [SerializeField] public VRCAvatarDescriptor AvatarRoot { get { return risVariables.AvatarRoot; } set { risVariables.AvatarRoot = value; } }
        [SerializeField] public bool WriteDefaults { get { return risVariables.WriteDefaults; } set { risVariables.WriteDefaults = value; } }
        [SerializeField] public bool OptimizeParams { get { return risVariables.OptimizeParams; } set { risVariables.OptimizeParams = value; } }
        [SerializeField] public string FolderID { get { return risVariables.FolderID; } set { risVariables.FolderID = value; } }
        [SerializeField] public List<PropGroup> Groups { get { return risVariables.Groups; } set { risVariables.Groups = value; } }

        [SerializeField] [HideInInspector] public RISVariables risVariables = new RISVariables();
        [SerializeField] public RISV3.RISMode MenuMode { get { return risVariables.MenuMode; } set { risVariables.MenuMode = value; } }
        [SerializeField] public bool ApplyEnabled { get { return risVariables.ApplyEnabled; } set { risVariables.ApplyEnabled = value; } }
        public void SetVariables(IEditorExtVariables variables)
        {
            if (!(variables is RISVariables))
                return;
            var risVariables = variables as RISVariables;
            this.AvatarRoot = risVariables.AvatarRoot;
            this.WriteDefaults = risVariables.WriteDefaults;
            this.OptimizeParams = risVariables.OptimizeParams;
            this.FolderID = risVariables.FolderID;
            this.Groups = risVariables.Groups;
            this.MenuMode = risVariables.MenuMode;
            this.ApplyEnabled = risVariables.ApplyEnabled;
        }
        public IEditorExtVariables GetVariables()
        {
            return new RISVariables()
            {
                AvatarRoot = this.AvatarRoot,
                WriteDefaults = this.WriteDefaults,
                OptimizeParams = this.OptimizeParams,
                FolderID = this.FolderID,
                Groups = this.Groups,
                MenuMode = this.MenuMode,
                ApplyEnabled = this.ApplyEnabled
            };
        }
    }
    [System.Serializable]
    public class RISVariables : IEditorExtVariables
    {
        [SerializeField] public VRCAvatarDescriptor AvatarRoot;
        [SerializeField] public bool WriteDefaults = false;
        [SerializeField] public bool OptimizeParams = true;
        [SerializeField] public string FolderID = "";
        [SerializeField] public List<PropGroup> Groups = new List<PropGroup>();
        [SerializeField] public RISV3.RISMode MenuMode = RISV3.RISMode.Simple;
        [SerializeField] public bool ApplyEnabled = true;
    }
}