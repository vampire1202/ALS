#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Template
{
    public class CSharpContext : TemplateContext
    {
        public CSharpContext()
        {
            AddType("int", typeof(int));
            AddType("uint", typeof(uint));
            AddType("long", typeof(long));
            AddType("ulong", typeof(ulong));
            AddType("short", typeof(short));
            AddType("ushort", typeof(ushort));
            AddType("double", typeof(double));
            AddType("float", typeof(float));
            AddType("bool", typeof(bool));
            AddType("char", typeof(char));
            AddType("byte", typeof(byte));
            AddType("sbyte", typeof(sbyte));
            AddType("string", typeof(string));
            Add("null", new ValueTypePair());
            Add("true", true);
            Add("false", false);
        }

        public CSharpContext(CSharpContext parent)
            : base(parent)
        {
        }

        public override ITemplateContext CreateLocal()
        {
            return new CSharpContext(this);
        }
    }
}
