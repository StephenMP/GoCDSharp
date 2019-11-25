using GoCDSharp.Constants;
using GoCDSharp.Dtos;
using Newtonsoft.Json;
using Xunit;

namespace GoCDSharp.Test.Constants
{
    internal class GoCDJobRunInstanceCountConstantsSteps
    {
        private GoCDJobRunInstanceCount goCDJobRunInstanceCount;
        private string json;
        private GoCDJob goCDJob;

        internal void WhenIAskForRunOnOneInstance()
        {
            this.goCDJobRunInstanceCount = GoCDJobRunInstanceCountConstants.RunOnOneInstance;
        }

        internal void ThenIShouldReceiveANullReturn()
        {
            Assert.Null(this.goCDJobRunInstanceCount);
        }

        internal void WhenIAskForRunOnAllAgents()
        {
            this.goCDJobRunInstanceCount = GoCDJobRunInstanceCountConstants.RunOnAllAgents;
        }

        internal void WhenIAskForRunOnInstances(int instances)
        {
            this.goCDJobRunInstanceCount = GoCDJobRunInstanceCountConstants.RunOnInstances(instances);
        }

        internal void ThenAllShouldBe(bool value)
        {
            Assert.Equal(value, this.goCDJobRunInstanceCount.All);
        }

        internal void ThenCountShouldBe(int instances)
        {
            Assert.Equal(instances, this.goCDJobRunInstanceCount.Count);
        }

        internal void GivenIHaveAGoCDJob(bool all, int count)
        {
            this.goCDJob = new GoCDJob { RunInstanceCount = new GoCDJobRunInstanceCount { All = all, Count = count } };
        }

        internal void WhenISerializeToJson()
        {
            this.json = JsonConvert.SerializeObject(this.goCDJob);
        }

        internal void ThenIShouldReceiveAString()
        {
            Assert.NotNull(this.json);
            Assert.NotEmpty(this.json);
        }

        internal void ThenTheStringShouldContain(string substring)
        {
            Assert.Contains(substring, this.json);
        }

        internal void WhenIDeserializeFromJson()
        {
            this.goCDJob = JsonConvert.DeserializeObject<GoCDJob>(this.json);
            this.goCDJobRunInstanceCount = this.goCDJob.RunInstanceCount;
        }

        internal void ThenIShouldReceiveAGoCDJobRunInstanceCount()
        {
            Assert.NotNull(this.goCDJobRunInstanceCount);
        }
    }
}