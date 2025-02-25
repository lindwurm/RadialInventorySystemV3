﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace YagihataItems.RadialInventorySystemV3
{
    [Serializable]
    public class PropGroup : ScriptableObject, ICloneable
    {
        [SerializeField]
        public List<Prop> Props = new List<Prop>();
        [SerializeField]
        public string GroupName = "";
        [SerializeField]
        public Texture2D GroupIcon = null;
        [SerializeField]
        public int ExclusiveMode = 0;
        [SerializeField]
        public VRCExpressionsMenu BaseMenu = null;
        public PropGroup()
        {
            Props = new List<Prop>();
            GroupName = "";
            GroupIcon = null;
            ExclusiveMode = 0;
        }
        public object Clone()
        {
            var obj = new PropGroup();
            obj.GroupName = this.GroupName;
            obj.GroupIcon = this.GroupIcon;
            obj.ExclusiveMode = this.ExclusiveMode;
            obj.Props.AddRange(this.Props.Select(n => (Prop)n.Clone()));
            obj.BaseMenu = this.BaseMenu;
            return obj;
        }

        public override bool Equals(object obj)
        {
            return obj is PropGroup group &&
                   base.Equals(obj) &&
                   name == group.name &&
                   hideFlags == group.hideFlags &&
                   EqualityComparer<List<Prop>>.Default.Equals(Props, group.Props) &&
                   GroupName == group.GroupName &&
                   EqualityComparer<Texture2D>.Default.Equals(GroupIcon, group.GroupIcon) &&
                   ExclusiveMode == group.ExclusiveMode &&
                   EqualityComparer<VRCExpressionsMenu>.Default.Equals(BaseMenu, group.BaseMenu);
        }

        public override int GetHashCode()
        {
            int hashCode = 963063520;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + hideFlags.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Prop>>.Default.GetHashCode(Props);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Texture2D>.Default.GetHashCode(GroupIcon);
            hashCode = hashCode * -1521134295 + ExclusiveMode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<VRCExpressionsMenu>.Default.GetHashCode(BaseMenu);
            return hashCode;
        }
    }
}
