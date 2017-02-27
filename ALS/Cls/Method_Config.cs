using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;

namespace ALS.Cls
{
    public class Method_Config : ConfigurationSection
    {
        public Method_Config()
        {
        }

        private static readonly ConfigurationProperty s_property
        = new ConfigurationProperty(string.Empty, typeof(MyKeyValueCollection), null,
                                        ConfigurationPropertyOptions.IsDefaultCollection);
        public Method_Config(String _name,string _id)
        {
            Name = _name;
            ID = _id;
        }

        [ConfigurationProperty("name", DefaultValue = "Clowns", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public String Name
        {
            get
            { return (String)this["name"]; }
            set
            { this["name"] = value; }
        }

        [ConfigurationProperty("ID", DefaultValue = "0", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public String ID
        {
            get
            { return (String)this["ID"]; }
            set
            { this["ID"] = value; }
        }

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public MyKeyValueCollection KeyValues
        {
            get
            {
                return (MyKeyValueCollection)base[s_property];
            }
        }

    }

    [ConfigurationCollection(typeof(MyKeyValueSetting))] 
    public class MyKeyValueCollection : ConfigurationElementCollection        
    {
        // 基本上，所有的方法都只要简单地调用基类的实现就可以了。
        public MyKeyValueCollection()
            : base(StringComparer.OrdinalIgnoreCase)    // 忽略大小写
        {
        }

        // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
        new public MyKeyValueSetting this[string name]
        {
            get
            {
                return (MyKeyValueSetting)base.BaseGet(name);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyKeyValueSetting("key","value");
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MyKeyValueSetting)element).Key;
        }

          // 说明：如果不需要在代码中修改集合，可以不实现Add, Clear, Remove
        public void Add(MyKeyValueSetting setting)
        {
            this.BaseAdd(setting);
        }
        public void Clear()
        {
            base.BaseClear();
        }
        public void Remove(string name)
        {
            base.BaseRemove(name);
        }


    }

    public class MyKeyValueSetting : ConfigurationElement    // 集合中的每个元素
    {
        public MyKeyValueSetting(string _key, string _value)
        {
            Key = _key;
            Value = _value;
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return this["key"].ToString(); }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true,DefaultValue="0")]
        public string Value
        {
            get { return this["value"].ToString(); }
            set { this["value"] = value; }
        }
    }

}
