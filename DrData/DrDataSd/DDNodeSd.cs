using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrOpen.DrCommon.DrData;
using DrOpen.DrData.DrDataSd;

namespace DrOpen.DrCommon.DrDataSd
{
    /// <summary>
    /// converts DDNode to DDML 
    /// </summary>
    public class DDNodeSd
    {
        private DDNode n;

        public DDNodeSd(DDNode n)
        {
            this.n = n;
        }

        public DDNode GetValue()
        {
            return this.n;
        }

        /// <summary>
        /// get DDNode representation as DDML string builder
        /// </summary>
        /// <param name="sb"></param>
        public void WriteDDML(StringBuilder sb)
        {
            DDNodeSde.Serialize(this.n, sb);
        }
        /// <summary>
        /// get DDNode representation as DDML stream
        /// </summary>
        /// <param name="st"></param>
        public void WriteDDML(Stream st)
        {
            DDNodeSde.Serialize(this.n, st);
        }
    }

    public static class DDNodeSde
    {
        /// <summary>
        /// Provides serialization DDNode to DDML StringBuilder
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sb"></param>
        public static void Serialize(DDNode n, StringBuilder sb)
        {
            using (StringWriter sw = new StringWriter(sb))
            {
                sw.Write(DDMLPresenter.DDnodeToDDML(n));
            }
        }

        /// <summary>
        /// Provides serialization DDNode to DDML stream
        /// </summary>
        /// <param name="n"></param>
        /// <param name="s"></param>
        public static void Serialize(DDNode n, Stream s)
        {
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write(DDMLPresenter.DDnodeToDDML(n));
            }
        }
    }

    /// <summary>
    /// extends DDNode to call SerializeToDDML as a static method of DDNode instance
    /// </summary>
    public static class DDNodeExtention
    {
        public static void SerializeToDDML(this DDNode n, StringBuilder sb)
        {
            DDNodeSde.Serialize(n, sb);
        }

        public static void SerializeToDDML(this DDNode n, Stream st)
        {
            DDNodeSde.Serialize(n, st);
        }
    }
}
