using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DrOpen.DrCommon.DrData;

namespace DrOpen.DrCommon.DrDataCom
{
        [Guid("1335CCD7-EE3D-4d84-BBB7-65CC800C3084")]
    public interface IDDValueCom // cannot list any base interfaces here 
    {
        // Note that the members of IUnknown and Interface are NOT
        // listed here 
        //
        [DispId(1)]
            Type Type { [return: MarshalAs(UnmanagedType.BStr)] get; }
       // [DispId(2)]

        //long SizeValue { [return: MarshalAs(UnmanagedType.I8)] get; }
             
        //[DispId(2)]
        //void ValidateExpectedNodeType([In, MarshalAs(UnmanagedType.BStr)]  string expectedType);
        

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

    [Guid("EC39B55B-AE93-4aff-ACFC-9A0BD265A0D0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IDDValueComEvents
    {
    }

    [Guid("8FD62AE4-924F-45a0-9D25-88F2FB95F324")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IDDValueComEvents))]
    [ProgId("DrDataCom.IDDValueCom")]
    public class DDValueCom : DDValue, IDDValueCom
    {
        public long SizeValue { get { return base.Size; } }
        public Type Type { get { return typeof(string); } }

    }
}
