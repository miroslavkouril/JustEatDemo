using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo.Core.SAL
{
	public interface IGPSService
	{
		bool GPSHardwareExists();
		bool GPSIsEnabled();
		string GetPostcodeOfLocation(GPSExactLocation location);
	}
}