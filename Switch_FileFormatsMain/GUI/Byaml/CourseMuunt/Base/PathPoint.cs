﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenTK;
using GL_EditorFramework.EditorDrawables;

namespace FirstPlugin.Turbo.CourseMuuntStructs
{
    public class PathPoint : IObject
    {
        public Action OnPathMoved;

        [Browsable(false)]
        public virtual RenderablePathPoint RenderablePoint
        {
            get
            {
                var point = new RenderablePathPoint(new Vector4(0f, 0.25f, 1f, 1f), Translate, Rotate, Scale, this);
                return point;
            }
        }

        public const string N_Translate = "Translate";
        public const string N_Rotate = "Rotate";
        public const string N_Scale = "Scale";
        public const string N_Id = "UnitIdNum";
        public const string N_ObjectID = "ObjId";

        [Browsable(false)]
        public Dictionary<string, dynamic> Prop { get; set; } = new Dictionary<string, dynamic>();

        public dynamic this[string name]
        {
            get
            {
                if (Prop.ContainsKey(name)) return Prop[name];
                else return null;
            }
            set
            {
                if (Prop.ContainsKey(name)) Prop[name] = value;
                else Prop.Add(name, value);
            }
        }

        public List<object> Properties = new List<object>();

        public List<PointID> NextPoints = new List<PointID>();
        public List<PointID> PrevPoints = new List<PointID>();

        public List<ControlPoint> ControlPoints = new List<ControlPoint>();

        [Category("Transform")]
        public Vector3 Rotate
        {
            get {
                if (this[N_Rotate] == null)
                    return new Vector3(0, 0, 0);

                return new Vector3(
               this[N_Rotate]["X"] != null ? this[N_Rotate]["X"] : 0,
               this[N_Rotate]["Y"] != null ? this[N_Rotate]["Y"] : 0,
               this[N_Rotate]["Z"] != null ? this[N_Rotate]["Z"] : 0);
            }
            set
            {
                this[N_Rotate]["X"] = value.X;
                this[N_Rotate]["Y"] = value.Y;
                this[N_Rotate]["Z"] = value.Z;
            }
        }

        [Category("Transform")]
        public Vector3 Scale
        {
            get
            {
                if (this[N_Scale] == null)
                    return new Vector3(1, 1, 1);

                return new Vector3(
               this[N_Scale]["X"] != null ? this[N_Scale]["X"] : 1,
               this[N_Scale]["Y"] != null ? this[N_Scale]["Y"] : 1,
               this[N_Scale]["Z"] != null ? this[N_Scale]["Z"] : 1);
            }
            set
            {
                if (this[N_Scale] != null)
                {
                    this[N_Scale]["X"] = value.X;
                    this[N_Scale]["Y"] = value.Y;
                    this[N_Scale]["Z"] = value.Z;
                }
            }
        }

        [Category("Transform")]
        public Vector3 Translate
        {
            get
            {
                if (this[N_Translate] == null)
                    return new Vector3(0, 0, 0);

                return new Vector3(
                 this[N_Translate]["X"] != null ? this[N_Translate]["X"] : 0,
                 this[N_Translate]["Y"] != null ? this[N_Translate]["Y"] : 0,
                 this[N_Translate]["Z"] != null ? this[N_Translate]["Z"] : 0);
            }
            set
            {
                this[N_Translate]["X"] = value.X;
                this[N_Translate]["Y"] = value.Y;
                this[N_Translate]["Z"] = value.Z;
            }
        }
    }

}
