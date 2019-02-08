using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrOpen.DrCommon.DrData;

namespace DrOpen.DrData.DrDataSd
{
    /// <summary>
    /// Presents DDNode as DDML string    /// </summary>
    public static class DDMLPresenter
    {
        #region Tags
        private const string nodeTag = ": ";
        private const string attrTag = " = ";
        private const string separator = "  ";
        #endregion

        public static string DDnodeToDDML(DDNode n)
        {
            var result = new StringBuilder();

            if (n.Level > 1) result.Append(new StringBuilder().Insert(0, separator, (int)n.Level).ToString()); //node formatting 

            result.AppendLine(ProcessNodeNameAndType(n));

            if (n.HasAttributes)
            {
                result.Append(ProcessAttributes(n.Attributes, new StringBuilder().Insert(0, separator, (int)n.Level + 1).ToString()));
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
                string value = attr.Value.ToString();
                string name = attr.Key.ToString();
                Type type = attr.Value.Type;

                result.Append(level);

                if (type.IsPrimitive || type == typeof(System.Guid) || type == typeof(System.DateTime))
                {
                    result.AppendLine(PrimitiveTypeAttribute(name, value));
                }

                if (type == typeof(System.String))
                {
                    result.AppendLine(StringTypeAttribute(name, value));
                }

                if (type.IsArray)
                {
                    result.AppendLine(ArrayTypeAttribute(name, attr.Value));
                }
            }

            return result.ToString();
        }

        private static string ProcessNodeNameAndType(DDNode n)
        {
            string type = n.Type.Name;
            string name = n.Name;
            return String.Concat(type, nodeTag, name);
        }

        private static string PrimitiveTypeAttribute(string name, string value)
        {
            return String.Concat(name, attrTag, value);
        }

        private static string StringTypeAttribute(string name, string value)
        {
            return String.Concat(name, attrTag, "\"", value, "\"");
        }

        private static string ArrayTypeAttribute(string name, DDValue value)
        {
            string[] resultStringArray = value.ToStringArray();
            string resultString = String.Join(", ", resultStringArray);

            if (resultStringArray.Length == 1)
            {
                return String.Concat(name, attrTag, resultString, ", ");
            }
            else
            {
                return String.Concat(name, attrTag, resultString);
            }
        }
    }
}
