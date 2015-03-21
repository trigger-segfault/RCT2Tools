using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.FileIO {
/** <summary> A class for storing a key and value of a property. </summary> */
public class Property {
	
	//============ STATIC ============
	#region Static
	
	public delegate object GetTypeFunction(string s, object defaultValue);
	public delegate string SetTypeFunction(object t, string format);

	private static Dictionary<Type, GetTypeFunction> getFunctions = new Dictionary<Type, GetTypeFunction>();
	private static Dictionary<Type, SetTypeFunction> setFunctions = new Dictionary<Type, SetTypeFunction>();

	public static void AddTypeGetter(Type type, GetTypeFunction getFunction) {
		getFunctions.Add(type, getFunction);
	}
	public static void AddTypeSetter(Type type, SetTypeFunction setFunction) {
		setFunctions.Add(type, setFunction);
	}

	#endregion
	//=========== MEMBERS ============
	#region Members
	//--------------------------------
	#region Format

	/** <summary> True if the property uses quotes to format its value. </summary> */
	private bool useQuotes;

	#endregion
	//--------------------------------
	#region Properties

	/** <summary> The name of the property. </summary> */
	private string key;
	/** <summary> The comments for the property. </summary> */
	private string comments;
	/** <summary> The value of the property. </summary> */
	private string value;
	
	#endregion
	//--------------------------------
	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default property. </summary> */
	public Property() {
		// Format
		this.useQuotes	= false;

		// Properties
		this.key		= "";
		this.value		= "";
		this.comments	= "";
	}
	/** <summary> Constructs a property with the specified key and value. </summary> */
	public Property(string key, string value = "", string comments = "", bool useQuotes = false) {
		// Format
		this.useQuotes	= useQuotes;

		// Properties
		this.key		= key;
		this.value		= value;
		this.comments	= comments;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Format

	/** <summary> Gets or sets if the property uses quotes to format its value. </summary> */
	public bool UseQuotes {
		get { return useQuotes; }
		set { useQuotes = value; }
	}

	#endregion
	//--------------------------------
	#region Properties

	/** <summary> Gets the name of the property. </summary> */
	public string Key {
		get { return key; }
	}
	/** <summary> Gets or sets the comments for the property. </summary> */
	public string Comments {
		get { return comments; }
		set { comments = value; }
	}
	/** <summary> Gets or sets the value of the property. </summary> */
	public string Value {
		get { return this.value; }
		set { this.value = value; }
	}

	#endregion
	//--------------------------------
	#endregion
	//============ TYPES =============
	#region Types
	
	/** <summary> Gets the value as an bool. </summary> */
	public bool GetBool(bool defaultValue = false) {
		bool result = false;
		return (Boolean.TryParse(value, out result) ? result : defaultValue);
	}
	/** <summary> Gets the value as an int. </summary> */
	public int GetInt(int defaultValue = 0) {
		int result = 0;
		return (Int32.TryParse(value, out result) ? result : defaultValue);
	}
	/** <summary> Gets the value as a double. </summary> */
	public double GetDouble(double defaultValue = 0.0) {
		double result = 0.0;
		return (Double.TryParse(value, out result) ? result : defaultValue);
	}
	/** <summary> Gets the value as the specified type. </summary> */
	public T GetAsType<T>(T defaultValue) {
		if (getFunctions.ContainsKey(typeof(T)))
			return (T)getFunctions[typeof(T)](value, defaultValue);
		return defaultValue;
	}

	#endregion
}
}
