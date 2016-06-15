//
// File generated by HDevelop for HALCON/.NET (C#) Version 12.0.2
//

using HalconDotNet;

public partial class HDevelopExport
{
#if !(NO_EXPORT_MAIN || NO_EXPORT_APP_MAIN)
  public HDevelopExport()
  {
    // Default settings used in HDevelop 
    HOperatorSet.SetSystem("width", 512);
    HOperatorSet.SetSystem("height", 512);
    if (HalconAPI.isWindows)
      HOperatorSet.SetSystem("use_window_thread","true");
    action();
  }
#endif

#if !NO_EXPORT_MAIN
  // Main procedure 
  private void action()
  {


    // Stack for temporary objects 
    HObject[] OTemp = new HObject[20];

    // Local iconic variables 

    HObject ho_NewImage, ho_Image, ho_ImageSelected=null;
    HObject ho_Image1=null;

    // Local control variables 

    HTuple hv_AcqHandle = null, hv_ChannelCount = null;
    HTuple hv_Index = null, hv_Pointer = new HTuple(), hv_Type = new HTuple();
    HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_NewImage);
    HOperatorSet.GenEmptyObj(out ho_Image);
    HOperatorSet.GenEmptyObj(out ho_ImageSelected);
    HOperatorSet.GenEmptyObj(out ho_Image1);
    //Image Acquisition 01: Code generated by Image Acquisition 01
    ho_NewImage.Dispose();
    HOperatorSet.GenEmptyObj(out ho_NewImage);
    HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb", 
        -1, "false", "default", "[0] Integrated Camera", 0, -1, out hv_AcqHandle);
    HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
    //Image Acquisition 01: Do something
    ho_Image.Dispose();
    HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
    HOperatorSet.CountChannels(ho_Image, out hv_ChannelCount);
    HTuple end_val7 = hv_ChannelCount;
    HTuple step_val7 = 1;
    for (hv_Index=1; hv_Index.Continue(end_val7, step_val7); hv_Index = hv_Index.TupleAdd(step_val7))
    {
      ho_ImageSelected.Dispose();
      HOperatorSet.AccessChannel(ho_Image, out ho_ImageSelected, hv_Index);
      HOperatorSet.GetImagePointer1(ho_ImageSelected, out hv_Pointer, out hv_Type, 
          out hv_Width, out hv_Height);
      ho_Image1.Dispose();
      HOperatorSet.GenImage1(out ho_Image1, "byte", hv_Width, hv_Height, hv_Pointer);
      {
      HObject ExpTmpOutVar_0;
      HOperatorSet.AppendChannel(ho_NewImage, ho_Image1, out ExpTmpOutVar_0);
      ho_NewImage.Dispose();
      ho_NewImage = ExpTmpOutVar_0;
      }
    }
    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
    ho_NewImage.Dispose();
    ho_Image.Dispose();
    ho_ImageSelected.Dispose();
    ho_Image1.Dispose();

  }

#endif


}
#if !(NO_EXPORT_MAIN || NO_EXPORT_APP_MAIN)
public class HDevelopExportApp
{
  static void Main(string[] args)
  {
    new HDevelopExport();
  }
}
#endif
