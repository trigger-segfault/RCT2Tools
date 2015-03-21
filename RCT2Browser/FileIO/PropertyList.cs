using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RCTDataEditor.FileIO {
/** <summary> A class to load, store, and save program settings and properties. </summary> */
public class PropertyList {

	//=========== MEMBERS ============
	#region Members
	//--------------------------------
	#region Format

	/** <summary> The assignment type used for properties. </summary> */
	private string assignmentType;
	/** <summary> The comment indicator used for descriptions. </summary> */
	private string commentType;
	/** <summary> The maximum line length before the line is continued. </summary> */
	private int maxLineLength;
	/** <summary> Requires that all formatted lines use escape characters even when unnecessary. </summary> */
	private bool strictFormatting;
	/** <summary> True if the property list keeps the comments when loading. </summary> */
	private bool keepComments;
	/** <summary> True if duplicate sections are allowed. </summary> */
	private bool allowDuplicateSections;
	
	#endregion
	//--------------------------------
	#region Properties

	/** <summary> The global property section. </summary> */
	private PropertySection global;
	/** <summary> The list of sections for property list. </summary> */
	private List<PropertySection> sections;
	
	#endregion
	//--------------------------------
	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default property list. </summary> */
	public PropertyList() {
		// Format
		this.assignmentType			= "=";
		this.commentType			= "; ";
		this.maxLineLength			= -1;
		this.strictFormatting		= false;
		this.keepComments			= false;
		this.allowDuplicateSections	= false;

		// Properties
		this.global					= new PropertySection();
		this.sections				= new List<PropertySection>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Format

	/** <summary> Gets or sets the assignment type used for property list. </summary> */
	public string AssignmentType {
		get { return assignmentType; }
		set { assignmentType = value; }
	}
	/** <summary> Gets or sets the comment indicator used for descriptions. </summary> */
	public string CommentType {
		get { return commentType; }
		set { commentType = value; }
	}
	/** <summary> Gets or sets the maximum line length before the line is continued. </summary> */
	public int MaxLineLength {
		get { return maxLineLength; }
		set { maxLineLength = value; }
	}
	/** <summary> Gets or sets if all formatted lines require escape characters even when unnecessary. </summary> */
	public bool StrictFormatting {
		get { return strictFormatting; }
		set { strictFormatting = value; }
	}
	/** <summary> Gets or sets if the property list keeps the comments when loading. </summary> */
	public bool KeepComments {
		get { return keepComments; }
		set { keepComments = value; }
	}
	/** <summary> Gets or sets if duplicate sections are allowed. </summary> */
	public bool AllowDuplicateSections {
		get { return allowDuplicateSections; }
		set { allowDuplicateSections = value; }
	}

	#endregion
	//--------------------------------
	#region Properties

	/** <summary> Gets the list of sections in the property list. </summary> */
	public ReadOnlyCollection<PropertySection> Sections {
		get { return sections.AsReadOnly(); }
	}
	/** <summary> Gets the global section. </summary> */
	public PropertySection Global {
		get { return global; }
	}
	/** <summary> Gets the section with the specified key. </summary> */
	public PropertySection this[string key, int index = 0] {
		get { return Get(key, index); }
	}
	/** <summary> Gets the number of sections in the property list. This excludes the global section. </summary> */
	public int Count {
		get { return sections.Count; }
	}

	#endregion
	//--------------------------------
	#endregion
	//========== MANAGEMENT ==========
	#region Mangement
	//--------------------------------
	#region Setters

	/** <summary> Adds the specified section to the property list. </summary> */
	public PropertySection Add(PropertySection section) {
		if (!Contains(section)) {
			sections.Add(section);
			return section;
		}
		return null;
	}
	/** <summary> Adds a new section with the specified key to the property list. </summary> */
	public PropertySection Add(string key, string comments = "") {
		if (allowDuplicateSections || !Contains(key)) {
			PropertySection section = new PropertySection(key, comments);
			sections.Add(section);
			return section;
		}
		return null;
	}
	/** <summary> Removes the specified section from the property list. </summary> */
	public void Remove(PropertySection section) {
		sections.Remove(section);
	}
	/** <summary> Removes the section with the specified key from the property list. </summary> */
	public void Remove(string key, int index = 0) {
		for (int i = 0; i < sections.Count && index >= 0; i++) {
			if (key.ToLower() == sections[i].Key.ToLower()) {
				if (index == 0) {
					sections.RemoveAt(i);
					break;
				}
				index--;
			}
		}
	}
	/** <summary> Removes all sections from the property list. </summary> */
	public void Clear() {
		sections.Clear();
	}

	#endregion
	//--------------------------------
	#region Getters

	/** <summary> Gets the section with the specified key. </summary> */
	public PropertySection Get(string key, int index = 0) {
		for (int i = 0; i < sections.Count && index >= 0; i++) {
			if (key.ToLower() == sections[i].Key.ToLower()) {
				if (index == 0)
					return sections[i];
				index--;
			}
		}
		return new PropertySection();
	}
	/** <summary> Returns true if the specified section exists in the property list. </summary> */
	public bool Contains(PropertySection section) {
		for (int i = 0; i < sections.Count; i++) {
			if (section == sections[i])
				return true;
		}
		return false;
	}
	/** <summary> Returns true if a section with the specified key exists in the property list. </summary> */
	public bool Contains(string key, int index = 0) {
		for (int i = 0; i < sections.Count && index >= 0; i++) {
			if (key.ToLower() == sections[i].Key.ToLower()) {
				if (index == 0)
					return true;
				index--;
			}
		}
		return false;
	}

	#endregion
	//--------------------------------
	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Parses the property list from the specified text. </summary> */
	public void ParseProperties(string text) {
		// The lines of the text
		List<string> lines = new List<string>();
		// The current section being edited. (Set to global section by default)
		PropertySection section = null;
		// The current description for the next section or property
		string comment = "";

		sections.Clear();
		global = new PropertySection();
		section = global;

		// Formating Order:
		// Replace '\r' with '\n'
		// Remove all empty lines
		// Remove '\n' if line ends with '\'
		// Split up lines
		// Remove lines beginning with ';', '#', or '!'
		// Split lines at "=", " = ", ":", or " : " and not "\\=" or "\\:"
		// Remove quotes around values
		// Implement all escape characters:
		// '\\', '\0', '\a', '\b', '\t', '\r', '\n', '\;', '\#', '\!', '\=', '\:', '\"', '\ ', '\x####'

		// Replace all carriage returns with new lines
		if (!keepComments)
			text = text.Replace("\r", "\n");
		else
			text = text.Replace("\r\n", "\n");
		
		// Remove all empty lines
		if (!keepComments)
			text = Regex.Replace(text, @"\n+", "\n");
		
		// Remove all commented lines
		if (!keepComments)
			text = Regex.Replace(Regex.Replace(text, @"\n[\;|\#|\!].*", ""), @"^[\;|\#|\!].*\n", "");

		// Remove new line if line ends with '\'
		if (!keepComments) {
			text = text.Replace("\\\n", "");
		}
		else {
			lines.AddRange(text.Split('\n'));
			for (int i = 0; i < lines.Count; i++) {
				if (lines[i].Length > 0) {
					// Check if line isn't a comment and ends with '\'
					if (RegexMatchIndex(lines[i], @"^[^\;\#\!].*\\", 0)) {
						lines[i] = lines[i].Substring(0, lines[i].Length - 1);
						// Combine the two lines into one
						if (i + 1 < lines.Count) {
							lines[i] += lines[i + 1];
							lines.RemoveAt(i + 1);
						}
					}
				}
			}
			text = String.Join("\n", lines);
			lines.Clear();
		}
		
		// Split up the lines
		lines.AddRange(text.Split(new string[] { "\n" }, StringSplitOptions.None));
		
		// Iterate through all the lines
		for (int i = 0; i < lines.Count; i++) {
			string line = lines[i];
			if (line.Length == 0) { // Empty line comment
				// If the comment is a blank line
				comment += "\n";
			}
			else if (RegexMatchIndex(line, @"^[\;|\#|\!].*", 0)) { // Comment
				// If the comment is spaced or not spaced
				if (RegexMatchIndex(line, @"^[\;|\#|\!] .*", 0))
					comment += line.Substring(2, line.Length - 2) + "\n";
				else
					comment += line.Substring(1, line.Length - 1) + "\n";
			}
			else if (RegexMatchIndex(line, @"^\[.*\]$", 0)) { // Section
				string sectionKey = ParseSection(line);
				PropertySection newSection = Add(sectionKey, comment);
				if (newSection != null)
					section = newSection;
				comment = "";
			}
			else { // Propery
				// Split the line into [key, value]
				string[] parts = ParseProperty(line).Split('\n');
				if (parts.Length == 2) {
					string key		= ParseKey(parts[0]);
					string value	= ParseValue(parts[1]);
					/*if (allowDuplicateProperties) {
						section.AddNewProperty(key, value, comment);
						// Set property of correct index
					}
					else {*/
						section.Add(key, value, comment);
						comment = "";
					//}
				}
				else {
					// Not a valid line
				}
			}
		}
	}
	/** <summary> Checks if the specified regex matches the beginning of the line. </summary> */
	private static bool RegexMatchIndex(string input, string pattern, int index = 0) {
		Match match = Regex.Match(input, pattern);
		return (match.Success && match.Index == 0);
	}
	/** <summary> Unescapes characters. </summary> */
	private static string Unescape(string text) {
		text = text.Replace("\\\\", "\\");
		text = text.Replace("\\0", "\x00");
		text = text.Replace("\\a", "\x07");
		text = text.Replace("\\b", "\b");
		text = text.Replace("\\t", "\t");
		text = text.Replace("\\r", "\r");
		text = text.Replace("\\n", "\n");
		text = text.Replace("\\\"", "\"");
		text = text.Replace("\\;", ";");
		text = text.Replace("\\#", "#");
		text = text.Replace("\\!", "!");
		text = text.Replace("\\=", "=");
		text = text.Replace("\\:", ":");
		text = text.Replace("\\ ", " ");
		text = text.Replace("\\ ", " ");
		return text;
	}
	/** <summary> Parses the specified section. </summary> */
	private static string ParseSection(string section) {
		section = section.Substring(1, section.Length - 2);
		return Unescape(section);
	}
	/** <summary> Parses the specified property. </summary> */
	private static string ParseProperty(string property) {
		// Separate the key and value by splitting it with '\n'
		// Replace ' ', '=', and ':' with non-matchable characters
		property = property.Replace("\\ ", "\\s").Replace("\\=", "\\e").Replace("\\:", "\\c");
		Regex regex = new Regex(@" \= | \: |\=|\:");
		property = regex.Replace(property, "\n", 1);
		property = property.Replace("\\s", "\\ ").Replace("\\e", "\\=").Replace("\\c", "\\:");
		return property;
	}
	/** <summary> Parses the specified key. </summary> */
	private static string ParseKey(string key) {
		return Unescape(key);
	}
	/** <summary> Parses the specified value. </summary> */
	private static string ParseValue(string value) {
		// Remove quotes if the value was quoted
		if (RegexMatchIndex(value, @"^\"".*\""$", 0))
			value = value.Substring(1, value.Length - 2);
		return Unescape(value);
	}

	#endregion
	//=========== WRITING ============
	#region Writing

	/** <summary> Writes the properties to a string. </summary> */
	public string WriteProperties() {
		string text = "";

		text += WriteSection(global, strictFormatting, assignmentType, commentType, maxLineLength);

		for (int i = 0; i < sections.Count; i++) {
			text += WriteSection(sections[i], strictFormatting, assignmentType, commentType, maxLineLength);
		}

		text = text.Replace("\n", "\r\n");
		return text;
	}
	/** <summary> Escapes characters. </summary> */
	private static string Escape(string text, bool escape, bool special, bool quotes, bool spaces) {
		text = text.Replace("\\", "\\\\");
		if (escape) {
			text = text.Replace("\x00", "\\\0");
			text = text.Replace("\x07", "\\\a");
			text = text.Replace("\b", "\\\b");
			text = text.Replace("\t", "\\\t");
			text = text.Replace("\r", "\\\r");
			text = text.Replace("\n", "\\\n");
		}
		if (quotes) {
			text = text.Replace("\"", "\\\"");
		}
		if (special) {
			text = text.Replace(";", "\\;");
			text = text.Replace("#", "\\#");
			text = text.Replace("!", "\\!");
			text = text.Replace("=", "\\=");
			text = text.Replace(":", "\\:");
		}
		if (spaces) {
			text = text.Replace(" ", "\\ ");
		}
		return text;
	}
	/** <summary> Writes the section head. </summary> */
	private static string WriteSection(PropertySection section, bool strictFormatting, string assignmentType, string commentType, int maxLineLength) {
		string text = "";
		if (section.Comments.Length > 0)
			text += WriteComments(section.Comments, commentType, maxLineLength);

		if (section.Key.Length > 0) {
			string sectionText = "";
			sectionText = Escape(section.Key, true, strictFormatting, strictFormatting, strictFormatting); ;
			sectionText = "[" + sectionText + "]";
			text += ContinueLine(sectionText, maxLineLength) + "\n";
		}

		for (int i = 0; i < section.Count; i++) {
			text += WriteProperty(section.Properties[i], strictFormatting, assignmentType, commentType, maxLineLength);
		}
		return text;
	}
	/** <summary> Writes a section property. </summary> */
	private static string WriteProperty(Property property, bool strictFormatting, string assignmentType, string commentType, int maxLineLength) {
		string text = "";
		if (property.Comments.Length > 0)
			text += WriteComments(property.Comments, commentType, maxLineLength);

		string propertyText = "";
		propertyText += Escape(property.Key, true, true, strictFormatting, true);
		propertyText += assignmentType;

		string valueText = Escape(property.Value, true, strictFormatting, true, strictFormatting);
		if (property.UseQuotes)
			valueText = "\"" + valueText + "\"";
		propertyText += valueText;

		text += ContinueLine(propertyText, maxLineLength) + "\n";

		return text;
	}
	/** <summary> Writes comments. </summary> */
	private static string WriteComments(string comments, string commentType, int maxLineLength) {
		string[] lines = comments.Split('\n');
		for (int i = 0; i < lines.Length; i++) {
			// Don't comment empty lines
			if (lines[i].Length > 0)
				lines[i] = commentType + lines[i];
		}
		return String.Join("\n", lines);// +"\n";
	}
	/** <summary>Continues lines of a certain length. </summary> */
	private static string ContinueLine(string text, int maxLineLength) {
		if (maxLineLength == -1 || text.Length <= maxLineLength)
			return text;

		string[] lines = new string[text.Length / maxLineLength];

		for (int i = 0; i < lines.Length && text.Length > maxLineLength; i++) {
			lines[i] = text.Substring(0, maxLineLength);
			text = text.Substring(maxLineLength);
		}
		return String.Join("\\\n", lines) + (text.Length > 0 ? "\\\n" + text : "");
	}

	#endregion
}
}
