using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrOpen.DrCommon.DrData;
using System.Text.RegularExpressions;

namespace DrOpen.DrData.DrDataSd
{
    /// <summary>
    /// Presents DDNode as DDML string    /// </summary>
    public static class DDMLPresenter
    {
        #region Tags
        private const string nodeTag = ":";
        private const string attrTag = "=";
        private const string separator = "  ";
        private const string escapeSymbol = @"\";
        private static string[] keySymbols = new string[] { escapeSymbol, nodeTag, attrTag };
        #endregion

        public static string DDnodeToDDML(DDNode n)
        {
            var result = new StringBuilder();

            if (n.Level > 1) result.Append(new StringBuilder().Insert(0, separator, (int)n.Level - 1).ToString());//node formatting

            result.AppendLine(ProcessNodeNameAndType(n));

            if (n.HasAttributes)
            {
                result.Append(ProcessAttributes(n.Attributes, new StringBuilder().Insert(0, separator, (int)n.Level).ToString()));
            }

            if (n.HasChildNodes)
            {
                foreach (var child in n.Values)
                {
                    if (child.Type.Name.Contains("Schema")) //  Skips node if node type is Schema
                    {
                        child.Skip(1);
                    }
                    else
                    {
                        result.Append(DDnodeToDDML(child));
                    }
                }
            }

            return result.ToString();
        }

        private static string ProcessAttributes(DDAttributesCollection ac, string level)
        {
            var result = new StringBuilder();

            foreach (var attr in ac)
            {
                result.Append(level);
                if (attr.Value.Type.IsArray)
                {
                    string[] convertedAttributes = AttributeConverter(attr.Value.Type, attr.Key.ToString(), attr.Value);
                    string[] resultStringArray = InsertEscapeSymbol(attr.Key);
                    string resultString = String.Join(", ", convertedAttributes);

                    if (convertedAttributes.Length == 1)
                    {
                        result.AppendLine(String.Concat(resultStringArray[0], attrTag, resultString, ", "));
                    }
                    else
                    {
                        result.AppendLine(String.Concat(resultStringArray[0], attrTag, resultString));
                    }
                }
                else
                {
                    var convertedAttributes = AttributeConverter(attr.Value.Type, attr.Key.ToString(), attr.Value);
                    var resultStringArray = InsertEscapeSymbol(convertedAttributes);
                    var resultString = String.Concat(resultStringArray[0], attrTag, resultStringArray[1]);
                    result.AppendLine(resultString);
                }

            }

            return result.ToString();
        }

        private static string[] AttributeConverter(Type type, string name, DDValue value)
        {
            if ((type.IsPrimitive & (type != typeof(System.Char))) || type == typeof(System.Guid))
            {
                return new string[] { name, value.ToString() };
            }
            else if (type == typeof(System.DateTime))
            {
                var iso8601 = value.GetValueAsDateTime();
                return new string[] { name, iso8601.ToString("o") };
            }
            else if (type == typeof(System.String))
            {
                if (value.Size == 0) { var test = value.ToString(); };
                
                return new string[] { name, String.Concat("\"", value.ToString(), "\"") };
            }
            else if (type == typeof(System.Char))
            {
                return new string[] { name, String.Concat("\'", value.ToString(), "\'") };
            }
            else if (type.IsArray)
            {
                return ArrayTypeAttribute(name, value);
            }
            else
            {
                return new string[] { };
            }
        }

        private static string[] ArrayTypeAttribute(string name, DDValue value)
        {
            var typeArray = value.Type.Name;
            string[] resultStringArray;

            if (typeArray == "Char[]")
            {
                var charArray = value.GetValueAsCharArray();
                resultStringArray = new string[charArray.Length];

                for (int i = 0; i < charArray.Length; i++)
                {
                    resultStringArray[i] = String.Concat("\'", charArray[i], "\'");
                }

            }
            else if (typeArray == "String[]")
            {
                resultStringArray = value.GetValueAsStringArray();
                for (int i = 0; i < resultStringArray.Length; i++)
                {
                    resultStringArray[i] = String.Concat("\"", resultStringArray[i], "\"");
                }
            }
            else if (typeArray == "DateTime[]")
            {
                var values = value.ToStringArray();
                resultStringArray = InsertEscapeSymbol(values);                
            }
            else
            {
                resultStringArray = value.ToStringArray();                
            }

            return resultStringArray;
        }

        private static string ProcessNodeNameAndType(DDNode n)
        {
            string type = n.Type.Name;
            string name = n.Name;

            var result = InsertEscapeSymbol(type, name);

            return String.Concat(result[0], nodeTag, result[1]);
        }

        private static string[] InsertEscapeSymbol(params string[] stringToCheck) //Inserts Escape Symbol into strings if they contain key symbols
        {
            foreach (var element in keySymbols)
            {
                for (int i = 0; i < stringToCheck.Length; i++)
                {
                    var charString = stringToCheck[i].ToCharArray();

                    int counter = 0;

                    for (int j = 0; j < charString.Length; j++)
                    {
                        if (j == 0)
                        {
                            if (charString[j] == ' ') stringToCheck[i] = stringToCheck[i].Insert(0, escapeSymbol);                            
                        }

                        if (charString[j].ToString() == element)
                        {
                            if (counter > 0)
                            {
                                stringToCheck[i] = stringToCheck[i].Insert(j + counter, escapeSymbol);
                            }
                            else
                            {
                                stringToCheck[i] = stringToCheck[i].Insert(j, escapeSymbol);
                                counter++;
                            }
                        }
                    }
                }
            }

            return stringToCheck;
        }

    }
}
