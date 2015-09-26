using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.Xml;


namespace DataAccess
{
	/// <summary>
	/// Architecture service for serialization
	/// </summary>
	public class SerialService
	{
		private const string RETURN_NEWLINE = "\r\n";
		private const string XMLVERSION = "<?xml version=\"1.0\"?>";
		private const string XMLNAMESPACES = " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"";

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SerialService()
		{
		}

		/// <summary>
		/// Serializes an object to either an xml string or a Base64 encoded string.
		/// </summary>
		/// <param name="objX">Object to be serialized.</param>
		/// <param name="useBinary">Flag to indicate whether object should be serialized to xml or binary.
		/// If true, then will serialize to binary, else, will serialize to xml.</param>
		/// <param name="lineBreaks">Flag to add line breaks after each XML tag when not exporting in binary</param>
		/// <returns>Serialized object</returns>
		public static string Serialize(object objX, bool useBinary, bool lineBreaks)
		{
			string retVal = "";

			if (useBinary)
			{
				// First serialize the object into byte array
				byte[] btarr = SerializeToByteArray(objX);

				//Base64 encode byte array
				retVal = Convert.ToBase64String(btarr);
			}
			else
			{
				//Create xmlSerializer variable
				XmlSerializer objXMLS = new XmlSerializer(objX.GetType());

				//Create a memory stream
				MemoryStream objStream = new System.IO.MemoryStream();

				objXMLS.Serialize(objStream, objX); 	

				//Return out stream contents
				retVal = GetStringFromStream(objStream, lineBreaks);
			}

			return retVal;
		}

		/// <summary>
		/// Serializes an object to either an xml string or a Base64 encoded string.
		/// </summary>
		/// <param name="objX">Object to be serialized.</param>
		/// <param name="useBinary">Flag to indicate whether object should be serialized to xml or binary.
		/// If true, then will serialize to binary, else, will serialize to xml.</param>
		/// <returns>Serialized object</returns>
		public static string Serialize(object objX, bool useBinary)
		{
			return Serialize(objX, useBinary, false);
		}

		/// <summary>
		/// Binary Serializes an object to a byte array
		/// </summary>
		/// <param name="objX">Object to be serialized.</param>
		/// <returns>Byte Array</returns>
		public static byte[] SerializeToByteArray(object objX)
		{
			// First serialize the object into a memory stream
			MemoryStream objStream = new MemoryStream();
			BinaryFormatter objBinaryFormat = new BinaryFormatter();
			objBinaryFormat.Serialize(objStream, objX);
			objBinaryFormat = null;
		
			// Convert the stream into a string
			objStream.Position = 0;
			return objStream.ToArray();
		}

		/// <summary>
		/// Deserializes a Stream object.
		/// </summary>
		/// <param name="objectType">Object type</param>
		/// <param name="objStream">Stream to be deserialized.</param>
		/// <returns>Deserialized object.</returns>
		public static object Deserialize(Type objectType, Stream objStream)
		{
			//Create xmlSerializer variable
			XmlSerializer objXMLS = new XmlSerializer(objectType);

			objStream.Position  = 0;
			return objXMLS.Deserialize (objStream);
		}


		/// <summary>
		/// Deserializes either an xml serialized or binary serialized object.
		/// </summary>
		/// <param name="objectType">Object type</param>
		/// <param name="strObject">Either an xml serialized or binary serialized object.</param>
		/// <param name="binaryString">Flag to determine form of deserialization. 
		/// If strObject is a binary string, then this value should be true. 
		/// If strObject is an xml string, then this value should be false.</param>
		/// <returns>Deserialized object</returns>
		public static object Deserialize(Type objectType, string strObject, bool binaryString)
		{
			if (binaryString)
			{
				// convert the string into a stream
				Byte[] btarr = Convert.FromBase64String(strObject);
				MemoryStream memoryStream = new MemoryStream(btarr);

				// deserialize the stream into an object graph
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				object objX = binaryFormatter.Deserialize(memoryStream);
				return objX;

			}
			else
			{
				//Create xmlSerializer variable
				XmlSerializer objXMLS = new XmlSerializer(objectType);

				//Create String Reader
				StringReader stringReader = new StringReader(strObject);

				//Deserialize object
				object objX = objXMLS.Deserialize(stringReader);

				return objX;
			}
		}

		private static string GetStringFromStream(MemoryStream strm1, bool lineBreaks)
		{
			strm1.Position = 0;
			byte[] btarr = strm1.ToArray();
			Encoding encoder = Encoding.UTF8;
			String retVal = encoder.GetString(btarr); 
			
			//Removed 5/13/2004
			//HACK: Need to determine cause for namespaces and spaces inthe xml for no apparent reason
			//Replace carriage returns, newline, xml version and namespaces
			//string str = retVal.Replace(RETURN_NEWLINE, "");
			//string str1 = str.Replace(XMLVERSION, "");
			//string str2 = str1.Replace(XMLNAMESPACES, "");
			//string str3 = str2.Replace(">   ", ">");
			//string str4 = str3.Replace(">  ", ">");
			//string str5 = str4.Replace("> ", ">");

			retVal = lineBreaks ? retVal.Replace(">", ">\n") : retVal;

			return retVal;
		}

		private static string GetStringFromStream(MemoryStream strm1)
		{
			return GetStringFromStream(strm1, false);
		}

	}
}