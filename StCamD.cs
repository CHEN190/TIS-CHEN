//Created Date:2017/04/26 16:19
using System.Runtime.InteropServices;
namespace SensorTechnology {
	public class StCam {
		private StCam() {} //Only Static Functions
		public delegate void fStCamPreviewBitmapCallbackFunc(System.IntPtr pbyteBitmap,uint dwBufferSize, uint dwWidth, uint dwHeight, uint dwFrameNo, uint dwPreviewPixelFormat, System.IntPtr lpContext,System.IntPtr lpReserved);
		public delegate void fStCamRawCallbackFunc(System.IntPtr pbyteBuffer,uint dwBufferSize, uint dwWidth, uint dwHeight, uint dwFrameNo,ushort wColorArray, uint dwTransferBitsPerPixel, System.IntPtr lpContext,System.IntPtr lpReserved);
		public delegate void fStCamPreviewGDICallbackFunc(System.IntPtr hDC, uint dwWidth, uint dwHeight,  uint dwFrameNo,System.IntPtr lpContext,System.IntPtr lpReserved);
		//------------------------------------------------------------------------------
		//Function
		//------------------------------------------------------------------------------

		#region Initialize
		//------------------------------------------------------------------------------
		//Initialize
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_Open")]
		public static extern System.IntPtr Open(uint dwInstance);
		[DllImport("StCamD.dll", EntryPoint="StCam_Close")]
		public static extern void Close(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetLastError")]
		public static extern uint GetLastError(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_CameraCount")]
		public static extern uint CameraCount();
		[DllImport("StCamD.dll", EntryPoint="StCam_SetReceiveMsgWindow")]
		public static extern bool SetReceiveMsgWindow(System.IntPtr hCamera, System.IntPtr hWnd);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetUSBSpeed")]
		public static extern bool GetUSBSpeed(System.IntPtr hCamera, out byte pbyteUSBSpeed);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetUSBMaxSpeed")]
		public static extern bool GetUSBMaxSpeed(System.IntPtr hCamera, out byte pbyteUSBSpeed);
		#endregion

		#region Image Information
		//------------------------------------------------------------------------------
		//Image Information
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_GetColorArray")]
		public static extern bool GetColorArray(System.IntPtr hCamera, out ushort pwColorArray);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetEnableTransferBitsPerPixel")]
		public static extern bool GetEnableTransferBitsPerPixel(System.IntPtr hCamera, out uint pdwEnableTransferBitsPerPixel);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetTransferBitsPerPixel")]
		public static extern bool SetTransferBitsPerPixel(System.IntPtr hCamera, uint dwTransferBitsPerPixel);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetTransferBitsPerPixel")]
		public static extern bool GetTransferBitsPerPixel(System.IntPtr hCamera, out uint pdwTransferBitsPerPixel);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaximumImageSize")]
		public static extern bool GetMaximumImageSize(System.IntPtr hCamera, out uint pdwMaxWidth, out uint pdwMaxHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetEnableImageSize")]
		public static extern bool GetEnableImageSize(System.IntPtr hCamera, out uint pdwReserved, out ushort pwEnableScanMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetImageSize")]
		public static extern bool SetImageSize(System.IntPtr hCamera, uint dwReserved, ushort wScanMode, uint dwOffsetX, uint dwOffsetY, uint dwWidth, uint dwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetImageSize")]
		public static extern bool GetImageSize(System.IntPtr hCamera, out uint pdwReserved, out ushort pwScanMode, out uint pdwOffsetX, out uint pdwOffsetY, out uint pdwWidth, out uint pdwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetSkippingAndBinning")]
		public static extern bool GetSkippingAndBinning(System.IntPtr hCamera, out byte pbyteHSkipping, out byte pbyteVSkipping, out byte pbyteHBinning, out byte pbyteVBinning);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetSkippingAndBinning")]
		public static extern bool SetSkippingAndBinning(System.IntPtr hCamera, byte byteHSkipping, byte byteVSkipping, byte byteHBinning, byte byteVBinning);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetBinningSumMode")]
		public static extern bool GetBinningSumMode(System.IntPtr hCamera, out ushort pwMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetBinningSumMode")]
		public static extern bool SetBinningSumMode(System.IntPtr hCamera, ushort wMode);
		#endregion

		#region Preview
		//------------------------------------------------------------------------------
		//Preview
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_StartTransfer")]
		public static extern bool StartTransfer(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_StopTransfer")]
		public static extern bool StopTransfer(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetPreviewPixelFormat")]
		public static extern bool SetPreviewPixelFormat(System.IntPtr hCamera, uint dwPreviewPixelFormat);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewPixelFormat")]
		public static extern bool GetPreviewPixelFormat(System.IntPtr hCamera, out uint pdwPreviewPixelFormat);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetEnablePreviewPixelFormat")]
		public static extern bool GetEnablePreviewPixelFormat(System.IntPtr hCamera, out uint pdwEnablePreviewPixelFormat);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetColorInterpolationMethod")]
		public static extern bool SetColorInterpolationMethod(System.IntPtr hCamera, byte byteColorInterpolationMethod);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetColorInterpolationMethod")]
		public static extern bool GetColorInterpolationMethod(System.IntPtr hCamera, out byte pbyteColorInterpolationMethod);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_CreatePreviewWindowA")]
		public static extern bool CreatePreviewWindowA(System.IntPtr hCamera, string pszWindowName, uint dwStyle, int lngPositionX, int lngPositionY, uint dwWidth, uint dwHeight, System.IntPtr hWndParent, System.IntPtr hMenu, bool bCloseEnable);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_CreatePreviewWindowW")]
		public static extern bool CreatePreviewWindowW(System.IntPtr hCamera, string pszWindowName, uint dwStyle, int lngPositionX, int lngPositionY, uint dwWidth, uint dwHeight, System.IntPtr hWndParent, System.IntPtr hMenu, bool bCloseEnable);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_CreatePreviewWindow")]
		public static extern bool CreatePreviewWindow(System.IntPtr hCamera, string pszWindowName, uint dwStyle, int lngPositionX, int lngPositionY, uint dwWidth, uint dwHeight, System.IntPtr hWndParent, System.IntPtr hMenu, bool bCloseEnable);
		[DllImport("StCamD.dll", EntryPoint="StCam_DestroyPreviewWindow")]
		public static extern bool DestroyPreviewWindow(System.IntPtr hCamera);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_SetPreviewWindowNameA")]
		public static extern bool SetPreviewWindowNameA(System.IntPtr hCamera, string pszWindowName);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_GetPreviewWindowNameA")]
		public static extern bool GetPreviewWindowNameA(System.IntPtr hCamera, System.Text.StringBuilder pszWindowName, int lngMaxCount);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_SetPreviewWindowNameW")]
		public static extern bool SetPreviewWindowNameW(System.IntPtr hCamera, string pszWindowName);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_SetPreviewWindowName")]
		public static extern bool SetPreviewWindowName(System.IntPtr hCamera, string pszWindowName);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_GetPreviewWindowNameW")]
		public static extern bool GetPreviewWindowNameW(System.IntPtr hCamera, System.Text.StringBuilder pszWindowName, int lngMaxCount);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_GetPreviewWindowName")]
		public static extern bool GetPreviewWindowName(System.IntPtr hCamera, System.Text.StringBuilder pszWindowName, int lngMaxCount);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetPreviewMaskSize")]
		public static extern bool SetPreviewMaskSize(System.IntPtr hCamera, uint dwOffsetX, uint dwOffsetY, uint dwWidth, uint dwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewMaskSize")]
		public static extern bool GetPreviewMaskSize(System.IntPtr hCamera, out uint pdwOffsetX, out uint pdwOffsetY, out uint pdwWidth, out uint pdwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetPreviewWindowSize")]
		public static extern bool SetPreviewWindowSize(System.IntPtr hCamera, int lngPositionX, int lngPositionY, uint dwWidth, uint dwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewWindowSize")]
		public static extern bool GetPreviewWindowSize(System.IntPtr hCamera, out int plngPositionX, out int plngPositionY, out uint pdwWidth, out uint pdwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetPreviewWindowStyle")]
		public static extern bool SetPreviewWindowStyle(System.IntPtr hCamera, uint dwStyle);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewWindowStyle")]
		public static extern bool GetPreviewWindowStyle(System.IntPtr hCamera, out uint pdwStyle);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAspectMode")]
		public static extern bool SetAspectMode(System.IntPtr hCamera, byte byteAspectMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAspectMode")]
		public static extern bool GetAspectMode(System.IntPtr hCamera, out byte pbyteAspectMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetPreviewDestSize")]
		public static extern bool SetPreviewDestSize(System.IntPtr hCamera, uint dwOffsetX, uint dwOffsetY, uint dwWidth, uint dwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewDestSize")]
		public static extern bool GetPreviewDestSize(System.IntPtr hCamera, out uint pdwOffsetX, out uint pdwOffsetY, out uint pdwWidth, out uint pdwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetMagnificationMode")]
		public static extern bool SetMagnificationMode(System.IntPtr hCamera, byte byteMagnificationMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMagnificationMode")]
		public static extern bool GetMagnificationMode(System.IntPtr hCamera, out byte pbyteMagnificationMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDCWithReset")]
		public static extern bool GetDCWithReset(System.IntPtr hCamera, out System.IntPtr phDC);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDC")]
		public static extern bool GetDC(System.IntPtr hCamera, out System.IntPtr phDC);
		[DllImport("StCamD.dll", EntryPoint="StCam_ReleaseDC")]
		public static extern bool ReleaseDC(System.IntPtr hCamera, System.IntPtr hDC);
		[DllImport("StCamD.dll", EntryPoint="StCam_ResetOverlay")]
		public static extern bool ResetOverlay(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetColorKey")]
		public static extern bool SetColorKey(System.IntPtr hCamera, uint dwColorKey);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetColorKey")]
		public static extern bool GetColorKey(System.IntPtr hCamera, out uint pdwColorKey);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetDisplayMode")]
		public static extern bool SetDisplayMode(System.IntPtr hCamera, byte byteDisplayMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDisplayMode")]
		public static extern bool GetDisplayMode(System.IntPtr hCamera, out byte pbyteDisplayMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAlphaChannel")]
		public static extern bool GetAlphaChannel(System.IntPtr hCamera, out byte pbyteAlphaChannel);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAlphaChannel")]
		public static extern bool SetAlphaChannel(System.IntPtr hCamera, byte byteAlphaChannel);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewImagePixelValue")]
		public static extern bool GetPreviewImagePixelValue(System.IntPtr hCamera, uint nX, uint nY, out uint pdwColor);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewWnd")]
		public static extern bool GetPreviewWnd(System.IntPtr hCamera, out System.IntPtr hWnd);
		#endregion

		#region Image Acquisition
		//------------------------------------------------------------------------------
		//Image Acquisition
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_TakeRawSnapShot")]
		public static extern bool TakeRawSnapShot(System.IntPtr hCamera, System.IntPtr pbyteBuffer, uint dwBufferSize, out uint pdwNumberOfByteTrans, uint[] pdwFrameNo, uint dwMilliseconds);
		[DllImport("StCamD.dll", EntryPoint="StCam_TakePreviewSnapShot")]
		public static extern bool TakePreviewSnapShot(System.IntPtr hCamera, System.IntPtr pbyteBuffer, uint dwBufferSize, out uint pdwNumberOfByteTrans, uint[] pdwFrameNo, uint dwMilliseconds);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_SaveImageA")]
		public static extern bool SaveImageA(System.IntPtr hCamera, uint dwWidth, uint dwHeight, uint dwPreviewPixelFormat, System.IntPtr pbyteData, string pszFileName, uint dwParam);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_SaveImageW")]
		public static extern bool SaveImageW(System.IntPtr hCamera, uint dwWidth, uint dwHeight, uint dwPreviewPixelFormat, System.IntPtr pbyteData, string pszFileName, uint dwParam);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_SaveImage")]
		public static extern bool SaveImage(System.IntPtr hCamera, uint dwWidth, uint dwHeight, uint dwPreviewPixelFormat, System.IntPtr pbyteData, string pszFileName, uint dwParam);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetRawDataSize")]
		public static extern bool GetRawDataSize(System.IntPtr hCamera, out uint pdwSize);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewDataSize")]
		public static extern bool GetPreviewDataSize(System.IntPtr hCamera, out uint pdwSize, out uint pdwWidth, out uint pdwHeight, out uint pdwLinePitch);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetROI")]
		public static extern bool SetROI(System.IntPtr hCamera, uint dwIndex, uint dwMode, uint dwOffsetX, uint dwOffsetY, uint dwWidth, uint dwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetROI")]
		public static extern bool GetROI(System.IntPtr hCamera, uint dwIndex, out uint pdwMode, out uint pdwOffsetX, out uint pdwOffsetY, out uint pdwWidth, out uint pdwHeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxROICount")]
		public static extern bool GetMaxROICount(System.IntPtr hCamera, out uint pdwRegionCount);
		#endregion

		#region Shutter Gain Control
		//------------------------------------------------------------------------------
		//Shutter Gain Control
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_GetALCMode")]
		public static extern bool GetALCMode(System.IntPtr hCamera, out byte pbyteAlcMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetALCMode")]
		public static extern bool SetALCMode(System.IntPtr hCamera, byte byteAlcMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetExposureClock")]
		public static extern bool GetExposureClock(System.IntPtr hCamera, out uint pdwExposureClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetExposureClock")]
		public static extern bool SetExposureClock(System.IntPtr hCamera, uint dwExposureClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxShortExposureClock")]
		public static extern bool GetMaxShortExposureClock(System.IntPtr hCamera, out uint pdwMaximumExpClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxLongExposureClock")]
		public static extern bool GetMaxLongExposureClock(System.IntPtr hCamera, out uint pdwMaximumExpClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetExposureTimeFromClock")]
		public static extern bool GetExposureTimeFromClock(System.IntPtr hCamera, uint dwExposureClock, out float pfExpTime);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetExposureClockFromTime")]
		public static extern bool GetExposureClockFromTime(System.IntPtr hCamera, float fExpTime, out uint pdwExposureClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetGain")]
		public static extern bool GetGain(System.IntPtr hCamera, out ushort pwGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetGain")]
		public static extern bool SetGain(System.IntPtr hCamera, ushort wGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxGain")]
		public static extern bool GetMaxGain(System.IntPtr hCamera, out ushort pwMaxGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetGainDBFromSettingValue")]
		public static extern bool GetGainDBFromSettingValue(System.IntPtr hCamera, ushort wGain, out float pfGainDB);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetTargetBrightness")]
		public static extern bool GetTargetBrightness(System.IntPtr hCamera, out byte pbyteTargetBrightness, out byte pbyteTolerance, out byte pbyteThreshold);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetTargetBrightness")]
		public static extern bool SetTargetBrightness(System.IntPtr hCamera, byte byteTargetBrightness, byte byteTolerance, byte byteThreshold);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetALCWeight")]
		public static extern bool GetALCWeight(System.IntPtr hCamera, byte[] pbyteALCWeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetALCWeight")]
		public static extern bool SetALCWeight(System.IntPtr hCamera, byte[] pbyteALCWeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAEMinExposureClock")]
		public static extern bool SetAEMinExposureClock(System.IntPtr hCamera, uint dwMinExposureClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAEMinExposureClock")]
		public static extern bool GetAEMinExposureClock(System.IntPtr hCamera, out uint pdwMinExposureClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAEMaxExposureClock")]
		public static extern bool GetAEMaxExposureClock(System.IntPtr hCamera, out uint pdwMaxExposureClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAEMaxExposureClock")]
		public static extern bool SetAEMaxExposureClock(System.IntPtr hCamera, uint dwMaxExposureClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetALCControlSpeed")]
		public static extern bool SetALCControlSpeed(System.IntPtr hCamera, byte byteShutterCtrlSpeedLimit, byte byteGainCtrlSpeedLimit, byte byteSkipFrameCount, byte byteAverageFrameCount);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetALCControlSpeed")]
		public static extern bool GetALCControlSpeed(System.IntPtr hCamera, out byte pbyteShutterCtrlSpeedLimit, out byte pbyteGainCtrlSpeedLimit, out byte pbyteSkipFrameCount, out byte pbyteAverageFrameCount);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetGainControlRange")]
		public static extern bool GetGainControlRange(System.IntPtr hCamera, out ushort pwMinGain, out ushort pwMaxGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetGainControlRange")]
		public static extern bool SetGainControlRange(System.IntPtr hCamera, ushort wMinGain, ushort wMaxGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDigitalGain")]
		public static extern bool GetDigitalGain(System.IntPtr hCamera, out ushort pwDigitalGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetDigitalGain")]
		public static extern bool SetDigitalGain(System.IntPtr hCamera, ushort wDigitalGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxDigitalGain")]
		public static extern bool GetMaxDigitalGain(System.IntPtr hCamera, out ushort pwMaxDigitalGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDigitalGainTimesFromSettingValue")]
		public static extern bool GetDigitalGainTimesFromSettingValue(System.IntPtr hCamera, ushort wDigitalGain, out float pfDigitalGainTimes);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDigitalGainSettingValueFromGainTimes")]
		public static extern bool GetDigitalGainSettingValueFromGainTimes(System.IntPtr hCamera, float fDigitalGainTimes, out ushort pwDigitalGain);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetShutterSpeed")]
		public static extern bool GetShutterSpeed(System.IntPtr hCamera, out ushort pwShutterLine, out ushort pwShutterClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetShutterSpeed")]
		public static extern bool SetShutterSpeed(System.IntPtr hCamera, ushort wShutterLine, ushort wShutterClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetShutterControlRange")]
		public static extern bool GetShutterControlRange(System.IntPtr hCamera, out ushort pwMinShutterLine, out ushort pwMinShutterClock, out ushort pwMaxShutterLine, out ushort pwMaxShutterClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetShutterControlRange")]
		public static extern bool SetShutterControlRange(System.IntPtr hCamera, ushort wMinShutterLine, ushort wMinShutterClock, ushort wMaxShutterLine, ushort wMaxShutterClock);
		#endregion

		#region White Balance Control
		//------------------------------------------------------------------------------
		//White Balance Control
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_SetWhiteBalanceMode")]
		public static extern bool SetWhiteBalanceMode(System.IntPtr hCamera, byte byteWBMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetWhiteBalanceMode")]
		public static extern bool GetWhiteBalanceMode(System.IntPtr hCamera, out byte pbyteWBMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetWhiteBalanceGain")]
		public static extern bool SetWhiteBalanceGain(System.IntPtr hCamera, ushort wWBGainR, ushort wWBGainGr, ushort wWBGainGb, ushort wWBGainB);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetWhiteBalanceGain")]
		public static extern bool GetWhiteBalanceGain(System.IntPtr hCamera, out ushort pwWBGainR, out ushort pwWBGainGr, out ushort pwWBGainGb, out ushort pwWBGainB);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetWhiteBalanceTarget")]
		public static extern bool SetWhiteBalanceTarget(System.IntPtr hCamera, ushort wAWBTargetR, ushort wAWBTargetB);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetWhiteBalanceTarget")]
		public static extern bool GetWhiteBalanceTarget(System.IntPtr hCamera, out ushort pwAWBTargetR, out ushort pwAWBTargetB);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetWhiteBalanceToleranceThreshold")]
		public static extern bool SetWhiteBalanceToleranceThreshold(System.IntPtr hCamera, ushort wAWBTolerance, ushort wAWBThreshold);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetWhiteBalanceToleranceThreshold")]
		public static extern bool GetWhiteBalanceToleranceThreshold(System.IntPtr hCamera, out ushort pwAWBTolerance, out ushort pwAWBThreshold);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAWBWeight")]
		public static extern bool SetAWBWeight(System.IntPtr hCamera, byte[] pbyteAWBWeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAWBWeight")]
		public static extern bool GetAWBWeight(System.IntPtr hCamera, byte[] pbyteAWBWeight);
		[DllImport("StCamD.dll", EntryPoint="StCam_RawWhiteBalance")]
		public static extern bool RawWhiteBalance(System.IntPtr hCamera, uint dwWidth, uint dwHeight, ushort wColorArray, System.IntPtr pbyteRaw);
		#endregion

		#region Gamma
		//------------------------------------------------------------------------------
		//Gamma
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_SetGammaMode")]
		public static extern bool SetGammaMode(System.IntPtr hCamera, byte byteGammaTarget, byte byteGammaMode, ushort wGamma, byte[] pbyteGammaTable);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetGammaMode")]
		public static extern bool GetGammaMode(System.IntPtr hCamera, byte byteGammaTarget, out byte pbyteGammaMode, out ushort pwGamma, byte[] pbyteGammaTable);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetGammaModeEx")]
		public static extern bool SetGammaModeEx(System.IntPtr hCamera, byte byteGammaTarget, byte byteGammaMode, ushort wGamma, short shtBrightness, byte byteContrast, byte[] pbyteGammaTable);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetGammaModeEx")]
		public static extern bool GetGammaModeEx(System.IntPtr hCamera, byte byteGammaTarget, out byte pbyteGammaMode, out ushort pwGamma, out short pshtBrightness, out byte pbyteContrast, byte[] pbyteGammaTable);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetCameraGammaValue")]
		public static extern bool GetCameraGammaValue(System.IntPtr hCamera, out ushort pwValue);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetCameraGammaValue")]
		public static extern bool SetCameraGammaValue(System.IntPtr hCamera, ushort wValue);
		#endregion

		#region Sharpness
		//------------------------------------------------------------------------------
		//Sharpness
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_SetSharpnessMode")]
		public static extern bool SetSharpnessMode(System.IntPtr hCamera, byte byteSharpnessMode, ushort wSharpnessGain, byte byteSharpnessCoring);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetSharpnessMode")]
		public static extern bool GetSharpnessMode(System.IntPtr hCamera, out byte pbyteSharpnessMode, out ushort pwSharpnessGain, out byte pbyteSharpnessCoring);
		#endregion

		#region Hue Saturation
		//------------------------------------------------------------------------------
		//Hue Saturation
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_SetHueSaturationMode")]
		public static extern bool SetHueSaturationMode(System.IntPtr hCamera, byte byteHueSaturationMode, short shtHue, ushort wSaturation);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetHueSaturationMode")]
		public static extern bool GetHueSaturationMode(System.IntPtr hCamera, out byte pbyteHueSaturationMode, out short pshtHue, out ushort pwSaturation);
		#endregion

		#region Color Matrix
		//------------------------------------------------------------------------------
		//Color Matrix
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_SetColorMatrix")]
		public static extern bool SetColorMatrix(System.IntPtr hCamera, byte byteColorMatrixMode, short[] pshtColorMatrix);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetColorMatrix")]
		public static extern bool GetColorMatrix(System.IntPtr hCamera, out byte pbyteColorMatrixMode, short[] pshtColorMatrix);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetHighChromaSuppression")]
		public static extern bool SetHighChromaSuppression(System.IntPtr hCamera, ushort wStartLevel, ushort wSuppression);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetLowChromaSuppression")]
		public static extern bool SetLowChromaSuppression(System.IntPtr hCamera, ushort wStartLevel, ushort wSuppression);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetHighChromaSuppression")]
		public static extern bool GetHighChromaSuppression(System.IntPtr hCamera, out ushort pwStartLevel, out ushort pwSuppression);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetLowChromaSuppression")]
		public static extern bool GetLowChromaSuppression(System.IntPtr hCamera, out ushort pwStartLevel, out ushort pwSuppression);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetChromaSuppression")]
		public static extern bool SetChromaSuppression(System.IntPtr hCamera, ushort wStartLevel, ushort wSuppression);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetChromaSuppression")]
		public static extern bool GetChromaSuppression(System.IntPtr hCamera, out ushort pwStartLevel, out ushort pwSuppression);
		#endregion

		#region Shading Correction
		//------------------------------------------------------------------------------
		//Shading Correction
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_SetShadingCorrectionMode")]
		public static extern bool SetShadingCorrectionMode(System.IntPtr hCamera, uint dwMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetShadingCorrectionMode")]
		public static extern bool GetShadingCorrectionMode(System.IntPtr hCamera, out uint pdwMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetShadingCorrectionTarget")]
		public static extern bool SetShadingCorrectionTarget(System.IntPtr hCamera, ushort wTarget);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetShadingCorrectionTarget")]
		public static extern bool GetShadingCorrectionTarget(System.IntPtr hCamera, out ushort wTarget);
		#endregion

		#region Mirro Rotation
		//------------------------------------------------------------------------------
		//Mirro Rotation
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_GetEnableMirrorMode")]
		public static extern bool GetEnableMirrorMode(System.IntPtr hCamera, out byte pbyteMirrorMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetMirrorMode")]
		public static extern bool SetMirrorMode(System.IntPtr hCamera, byte byteMirrorMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMirrorMode")]
		public static extern bool GetMirrorMode(System.IntPtr hCamera, out byte pbyteMirrorMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetRotationMode")]
		public static extern bool SetRotationMode(System.IntPtr hCamera, byte byteRotationMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetRotationMode")]
		public static extern bool GetRotationMode(System.IntPtr hCamera, out byte pbyteRotationMode);
		#endregion

		#region Movie
		//------------------------------------------------------------------------------
		//Movie
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_SaveAVIA")]
		public static extern bool SaveAVIA(System.IntPtr hCamera, string pszFileName, uint dwCompressor, uint dwLength, System.IntPtr lpReserved);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_SaveAVIW")]
		public static extern bool SaveAVIW(System.IntPtr hCamera, string pszFileName, uint dwCompressor, uint dwLength, System.IntPtr lpReserved);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_SaveAVI")]
		public static extern bool SaveAVI(System.IntPtr hCamera, string pszFileName, uint dwCompressor, uint dwLength, System.IntPtr lpReserved);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAVIStatus")]
		public static extern bool SetAVIStatus(System.IntPtr hCamera, byte byteAVIStatus);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAVIStatus")]
		public static extern bool GetAVIStatus(System.IntPtr hCamera, out byte pbyteAVIStatus, out uint pdwTotalFrameCounts, out uint pdwCurrentFrameCounts);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAVIQuality")]
		public static extern bool SetAVIQuality(System.IntPtr hCamera, uint dwQuality);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAVIQuality")]
		public static extern bool GetAVIQuality(System.IntPtr hCamera, out uint pdwQuality);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAVIPriorityFileFormat")]
		public static extern bool SetAVIPriorityFileFormat(System.IntPtr hCamera, uint dwFileFormat);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAVIPriorityFileFormat")]
		public static extern bool GetAVIPriorityFileFormat(System.IntPtr hCamera, out uint pdwFileFormat);
		#endregion

		#region Clock
		//------------------------------------------------------------------------------
		//Clock
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_GetEnableClock")]
		public static extern bool GetEnableClock(System.IntPtr hCamera, out uint pdwEnableClockMode, out uint pdwStandardClock, out uint pdwMinimumClock, out uint pdwMaximumClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetClock")]
		public static extern bool SetClock(System.IntPtr hCamera, uint dwClockMode, uint dwClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetClock")]
		public static extern bool GetClock(System.IntPtr hCamera, out uint pdwClockMode, out uint pdwClock);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetFrameClock")]
		public static extern bool GetFrameClock(System.IntPtr hCamera, out ushort pwCurrentLinePerFrame, out ushort pwCurrentClockPerLine);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetOutputFPS")]
		public static extern bool GetOutputFPS(System.IntPtr hCamera, out float pfFPS);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetVBlankForFPS")]
		public static extern bool SetVBlankForFPS(System.IntPtr hCamera, uint dwVLines);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetVBlankForFPS")]
		public static extern bool GetVBlankForFPS(System.IntPtr hCamera, out uint pdwVLines);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxVBlankForFPS")]
		public static extern bool GetMaxVBlankForFPS(System.IntPtr hCamera, out uint pdwVLines);
		#endregion

		#region IOPin
		//------------------------------------------------------------------------------
		//IOPin
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDeviceTemperature")]
		public static extern bool GetDeviceTemperature(System.IntPtr hCamera, uint dwSelector, out int pnValue);
		#endregion

		#region Defect pixel correction
		//------------------------------------------------------------------------------
		//Defect pixel correction
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_GetEnableDefectPixelCorrectionCount")]
		public static extern bool GetEnableDefectPixelCorrectionCount(System.IntPtr hCamera, out ushort pwCount);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDefectPixelCorrectionMode")]
		public static extern bool GetDefectPixelCorrectionMode(System.IntPtr hCamera, out ushort pwMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetDefectPixelCorrectionMode")]
		public static extern bool SetDefectPixelCorrectionMode(System.IntPtr hCamera, ushort wMode);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDefectPixelCorrectionPosition")]
		public static extern bool GetDefectPixelCorrectionPosition(System.IntPtr hCamera, ushort wIndex, out uint pdwX, out uint pdwY);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetDefectPixelCorrectionPosition")]
		public static extern bool SetDefectPixelCorrectionPosition(System.IntPtr hCamera, ushort wIndex, uint dwX, uint dwY);
		[DllImport("StCamD.dll", EntryPoint="StCam_DetectDefectPixel")]
		public static extern bool DetectDefectPixel(System.IntPtr hCamera, uint dwWidth, uint dwHeight, System.IntPtr pbyteRaw, ushort wThreshold);
		#endregion

		#region HDR
		//------------------------------------------------------------------------------
		//HDR
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_GetHDRType")]
		public static extern bool GetHDRType(System.IntPtr hCamera, out uint pdwHDRType);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetHDRParameter")]
		public static extern bool SetHDRParameter(System.IntPtr hCamera, uint[] pdwBuffer, uint dwSize);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetHDRParameter")]
		public static extern bool GetHDRParameter(System.IntPtr hCamera, uint[] pdwBuffer, ref uint pdwSize);
		#endregion

		#region Callback Function
		//------------------------------------------------------------------------------
		//Callback Function
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_AddPreviewBitmapCallback")]
		public static extern bool AddPreviewBitmapCallback(System.IntPtr hCamera, fStCamPreviewBitmapCallbackFunc pPreviewBitmapCallbackFunc, System.IntPtr pContext, out uint pdwPreviewBitmapCallbackNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_RemovePreviewBitmapCallback")]
		public static extern bool RemovePreviewBitmapCallback(System.IntPtr hCamera, uint dwPreviewBitmapCallbackNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_RemoveAllPreviewBitmapCallback")]
		public static extern bool RemoveAllPreviewBitmapCallback(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewBitmapCallbackCount")]
		public static extern bool GetPreviewBitmapCallbackCount(System.IntPtr hCamera, out uint pdwListCount);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewBitmapCallback")]
		public static extern bool GetPreviewBitmapCallback(System.IntPtr hCamera, uint dwCallbackIndex, out fStCamPreviewBitmapCallbackFunc ppPreviewBitmapCallbackFunc, out uint pdwCallbackFunctionNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_AddPreviewGDICallback")]
		public static extern bool AddPreviewGDICallback(System.IntPtr hCamera, fStCamPreviewGDICallbackFunc pPreviewGDICallbackFunc, System.IntPtr pContext, out uint pdwPreviewGDICallbackNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_RemovePreviewGDICallback")]
		public static extern bool RemovePreviewGDICallback(System.IntPtr hCamera, uint dwPreviewGDICallbackNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_RemoveAllPreviewGDICallback")]
		public static extern bool RemoveAllPreviewGDICallback(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewGDICallbackCount")]
		public static extern bool GetPreviewGDICallbackCount(System.IntPtr hCamera, out uint pdwListCount);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetPreviewGDICallback")]
		public static extern bool GetPreviewGDICallback(System.IntPtr hCamera, uint dwCallbackIndex, out fStCamPreviewGDICallbackFunc ppPreviewGDICallbackFunc, out uint pdwCallbackFunctionNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_AddRawCallback")]
		public static extern bool AddRawCallback(System.IntPtr hCamera, fStCamRawCallbackFunc pRawCallbackFunc, System.IntPtr pContext, out uint pdwRawCallbackNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_RemoveRawCallback")]
		public static extern bool RemoveRawCallback(System.IntPtr hCamera, uint dwRawCallbackNo);
		[DllImport("StCamD.dll", EntryPoint="StCam_RemoveAllRawCallback")]
		public static extern bool RemoveAllRawCallback(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetRawCallbackCount")]
		public static extern bool GetRawCallbackCount(System.IntPtr hCamera, out uint pdwListCount);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetRawCallback")]
		public static extern bool GetRawCallback(System.IntPtr hCamera, uint dwCallbackIndex, out fStCamRawCallbackFunc ppRawCallbackFunc, out uint pdwCallbackFunctionNo);
		#endregion

		#region Setting
		//------------------------------------------------------------------------------
		//Setting
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_SaveSettingFileA")]
		public static extern bool SaveSettingFileA(System.IntPtr hCamera, string pszFileName);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_SaveSettingFileW")]
		public static extern bool SaveSettingFileW(System.IntPtr hCamera, string pszFileName);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_SaveSettingFile")]
		public static extern bool SaveSettingFile(System.IntPtr hCamera, string pszFileName);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_LoadSettingFileA")]
		public static extern bool LoadSettingFileA(System.IntPtr hCamera, string pszFileName);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_LoadSettingFileW")]
		public static extern bool LoadSettingFileW(System.IntPtr hCamera, string pszFileName);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_LoadSettingFile")]
		public static extern bool LoadSettingFile(System.IntPtr hCamera, string pszFileName);
		[DllImport("StCamD.dll", EntryPoint="StCam_ResetSetting")]
		public static extern bool ResetSetting(System.IntPtr hCamera);
		[DllImport("StCamD.dll", EntryPoint="StCam_CameraSetting")]
		public static extern bool CameraSetting(System.IntPtr hCamera, ushort wMode);
		#endregion

		#region EEPROM
		//------------------------------------------------------------------------------
		//EEPROM
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_ReadUserMemory")]
		public static extern bool ReadUserMemory(System.IntPtr hCamera, byte[] pbyteBuffer, ushort wOffset, ushort wLength);
		[DllImport("StCamD.dll", EntryPoint="StCam_WriteUserMemory")]
		public static extern bool WriteUserMemory(System.IntPtr hCamera, byte[] pbyteBuffer, ushort wOffset, ushort wLength);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_ReadCameraUserIDA")]
		public static extern bool ReadCameraUserIDA(System.IntPtr hCamera, out uint pdwCameraID, System.Text.StringBuilder pszBuffer, uint dwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_ReadCameraUserIDW")]
		public static extern bool ReadCameraUserIDW(System.IntPtr hCamera, out uint pdwCameraID, System.Text.StringBuilder pszBuffer, uint dwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_ReadCameraUserID")]
		public static extern bool ReadCameraUserID(System.IntPtr hCamera, out uint pdwCameraID, System.Text.StringBuilder pszBuffer, uint dwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_WriteCameraUserIDA")]
		public static extern bool WriteCameraUserIDA(System.IntPtr hCamera, uint dwCameraID, string pszBuffer, uint dwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_WriteCameraUserIDW")]
		public static extern bool WriteCameraUserIDW(System.IntPtr hCamera, uint dwCameraID, string pszBuffer, uint dwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_WriteCameraUserID")]
		public static extern bool WriteCameraUserID(System.IntPtr hCamera, uint dwCameraID, string pszBuffer, uint dwBufferSize);
		#endregion

		#region Version Information
		//------------------------------------------------------------------------------
		//Version Information
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_GetProductNameA")]
		public static extern bool GetProductNameA(System.IntPtr hCamera, System.Text.StringBuilder pszCameraName, uint dwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_GetProductNameW")]
		public static extern bool GetProductNameW(System.IntPtr hCamera, System.Text.StringBuilder pszCameraName, uint dwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_GetProductName")]
		public static extern bool GetProductName(System.IntPtr hCamera, System.Text.StringBuilder pszCameraName, uint dwBufferSize);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetCameraVersion")]
		public static extern bool GetCameraVersion(System.IntPtr hCamera, out ushort pwUSBVendorID, out ushort pwUSBProductID, out ushort pwFPGAVersion, out ushort pwFirmVersion);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDriverVersion")]
		public static extern bool GetDriverVersion(System.IntPtr hCamera, out uint pdwFileVersionMS, out uint pdwFileVersionLS, out uint pdwProductVersionMS, out uint pdwProductVersionLS);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetUSBDllVersion")]
		public static extern bool GetUSBDllVersion(out uint pdwFileVersionMS, out uint pdwFileVersionLS, out uint pdwProductVersionMS, out uint pdwProductVersionLS);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetCAMDllVersion")]
		public static extern bool GetCAMDllVersion(out uint pdwFileVersionMS, out uint pdwFileVersionLS, out uint pdwProductVersionMS, out uint pdwProductVersionLS);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetUSBFunctionAddress")]
		public static extern bool GetUSBFunctionAddress(System.IntPtr hCamera, out byte pbyteUSBFunctionAddress);
		[DllImport("StCamD.dll", EntryPoint="StCam_HasFunction")]
		public static extern bool HasFunction(System.IntPtr hCamera, uint dwCameraFunctionID, out bool pbHasFunction);
		[DllImport("StCamD.dll", CharSet=CharSet.Ansi, EntryPoint="StCam_GetDevicePathA")]
		public static extern bool GetDevicePathA(System.IntPtr hCamera, System.Text.StringBuilder pszDevicePath, ref uint pdwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Unicode, EntryPoint="StCam_GetDevicePathW")]
		public static extern bool GetDevicePathW(System.IntPtr hCamera, System.Text.StringBuilder pszDevicePath, ref uint pdwBufferSize);
		[DllImport("StCamD.dll", CharSet=CharSet.Auto, EntryPoint="StCam_GetDevicePath")]
		public static extern bool GetDevicePath(System.IntPtr hCamera, System.Text.StringBuilder pszDevicePath, ref uint pdwBufferSize);
		#endregion

		#region Other
		//------------------------------------------------------------------------------
		//Other
		//------------------------------------------------------------------------------
		[DllImport("StCamD.dll", EntryPoint="StCam_ConvertBitmapBGR24ToRGB24")]
		public static extern bool ConvertBitmapBGR24ToRGB24(System.IntPtr hCamera, uint dwWidth, uint dwHeight, System.IntPtr pbyteBitmap);
		[DllImport("StCamD.dll", EntryPoint="StCam_ConvertRawToBGR")]
		public static extern bool ConvertRawToBGR(System.IntPtr hCamera, uint dwWidth, uint dwHeight, System.IntPtr pbyteSrcRaw, System.IntPtr pbyteDstBGR, byte byteColorInterpolationMethod, uint dwPreviewPixelFormat);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetControlArea")]
		public static extern bool SetControlArea(System.IntPtr hCamera, ushort[] pwSepalateX, ushort[] pwSepalateY);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetControlArea")]
		public static extern bool GetControlArea(System.IntPtr hCamera, ushort[] pwSepalateX, ushort[] pwSepalateY);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetDigitalClamp")]
		public static extern bool GetDigitalClamp(System.IntPtr hCamera, out ushort pwValue);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetDigitalClamp")]
		public static extern bool SetDigitalClamp(System.IntPtr hCamera, ushort wValue);
		[DllImport("StCamD.dll", EntryPoint="StCam_ResetRootHub")]
		public static extern bool ResetRootHub();
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAnalogBlackLevel")]
		public static extern bool SetAnalogBlackLevel(System.IntPtr hCamera, ushort wBlackLevel);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAnalogBlackLevel")]
		public static extern bool GetAnalogBlackLevel(System.IntPtr hCamera, out ushort pwBlackLevel);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxAnalogBlackLevel")]
		public static extern bool GetMaxAnalogBlackLevel(System.IntPtr hCamera, out ushort pwBlackLevel);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetMaxDigitalClamp")]
		public static extern bool GetMaxDigitalClamp(System.IntPtr hCamera, out ushort pwDigitalClamp);
		[DllImport("StCamD.dll", EntryPoint="StCam_SetAdjustmentMode")]
		public static extern bool SetAdjustmentMode(System.IntPtr hCamera, uint dwValue);
		[DllImport("StCamD.dll", EntryPoint="StCam_GetAdjustmentMode")]
		public static extern bool GetAdjustmentMode(System.IntPtr hCamera, out uint pdwValue);
		#endregion
		//------------------------------------------------------------------------------
		//Const
		//------------------------------------------------------------------------------

		#region ERROR_STCAM
		//------------------------------------------------------------------------------
		//ERROR_STCAM
		//------------------------------------------------------------------------------
		public const uint ERRST_NOT_FOUND_CAMERA = 0xE0000001;
		public const uint ERRST_ALL_CAMARA_OPENED = 0xE0000002;
		public const uint ERRST_INVALID_CAMERA_HANDLE = 0xE0000003;
		public const uint ERRST_INVALID_FUNCTION_RECEIVING = 0xE0000004;
		public const uint ERRST_USB_COMMAND_TRANSFER = 0xE0000005;
		public const uint ERRST_WINDOW_ALREADY_EXISTS = 0xE0000006;
		public const uint ERRST_WINDOW_DOES_NOT_EXISTS = 0xE0000007;
		public const uint ERRST_INVALID_FUNCTION_RECORDING = 0xE0000008;
		public const uint ERRST_AVI_STREAM = 0xE0000009;
		public const uint ERRST_AVI_NOCOMPRESSOR = 0xE000000A;
		public const uint ERRST_AVI_UNSUPPORTED = 0xE000000B;
		public const uint ERRST_AVI_DISK = 0xE000000C;
		public const uint ERRST_AVI_CANCELED = 0xE000000D;
		public const uint ERRST_AVI_WRITE = 0xE000000E;
		public const uint ERRST_INVALID_FILE_NAME = 0xE000000F;
		public const uint ERRST_FILE_OPEN = 0xE0000010;
		public const uint ERRST_FILE_WRITE = 0xE0000011;
		public const uint ERRST_NOT_SUPPORTED_FUNCTION = 0xE0000021;
		#endregion

		#region WM_STCAM
		//------------------------------------------------------------------------------
		//WM_STCAM
		//------------------------------------------------------------------------------
		public const int WM_STCAM_TRANSFER_START = 0xB001;
		public const int WM_STCAM_TRANSFER_FINISH = 0xB002;
		public const int WM_STCAM_PREVIEW_WINDOW_CREATE = 0xB003;
		public const int WM_STCAM_PREVIEW_WINDOW_CLOSE = 0xB004;
		public const int WM_STCAM_PREVIEW_WINDOW_RESIZE = 0xB005;
		public const int WM_STCAM_PREVIEW_MASK_RESIZE = 0xB006;
		public const int WM_STCAM_PREVIEW_DEST_RESIZE = 0xB007;
		public const int WM_STCAM_AVI_FILE_START = 0xB008;
		public const int WM_STCAM_AVI_FILE_FINISH = 0xB009;
		public const int WM_STCAM_PREVIEW_MENU_COMMAND = 0xB00A;
		public const int WM_STCAM_UPDATED_PREVIEW_IMAGE = 0xB00B;
		#endregion

		#region COLOR_ARRAY
		//------------------------------------------------------------------------------
		//COLOR_ARRAY
		//------------------------------------------------------------------------------
		public const ushort STCAM_COLOR_ARRAY_MONO = 0x0001;
		public const ushort STCAM_COLOR_ARRAY_RGGB = 0x0002;
		public const ushort STCAM_COLOR_ARRAY_GRBG = 0x0003;
		public const ushort STCAM_COLOR_ARRAY_GBRG = 0x0004;
		public const ushort STCAM_COLOR_ARRAY_BGGR = 0x0005;
		#endregion

		#region TRANSER_BITS_PER_PIXEL
		//------------------------------------------------------------------------------
		//TRANSER_BITS_PER_PIXEL
		//------------------------------------------------------------------------------
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_RAW_08 = 0x00000001;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_RAW_10 = 0x00000002;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_RAW_10P = 0x00010000;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_RAW_12 = 0x00000004;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_RAW_12P = 0x00020000;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_RAW_14 = 0x00000008;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_RAW_16 = 0x00000010;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_MONO_08 = 0x00000020;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_MONO_10 = 0x00000040;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_MONO_10P = 0x00100000;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_MONO_12 = 0x00000080;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_MONO_12P = 0x00200000;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_MONO_14 = 0x00000100;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_MONO_16 = 0x00000200;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_BGR_08 = 0x00000400;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_BGR_10 = 0x00000800;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_YCBCR411_08 = 0x00001000;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_YCBCR422_08 = 0x00002000;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_YCBCR444_08 = 0x00004000;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_08 = 0x00000001;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_10 = 0x00000002;
		public const uint STCAM_TRANSFER_BITS_PER_PIXEL_12 = 0x00000004;
		public const uint STCAM_TRANSER_BITS_PER_PIXEL_08 = 0x00000001;
		public const uint STCAM_TRANSER_BITS_PER_PIXEL_16 = 0x00000002;
		#endregion

		#region IMAGE_SIZE_MODE
		//------------------------------------------------------------------------------
		//IMAGE_SIZE_MODE
		//------------------------------------------------------------------------------
		public const uint STCAM_IMAGE_SIZE_MODE_CUSTOM = 0x00000001;
		public const uint STCAM_IMAGE_SIZE_MODE_VGA = 0x00000008;
		public const uint STCAM_IMAGE_SIZE_MODE_XGA = 0x00000020;
		public const uint STCAM_IMAGE_SIZE_MODE_QUAD_VGA = 0x00000080;
		public const uint STCAM_IMAGE_SIZE_MODE_SXGA = 0x00000100;
		public const uint STCAM_IMAGE_SIZE_MODE_UXGA = 0x00000400;
		#endregion

		#region SCAN_MODE
		//------------------------------------------------------------------------------
		//SCAN_MODE
		//------------------------------------------------------------------------------
		public const ushort STCAM_SCAN_MODE_NORMAL = 0x0000;
		public const ushort STCAM_SCAN_MODE_PARTIAL_2 = 0x0001;
		public const ushort STCAM_SCAN_MODE_PARTIAL_4 = 0x0002;
		public const ushort STCAM_SCAN_MODE_PARTIAL_1 = 0x0004;
		public const ushort STCAM_SCAN_MODE_VARIABLE_PARTIAL = 0x0008;
		public const ushort STCAM_SCAN_MODE_BINNING = 0x0010;
		public const ushort STCAM_SCAN_MODE_BINNING_PARTIAL_1 = 0x0020;
		public const ushort STCAM_SCAN_MODE_BINNING_PARTIAL_2 = 0x0040;
		public const ushort STCAM_SCAN_MODE_BINNING_PARTIAL_4 = 0x0080;
		public const ushort STCAM_SCAN_MODE_BINNING_VARIABLE_PARTIAL = 0x0100;
		public const ushort STCAM_SCAN_MODE_ROI = 0x8000;
		public const ushort STCAM_SCAN_MODE_AOI = 0x8000;
		#endregion

		#region PIXEL_FORMAT
		//------------------------------------------------------------------------------
		//PIXEL_FORMAT
		//------------------------------------------------------------------------------
		public const uint STCAM_PIXEL_FORMAT_08_MONO_OR_RAW = 0x00000001;
		public const uint STCAM_PIXEL_FORMAT_24_BGR = 0x00000004;
		public const uint STCAM_PIXEL_FORMAT_32_BGR = 0x00000008;
		#endregion

		#region COLOR_INTERPOLATION
		//------------------------------------------------------------------------------
		//COLOR_INTERPOLATION
		//------------------------------------------------------------------------------
		public const byte STCAM_COLOR_INTERPOLATION_NONE_MONO = 0;
		public const byte STCAM_COLOR_INTERPOLATION_NONE_COLOR = 1;
		public const byte STCAM_COLOR_INTERPOLATION_NEAREST_NEIGHBOR = 2;
		public const byte STCAM_COLOR_INTERPOLATION_BILINEAR = 3;
		public const byte STCAM_COLOR_INTERPOLATION_BILINEAR_FALSE_COLOR_REDUCTION = 5;
		public const byte STCAM_COLOR_INTERPOLATION_BICUBIC = 4;
		#endregion

		#region ASPECT
		//------------------------------------------------------------------------------
		//ASPECT
		//------------------------------------------------------------------------------
		public const byte STCAM_ASPECT_MODE_FIXED = 0;
		public const byte STCAM_ASPECT_MODE_KEEP_ASPECT = 1;
		public const byte STCAM_ASPECT_MODE_ADJUST_WINDOW = 2;
		public const byte STCAM_ASPECT_MODE_MASK_SIZE = 3;
		public const byte STCAM_ASPECT_MODE_CUSTOM_OFFSET = 254;
		public const byte STCAM_ASPECT_MODE_CUSTOM_CENTER = 255;
		public const byte STCAM_ASPECT_MODE_CUSTOM = 255;
		#endregion

		#region MAGNIFICATION
		//------------------------------------------------------------------------------
		//MAGNIFICATION
		//------------------------------------------------------------------------------
		public const byte STCAM_MAGNIFICATION_MODE_OFF = 0;
		public const byte STCAM_MAGNIFICATION_MODE_ON = 1;
		#endregion

		#region ALCMODE
		//------------------------------------------------------------------------------
		//ALCMODE
		//------------------------------------------------------------------------------
		public const byte STCAM_ALCMODE_FIXED_SHUTTER_AGC_OFF = 0;
		public const byte STCAM_ALCMODE_AUTO_SHUTTER_ON_AGC_ON = 1;
		public const byte STCAM_ALCMODE_AUTO_SHUTTER_ON_AGC_OFF = 2;
		public const byte STCAM_ALCMODE_FIXED_SHUTTER_AGC_ON = 3;
		public const byte STCAM_ALCMODE_AUTO_SHUTTER_AGC_ONESHOT = 4;
		public const byte STCAM_ALCMODE_AUTO_SHUTTER_ONESHOT_AGC_OFF = 5;
		public const byte STCAM_ALCMODE_FIXED_SHUTTER_AGC_ONESHOT = 6;
		public const byte STCAM_ALCMODE_CAMERA_AE_ON = 16;
		public const byte STCAM_ALCMODE_CAMERA_AGC_ON = 32;
		public const byte STCAM_ALCMODE_CAMERA_AE_AGC_ON = 48;
		public const byte STCAM_ALCMODE_ALC_FIXED_AGC_OFF = 0;
		public const byte STCAM_ALCMODE_ALC_FULLAUTO_AGC_ON = 1;
		public const byte STCAM_ALCMODE_ALC_FULLAUTO_AGC_OFF = 2;
		public const byte STCAM_ALCMODE_ALC_FIXED_AGC_ON = 3;
		public const byte STCAM_ALCMODE_ALCAGC_ONESHOT = 4;
		public const byte STCAM_ALCMODE_ALC_ONESHOT_AGC_OFF = 5;
		public const byte STCAM_ALCMODE_ALC_FIXED_AGC_ONESHOT = 6;
		#endregion

		#region WB
		//------------------------------------------------------------------------------
		//WB
		//------------------------------------------------------------------------------
		public const byte STCAM_WB_OFF = 0;
		public const byte STCAM_WB_MANUAL = 1;
		public const byte STCAM_WB_FULLAUTO = 2;
		public const byte STCAM_WB_ONESHOT = 3;
		#endregion

		#region GAMMA
		//------------------------------------------------------------------------------
		//GAMMA
		//------------------------------------------------------------------------------
		public const byte STCAM_GAMMA_OFF = 0;
		public const byte STCAM_GAMMA_ON = 1;
		public const byte STCAM_GAMMA_REVERSE = 2;
		public const byte STCAM_GAMMA_TABLE = 255;
		#endregion

		#region GAMMA_TARGET
		//------------------------------------------------------------------------------
		//GAMMA_TARGET
		//------------------------------------------------------------------------------
		public const byte STCAM_GAMMA_TARGET_Y = 0;
		public const byte STCAM_GAMMA_TARGET_R = 1;
		public const byte STCAM_GAMMA_TARGET_GR = 2;
		public const byte STCAM_GAMMA_TARGET_GB = 3;
		public const byte STCAM_GAMMA_TARGET_B = 4;
		#endregion

		#region SHARPNESS
		//------------------------------------------------------------------------------
		//SHARPNESS
		//------------------------------------------------------------------------------
		public const byte STCAM_SHARPNESS_OFF = 0;
		public const byte STCAM_SHARPNESS_ON = 1;
		#endregion

		#region HUE_SATURATION
		//------------------------------------------------------------------------------
		//HUE_SATURATION
		//------------------------------------------------------------------------------
		public const byte STCAM_HUE_SATURATION_OFF = 0;
		public const byte STCAM_HUE_SATURATION_ON = 1;
		#endregion

		#region COLOR_MATRIX
		//------------------------------------------------------------------------------
		//COLOR_MATRIX
		//------------------------------------------------------------------------------
		public const byte STCAM_COLOR_MATRIX_OFF = 0x00;
		public const byte STCAM_COLOR_MATRIX_CUSTOM = 0xFF;
		#endregion

		#region MIRROR
		//------------------------------------------------------------------------------
		//MIRROR
		//------------------------------------------------------------------------------
		public const byte STCAM_MIRROR_OFF = 0;
		public const byte STCAM_MIRROR_HORIZONTAL = 1;
		public const byte STCAM_MIRROR_VERTICAL = 2;
		public const byte STCAM_MIRROR_HORIZONTAL_VERTICAL = 3;
		public const byte STCAM_MIRROR_HORIZONTAL_CAMERA = 16;
		public const byte STCAM_MIRROR_VERTICAL_CAMERA = 32;
		#endregion

		#region ROTATION
		//------------------------------------------------------------------------------
		//ROTATION
		//------------------------------------------------------------------------------
		public const byte STCAM_ROTATION_OFF = 0;
		public const byte STCAM_ROTATION_CLOCKWISE_90 = 1;
		public const byte STCAM_ROTATION_COUNTERCLOCKWISE_90 = 2;
		#endregion

		#region AVI_COMPRESSOR
		//------------------------------------------------------------------------------
		//AVI_COMPRESSOR
		//------------------------------------------------------------------------------
		public const uint STCAM_AVI_COMPRESSOR_UNCOMPRESSED = 0x00000000;
		public const uint STCAM_AVI_COMPRESSOR_MJPG = 0x47504A4D;
		public const uint STCAM_AVI_COMPRESSOR_MP42 = 0x3234706D;
		public const uint STCAM_AVI_COMPRESSOR_MPV4 = 0x3467706D;
		public const uint STCAM_AVI_COMPRESSOR_DIALOG_BOX = 0xFFFFFFFF;
		#endregion

		#region CLOCK_MODE
		//------------------------------------------------------------------------------
		//CLOCK_MODE
		//------------------------------------------------------------------------------
		public const uint STCAM_CLOCK_MODE_NORMAL = 0x00000000;
		public const uint STCAM_CLOCK_MODE_DIV_2 = 0x00000001;
		public const uint STCAM_CLOCK_MODE_DIV_4 = 0x00000002;
		public const uint STCAM_CLOCK_MODE_VGA_90FPS = 0x00000100;
		public const uint STCAM_CLOCK_MODE_CUSTOM = 0x80000000;
		#endregion

		#region USBPID
		//------------------------------------------------------------------------------
		//USBPID
		//------------------------------------------------------------------------------
		public const ushort STCAM_USBPID_STC_C33USB = 0x0305;
		public const ushort STCAM_USBPID_STC_B33USB = 0x0705;
		public const ushort STCAM_USBPID_STC_B83USB = 0x0805;
		public const ushort STCAM_USBPID_STC_C83USB = 0x0605;
		public const ushort STCAM_USBPID_STC_TB33USB = 0x0906;
		public const ushort STCAM_USBPID_STC_TC33USB = 0x1006;
		public const ushort STCAM_USBPID_STC_TB83USB = 0x1106;
		public const ushort STCAM_USBPID_STC_TC83USB = 0x1206;
		public const ushort STCAM_USBPID_STC_TB133USB = 0x0109;
		public const ushort STCAM_USBPID_STC_TC133USB = 0x0209;
		public const ushort STCAM_USBPID_STC_TB152USB = 0x1306;
		public const ushort STCAM_USBPID_STC_TC152USB = 0x1406;
		public const ushort STCAM_USBPID_STC_TB202USB = 0x1506;
		public const ushort STCAM_USBPID_STC_TC202USB = 0x1606;
		public const ushort STCAM_USBPID_STC_MB33USB = 0x0110;
		public const ushort STCAM_USBPID_STC_MC33USB = 0x0210;
		public const ushort STCAM_USBPID_STC_MB83USB = 0x0310;
		public const ushort STCAM_USBPID_STC_MC83USB = 0x0410;
		public const ushort STCAM_USBPID_STC_MB133USB = 0x0510;
		public const ushort STCAM_USBPID_STC_MC133USB = 0x0610;
		public const ushort STCAM_USBPID_STC_MB152USB = 0x0710;
		public const ushort STCAM_USBPID_STC_MC152USB = 0x0810;
		public const ushort STCAM_USBPID_STC_MB202USB = 0x0910;
		public const ushort STCAM_USBPID_STC_MC202USB = 0x1010;
		public const ushort STCAM_USBPID_STC_MBA5MUSB3 = 0x0111;
		public const ushort STCAM_USBPID_STC_MCA5MUSB3 = 0x0211;
		public const ushort STCAM_USBPID_STC_MBE132U3V = 0x0112;
		public const ushort STCAM_USBPID_STC_MCE132U3V = 0x0212;
		public const ushort STCAM_USBPID_STC_MBCM401U3V = 0x0113;
		public const ushort STCAM_USBPID_STC_MCCM401U3V = 0x0213;
		public const ushort STCAM_USBPID_STC_MBCM200U3V = 0x0313;
		public const ushort STCAM_USBPID_STC_MCCM200U3V = 0x0413;
		public const ushort STCAM_USBPID_STC_MBCM33U3V = 0x0513;
		public const ushort STCAM_USBPID_STC_MCCM33U3V = 0x0613;
		public const ushort STCAM_USBPID_STC_MBS241U3V = 0x0713;
		public const ushort STCAM_USBPID_STC_MCS241U3V = 0x0813;
		public const ushort STCAM_USBPID_STC_MBE132U3V_IR = 0x0114;
		public const ushort STCAM_USBPID_STC_RHB33U3V = 0x0115;
		public const ushort STCAM_USBPID_STC_RHC33U3V = 0x0215;
		public const ushort STCAM_USBPID_STC_MBS510U3V = 0x0315;
		public const ushort STCAM_USBPID_STC_MCS510U3V = 0x0415;
		public const ushort STCAM_USBPID_STC_MBS322U3V = 0x0515;
		public const ushort STCAM_USBPID_STC_MCS322U3V = 0x0615;
		public const ushort STCAM_USBPID_STC_MBS891U3V = 0x0116;
		public const ushort STCAM_USBPID_STC_MCS891U3V = 0x0216;
		public const ushort STCAM_USBPID_STC_MBS123BU3V = 0x0316;
		public const ushort STCAM_USBPID_STC_MCS123BU3V = 0x0416;
		public const ushort STCAM_USBPID_STC_MBS43U3V = 0x0516;
		public const ushort STCAM_USBPID_STC_MCS43U3V = 0x0616;
		public const ushort STCAM_USBPID_STC_MBS163U3V = 0x0716;
		public const ushort STCAM_USBPID_STC_MCS163U3V = 0x0816;
		#endregion

		#region AVI_STATUS
		//------------------------------------------------------------------------------
		//AVI_STATUS
		//------------------------------------------------------------------------------
		public const byte STCAM_AVI_STATUS_STOP = 0x00;
		public const byte STCAM_AVI_STATUS_START = 0x01;
		public const byte STCAM_AVI_STATUS_PAUSE = 0x02;
		#endregion

		#region DISPLAY_MODE
		//------------------------------------------------------------------------------
		//DISPLAY_MODE
		//------------------------------------------------------------------------------
		public const byte STCAM_DISPLAY_MODE_GDI = 0x00;
		public const byte STCAM_DISPLAY_MODE_GDI_HALFTONE = 0x08;
		public const byte STCAM_DISPLAY_MODE_DD_OFFSCREEN = 0x01;
		public const byte STCAM_DISPLAY_MODE_DD_OVERLAY = 0x02;
		public const byte STCAM_DISPLAY_MODE_DD_OFFSCREEN_HQ = 0x03;
		public const byte STCAM_DISPLAY_MODE_DD_OVERLAY_HQ = 0x04;
		public const byte STCAM_DISPLAY_MODE_DIRECTX = 0x05;
		public const byte STCAM_DISPLAY_MODE_DIRECTX_VSYNC_ON = 0x06;
		public const byte STCAM_DISPLAY_MODE_DIRECTX_VSYNC_ON2 = 0x07;
		public const byte STCAM_DISPLAY_MODE_DIRECTX_FPU = 0x09;
		public const byte STCAM_DISPLAY_MODE_DIRECTX_VSYNC_ON_FPU = 0x0A;
		public const byte STCAM_DISPLAY_MODE_DIRECTX_VSYNC_ON2_FPU = 0x0B;
		#endregion

		#region TRUE_FALSE
		//------------------------------------------------------------------------------
		//TRUE_FALSE
		//------------------------------------------------------------------------------
		public const uint STCAM_TRUE = 0xFFFFFFFF;
		public const uint STCAM_FALSE = 0x00000000;
		#endregion

		#region CAMERA_SETTING
		//------------------------------------------------------------------------------
		//CAMERA_SETTING
		//------------------------------------------------------------------------------
		public const ushort STCAM_CAMERA_SETTING_INITIALIZE = 0x8000;
		public const ushort STCAM_CAMERA_SETTING_WRITE = 0x2000;
		public const ushort STCAM_CAMERA_SETTING_READ = 0x1000;
		public const ushort STCAM_CAMERA_SETTING_STANDARD = 0x0800;
		public const ushort STCAM_CAMERA_SETTING_DEFECT_PIXEL_POSITION = 0x0400;
		#endregion

		#region DEFECT_PIXEL_CORRECTION
		//------------------------------------------------------------------------------
		//DEFECT_PIXEL_CORRECTION
		//------------------------------------------------------------------------------
		public const ushort STCAM_DEFECT_PIXEL_CORRECTION_OFF = 0x0000;
		public const ushort STCAM_DEFECT_PIXEL_CORRECTION_ON = 0x0001;
		#endregion

		#region BINNING_SUM
		//------------------------------------------------------------------------------
		//BINNING_SUM
		//------------------------------------------------------------------------------
		public const ushort STCAM_BINNING_SUM_MODE_OFF = 0x0000;
		public const ushort STCAM_BINNING_SUM_MODE_H = 0x0001;
		public const ushort STCAM_BINNING_SUM_MODE_V = 0x0100;
		#endregion

		#region AVI_FILE_FORMAT
		//------------------------------------------------------------------------------
		//AVI_FILE_FORMAT
		//------------------------------------------------------------------------------
		public const uint STCAM_AVI_FILE_FORMAT_AVI1 = 0;
		public const uint STCAM_AVI_FILE_FORMAT_AVI2 = 1;
		#endregion

		#region SHADING_CORRECTION_MODE
		//------------------------------------------------------------------------------
		//SHADING_CORRECTION_MODE
		//------------------------------------------------------------------------------
		public const uint STCAM_SHADING_CORRECTION_MODE_OFF = 0x0000;
		public const uint STCAM_SHADING_CORRECTION_MODE_CALIBRATION_MULTIPLICATION = 0x0001;
		public const uint STCAM_SHADING_CORRECTION_MODE_ON_MULTIPLICATION = 0x0002;
		public const uint STCAM_SHADING_CORRECTION_MODE_CALIBRATION_ADDITION = 0x0003;
		public const uint STCAM_SHADING_CORRECTION_MODE_ON_ADDITION = 0x0004;
		#endregion

		#region CAMERA_FUNCTION
		//------------------------------------------------------------------------------
		//CAMERA_FUNCTION
		//------------------------------------------------------------------------------
		public const uint STCAM_CAMERA_FUNCTION_AWB = 24;
		public const uint STCAM_CAMERA_FUNCTION_AGC = 25;
		public const uint STCAM_CAMERA_FUNCTION_AE = 26;
		public const uint STCAM_CAMERA_FUNCTION_STORE_CAMERA_SETTING = 59;
		public const uint STCAM_CAMERA_FUNCTION_ANALOG_BLACK_LEVEL = 0x00050006;
		public const uint STCAM_CAMERA_FUNCTION_DISABLED_ANALOG_GAIN = 0x00090004;
		public const uint STCAM_CAMERA_FUNCTION_AGC_GAIN_TYPE = 0x00090005;
		public const uint STCAM_CAMERA_FUNCTION_ADJUSTMENT_MODE_DIGITAL_GAIN = 0x0009000A;
		public const uint STCAM_CAMERA_FUNCTION_DEVICE_TEMPERATURE_MAINBOARD = 0x00090009;
		#endregion

		#region ADJUSTMENT_MODE
		//------------------------------------------------------------------------------
		//ADJUSTMENT_MODE
		//------------------------------------------------------------------------------
		public const uint STCAM_ADJUSTMENT_MODE_DIGITAL_GAIN = 0x00000001;
		#endregion

		#region DEVICE_TEMPERATURE
		//------------------------------------------------------------------------------
		//DEVICE_TEMPERATURE
		//------------------------------------------------------------------------------
		public const uint STCAM_DEVICE_TEMPERATURE_MAINBOARD = 0x00000001;
		#endregion

		#region HDR_TYPE
		//------------------------------------------------------------------------------
		//HDR_TYPE
		//------------------------------------------------------------------------------
		public const uint STCAM_HDR_TYPE_CMOSIS_4M = 0x00000001;
		#endregion

		#region WINDOW_STYLE
		//------------------------------------------------------------------------------
		//WINDOW_STYLE
		//------------------------------------------------------------------------------
		public const uint WS_OVERLAPPED = 0x00000000;
		public const uint WS_POPUP = 0x80000000;
		public const uint WS_CHILD = 0x40000000;
		public const uint WS_MINIMIZE = 0x20000000;
		public const uint WS_VISIBLE = 0x10000000;
		public const uint WS_DISABLED = 0x08000000;
		public const uint WS_CLIPSIBLINGS = 0x04000000;
		public const uint WS_CLIPCHILDREN = 0x02000000;
		public const uint WS_MAXIMIZE = 0x01000000;
		public const uint WS_CAPTION = 0x00C00000;
		public const uint WS_BORDER = 0x00800000;
		public const uint WS_DLGFRAME = 0x00400000;
		public const uint WS_VSCROLL = 0x00200000;
		public const uint WS_HSCROLL = 0x00100000;
		public const uint WS_SYSMENU = 0x00080000;
		public const uint WS_THICKFRAME = 0x00040000;
		public const uint WS_GROUP = 0x00020000;
		public const uint WS_TABSTOP = 0x00010000;
		public const uint WS_MINIMIZEBOX = 0x00020000;
		public const uint WS_MAXIMIZEBOX = 0x00010000;
		public const uint WS_OVERLAPPEDWINDOW = 0x00CF0000;
		public const uint WS_POPUPWINDOW = 0x80880000;
		public const uint WS_TILED = 0x00000000;
		public const uint WS_ICONIC = 0x00020000;
		public const uint WS_SIZEBOX = 0x00040000;
		public const uint WS_TILEDWINDOW = 0x00CF0000;
		public const uint WS_CHILDWINDOW = 0x40000000;
		#endregion
	}
}

