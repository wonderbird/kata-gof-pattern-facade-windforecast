using kata_gof_pattern_facade_windforecast;

namespace kata_gof_pattern_facade_windforecast_tests
{
    public interface ITestBuilder
    {
        void SetupWindspeedForNextDays(params int[] windSpeedForNextDays);
        void SetupMocks(string location);
        IWindForecastService CreateWindForecastService();
        void VerifyMocks();
    }
}