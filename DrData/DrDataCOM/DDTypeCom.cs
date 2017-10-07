using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using DrOpen.DrCommon.DrData;

namespace DrOpen.DrCommon.DrDataCom
{
    [Guid("E905F26E-212E-4b16-8CED-DDD54B60BD36")]
    public interface IDDTypeCom // cannot list any base interfaces here 
    {
        // Note that the members of IUnknown and Interface are NOT
        // listed here 
        //
        [DispId(1)]
        string Name {get; set; }


        [DispId(2)]
        void ValidateExpectedNodeType([In, MarshalAs(UnmanagedType.BStr)]  string expectedType);
        

        //void Stop();

        //void GetState([In] int msTimeout, [Out] out int pfs);

        //void RenderFile(
        //[In, MarshalAs(UnmanagedType.BStr)] string strFilename);


        //void AddSourceFilter(
        //[In, MarshalAs(UnmanagedType.BStr)] string strFilename,
        //[Out, MarshalAs(UnmanagedType.Interface)] out object ppUnk);

        //[return: MarshalAs(UnmanagedType.Interface)]
        //object FilterCollection();

        //[return: MarshalAs(UnmanagedType.Interface)]
        //object RegFilterCollection();

        //void StopWhenReady();
    }

    [Guid("D5D3F13D-E071-4437-8613-16D6D5927589")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IDDTypeComEvents
    {
    }

    [Guid("FA8372F0-8981-451d-848A-6FB802853D5C")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IDDTypeComEvents))]
    [ProgId("DrDataCom.IDDTypeCom")]
    public class DDTypeCom : DDType, IDDTypeCom
    {

        public DDTypeCom () : base (String.Empty)
        { }
        ~DDTypeCom() { }

        public void ValidateExpectedNodeType(string expectedType)
        {
            base.ValidateExpectedNodeType(expectedType);
            //if ((expectedType == null) || (expectedType.Length==0)) return; // if array is empty exit
            //string[] a;
            //a = new string[expectedType.Length];
            //for (int i = 0; i < expectedType.Length; i++)
            //{
            //    a[i] = expectedType[i].ToString();
            //}
        }

    }
}
