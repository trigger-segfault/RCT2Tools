using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.FileIO {
/** <summary> A class for storing a group of properties. </summary> */
public class PropertySection {

	//=========== MEMBERS ============
	#region Members
	//--------------------------------
	#region Properties

	/** <summary> The name of the section. </summary> */
	private string key;
	/** <summary> The description for the section. </summary> */
	private string comments;
	/** <summary> The list of properties in the section. </summary> */
	private List<Property> properties;
	
	#endregion
	//--------------------------------
	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default property section. </summary> */
	public PropertySection() {
		// Properties
		this.key		= "";
		this.comments	= "";
		this.properties	= new List<Property>();
	}
	/** <summary> Constructs a property section with the specified key. </summary> */
	public PropertySection(string key, string comments = "") {
		// Properties
		this.key		= key;
		this.comments	= comments;
		this.properties	= new List<Property>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Properties

	/** <summary> Gets the name of the section. </summary> */
	public string Key {
		get { return key; }
	}
	/** <summary> Gets or sets the description for the section. </summary> */
	public string Comments {
		get { return comments; }
		set { comments = value; }
	}
	/** <summary> Gets the list of properties in the section. </summary> */
	public ReadOnlyCollection<Property> Properties {
		get { return properties.AsReadOnly(); }
	}
	/** <summary> Gets the property with the specified key. </summary> */
	public Property this[string key, string defaultValue = ""] {
		get { return Get(key, defaultValue); }
	}
	/** <summary> Gets the number of properties in the section. </summary> */
	public int Count {
		get { return properties.Count; }
	}

	#endregion
	//--------------------------------
	#endregion
	//========== MANAGEMENT ==========
	#region Mangement
	//--------------------------------
	#region Setters

	/** <summary> Adds the specified property to the section. </summary> */
	public Property Add(Property property) {
		if (!Contains(property)) {
			properties.Add(property);
			return property;
		}
		return null;
	}
	/** <summary> Adds a property with the specified key and value to the section. </summary> */
	public Property Add(string key, string value = "", string comments = "", bool useQuotes = false) {
		if (!Contains(key)) {
			Property property = new Property(key, value, comments, useQuotes);
			properties.Add(property);
			return property;
		}
		return null;
	}
	/** <summary> Removes the specified property from the section. </summary> */
	public void Remove(Property property) {
		properties.Remove(property);
	}
	/** <summary> Removes the property with the specified key from the section. </summary> */
	public void Remove(string key) {
		for (int i = 0; i < properties.Count; i++) {
			if (key.ToLower() == properties[i].Key.ToLower()) {
				properties.RemoveAt(i);
				break;
			}
		}
	}
	/** <summary> Removes all properties from the section. </summary> */
	public void Clear() {
		properties.Clear();
	}

	#endregion
	//--------------------------------
	#region Getters

	/** <summary> Gets the property with the specified key in the section. </summary> */
	public Property Get(string key, string defaultValue = "") {
		for (int i = 0; i < properties.Count; i++) {
			if (key.ToLower() == properties[i].Key.ToLower())
				return properties[i];
		}
		return new Property(key, defaultValue);
	}
	/** <summary> Returns true if the specified property exists in the section. </summary> */
	public bool Contains(Property property) {
		return properties.Contains(property);
	}
	/** <summary> Returns true if a property with the specified key exists in the section. </summary> */
	public bool Contains(string key) {
		for (int i = 0; i < properties.Count; i++) {
			if (key.ToLower() == properties[i].Key.ToLower())
				return true;
		}
		return false;
	}

	#endregion
	//--------------------------------
	#endregion
}
}
