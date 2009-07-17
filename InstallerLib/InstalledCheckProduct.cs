﻿using System;
using System.Xml;
using System.ComponentModel;

namespace InstallerLib
{
    /// <summary>
    /// Type of installed product id.
    /// </summary>
    public enum InstalledCheckProductType
    {
        productcode,
        upgradecode
    }

    /// <summary>
    /// InstalledCheck of type "check_product".
    /// </summary>
    public class InstalledCheckProduct : InstalledCheck
    {
        public InstalledCheckProduct()
            : base("check_product")
        {
            m_id_type = InstalledCheckProductType.upgradecode;
            m_id = new Guid();
            m_propertyname = "VersionString";
            m_comparison = installcheck_comparison.version;
            m_propertyvalue = "1.0.0.0";
        }

        private InstalledCheckProductType m_id_type;
        [Description("Type of id, product id or upgrade code.")]
        public InstalledCheckProductType id_type
        {
            get { return m_id_type; }
            set { m_id_type = value; }
        }

        private Guid m_id;
        [Description("Installed product's product id or upgrade code.")]
        public Guid id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_propertyname;
        [Description("The installed product's property name, for example 'VersionString'.")]
        public string propertyname
        {
            get { return m_propertyname; }
            set { m_propertyname = value; }
        }

        private string m_propertyvalue;
        [Description("The installed product's property value used to check if the component is installed.")]
        public string propertyvalue
        {
            get { return m_propertyvalue; }
            set { m_propertyvalue = value; }
        }

        private installcheck_comparison m_comparison;
        [Description("Comparison mode.")]
        public installcheck_comparison comparison
        {
            get { return m_comparison; }
            set { m_comparison = value; }
        }

        protected override void OnXmlWriteTag(XmlWriterEventArgs e)
        {
            e.XmlWriter.WriteAttributeString("id", m_id.ToString());
            e.XmlWriter.WriteAttributeString("id_type", m_id_type.ToString());
            e.XmlWriter.WriteAttributeString("propertyname", m_propertyname);
            e.XmlWriter.WriteAttributeString("propertyvalue", m_propertyvalue);
            e.XmlWriter.WriteAttributeString("comparison", m_comparison.ToString());
            base.OnXmlWriteTag(e);
        }

        protected override void OnXmlReadTag(XmlElementEventArgs e)
        {
            ReadAttributeValue(e, "id", ref m_id);
            ReadAttributeValue(e, "id_type", ref m_id_type);
            ReadAttributeValue(e, "propertyname", ref m_propertyname);
            ReadAttributeValue(e, "propertyvalue", ref m_propertyvalue);
            ReadAttributeValue(e, "comparison", ref m_comparison);
            base.OnXmlReadTag(e);
        }
    }
}