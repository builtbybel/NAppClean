using System.Threading.Tasks;

namespace NativeAppCleanup
{
    public abstract class FeatureBase
    {
        public abstract string ID();

        public abstract string Info();

        public abstract string GetFeatureDetails();

        public abstract string SupportedOS();

        public abstract Task<bool> CheckFeature();

        public abstract Task<bool> DoFeature();

        public abstract bool UndoFeature();
    }
}