using Prometheus;
using Prometheus.HttpMetrics;

namespace ProfessorApplication.Health
{
    public sealed class HttpRequestCountOptions : HttpMetricsOptionsBase
    {
        /// <summary>
        /// Set this to use a custom metric instead of the default.
        /// </summary>
        public ICollector<ICounter>? Counter { get; set; }
    }
}
