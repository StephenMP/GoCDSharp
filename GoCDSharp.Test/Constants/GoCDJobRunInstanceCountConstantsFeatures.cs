using System;
using Xunit;

namespace GoCDSharp.Test.Constants
{
    public class GoCDJobRunInstanceCountConstantsFeatures
    {
        private readonly GoCDJobRunInstanceCountConstantsSteps steps;

        public GoCDJobRunInstanceCountConstantsFeatures()
        {
            this.steps = new GoCDJobRunInstanceCountConstantsSteps();
        }

        [Fact]
        public void CanGetRunOnOneInstance()
        {
            this.steps.WhenIAskForRunOnOneInstance();

            this.steps.ThenIShouldReceiveANullReturn();
        }

        [Fact]
        public void CanGetRunOnAllAgents()
        {
            this.steps.WhenIAskForRunOnAllAgents();

            this.steps.ThenAllShouldBe(true);
            this.steps.ThenCountShouldBe(0);
        }

        [Fact]
        public void CanGetRunOnInstances()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var instances = random.Next();
                this.steps.WhenIAskForRunOnInstances(instances);

                this.steps.ThenAllShouldBe(false);
                this.steps.ThenCountShouldBe(instances);
            }
        }

        [Theory]
        [InlineData(true, 0)]
        [InlineData(true, 2)]
        [InlineData(true, 4)]
        [InlineData(true, 8)]
        [InlineData(true, 16)]
        [InlineData(false, 0)]
        [InlineData(false, 2)]
        [InlineData(false, 4)]
        [InlineData(false, 8)]
        [InlineData(false, 16)]
        public void CanSerializeAndDeserializeJson(bool all, int count)
        {
            this.steps.GivenIHaveAGoCDJob(all, count);

            this.steps.WhenISerializeToJson();

            this.steps.ThenIShouldReceiveAString();

            if (all)
            {
                this.steps.ThenTheStringShouldContain("\"run_instance_count\":\"all\"");
            }
            else
            {
                this.steps.ThenTheStringShouldContain($"\"run_instance_count\":{count}");
            }

            this.steps.WhenIDeserializeFromJson();

            this.steps.ThenIShouldReceiveAGoCDJobRunInstanceCount();

            if (all)
            {
                this.steps.ThenAllShouldBe(all);
            }

            else
            {
                this.steps.ThenCountShouldBe(count);
            }
        }
    }
}
