using System;
using System.Collections.Generic;
using System.Text;

namespace Imbick.StarCitizen.Keybind.Serialiser.Model
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ActionMaps
    {

        private ActionMapsCustomisationUIHeader customisationUIHeaderField;

        private List<ActionMapsOptions> optionsField;

        private ActionMapsModifiers modifiersField;

        private List<ActionMapsActionmap> actionmapField;

        private byte versionField;

        private byte optionsVersionField;

        private byte rebindVersionField;

        private string profileNameField;

        /// <remarks/>
        public ActionMapsCustomisationUIHeader CustomisationUIHeader
        {
            get
            {
                return this.customisationUIHeaderField;
            }
            set
            {
                this.customisationUIHeaderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("options")]
        public List<ActionMapsOptions> options
        {
            get
            {
                return this.optionsField;
            }
            set
            {
                this.optionsField = value;
            }
        }

        /// <remarks/>
        public ActionMapsModifiers modifiers
        {
            get
            {
                return this.modifiersField;
            }
            set
            {
                this.modifiersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("actionmap")]
        public List<ActionMapsActionmap> actionmap
        {
            get
            {
                return this.actionmapField;
            }
            set
            {
                this.actionmapField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte optionsVersion
        {
            get
            {
                return this.optionsVersionField;
            }
            set
            {
                this.optionsVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte rebindVersion
        {
            get
            {
                return this.rebindVersionField;
            }
            set
            {
                this.rebindVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string profileName
        {
            get
            {
                return this.profileNameField;
            }
            set
            {
                this.profileNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsCustomisationUIHeader
    {

        private ActionMapsCustomisationUIHeaderDevices devicesField;

        private List<ActionMapsCustomisationUIHeaderCategory> categoriesField;

        private string labelField;

        private string descriptionField;

        private string imageField;

        /// <remarks/>
        public ActionMapsCustomisationUIHeaderDevices devices
        {
            get
            {
                return this.devicesField;
            }
            set
            {
                this.devicesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("category", IsNullable = false)]
        public List<ActionMapsCustomisationUIHeaderCategory> categories
        {
            get
            {
                return this.categoriesField;
            }
            set
            {
                this.categoriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string image
        {
            get
            {
                return this.imageField;
            }
            set
            {
                this.imageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsCustomisationUIHeaderDevices
    {

        private ActionMapsCustomisationUIHeaderDevicesKeyboard keyboardField;

        private ActionMapsCustomisationUIHeaderDevicesMouse mouseField;

        private List<ActionMapsCustomisationUIHeaderDevicesJoystick> joystickField;

        /// <remarks/>
        public ActionMapsCustomisationUIHeaderDevicesKeyboard keyboard
        {
            get
            {
                return this.keyboardField;
            }
            set
            {
                this.keyboardField = value;
            }
        }

        /// <remarks/>
        public ActionMapsCustomisationUIHeaderDevicesMouse mouse
        {
            get
            {
                return this.mouseField;
            }
            set
            {
                this.mouseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("joystick")]
        public List<ActionMapsCustomisationUIHeaderDevicesJoystick> joystick
        {
            get
            {
                return this.joystickField;
            }
            set
            {
                this.joystickField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsCustomisationUIHeaderDevicesKeyboard
    {

        private byte instanceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte instance
        {
            get
            {
                return this.instanceField;
            }
            set
            {
                this.instanceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsCustomisationUIHeaderDevicesMouse
    {

        private byte instanceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte instance
        {
            get
            {
                return this.instanceField;
            }
            set
            {
                this.instanceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsCustomisationUIHeaderDevicesJoystick
    {

        private byte instanceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte instance
        {
            get
            {
                return this.instanceField;
            }
            set
            {
                this.instanceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsCustomisationUIHeaderCategory
    {

        private string labelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsOptions
    {

        private string typeField;

        private byte instanceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte instance
        {
            get
            {
                return this.instanceField;
            }
            set
            {
                this.instanceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsModifiers
    {

        private ActionMapsModifiersAdd addField;

        /// <remarks/>
        public ActionMapsModifiersAdd add
        {
            get
            {
                return this.addField;
            }
            set
            {
                this.addField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsModifiersAdd
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsActionmap
    {

        private List<ActionMapsActionmapAction> actionField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("action")]
        public List<ActionMapsActionmapAction> action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsActionmapAction
    {

        private ActionMapsActionmapActionRebind rebindField;

        private string nameField;

        /// <remarks/>
        public ActionMapsActionmapActionRebind rebind
        {
            get
            {
                return this.rebindField;
            }
            set
            {
                this.rebindField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActionMapsActionmapActionRebind
    {

        private string inputField;

        private string activationModeField;

        private byte multiTapField;

        private bool multiTapFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string activationMode
        {
            get
            {
                return this.activationModeField;
            }
            set
            {
                this.activationModeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte multiTap
        {
            get
            {
                return this.multiTapField;
            }
            set
            {
                this.multiTapField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool multiTapSpecified
        {
            get
            {
                return this.multiTapFieldSpecified;
            }
            set
            {
                this.multiTapFieldSpecified = value;
            }
        }
    }



}
