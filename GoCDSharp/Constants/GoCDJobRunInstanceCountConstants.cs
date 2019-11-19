using GoCDSharp.Dtos;

namespace GoCDSharp.Constants
{
    public static class GoCDJobRunInstanceCountConstants
    {
        public static GoCDJobRunInstanceCount RunOnOneInstance => null;
        public static GoCDJobRunInstanceCount RunOnAllAgents => new GoCDJobRunInstanceCount { All = true, Count = 0 };
        public static GoCDJobRunInstanceCount RunOnInstances(int instances) => new GoCDJobRunInstanceCount { All = false, Count = instances };
    }
}
