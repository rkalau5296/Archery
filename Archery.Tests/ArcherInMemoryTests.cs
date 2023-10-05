namespace Archery.Tests
{
    public class ArcherInMemoryTests
    {
        [Test]
        public void CheckIfArchersAreNotEqual()
        {
            // arrange
            ArcherInMemory archer = new("Jan", "Kowalski");            
            archer.AddPoint(5.0f);
            archer.AddPoint(4.0f);
            archer.AddPoint(3.0f);
            archer.AddPoint(6.0f);
            archer.AddPoint(2.0f);
            archer.AddPoint(5.0f);            

            // act
            var result = archer.GetStatistics();

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Average, Is.EqualTo(4.16666651).Within(0.01));
                Assert.That(result.Count, Is.EqualTo(6));
                Assert.That(result.Max, Is.EqualTo(6));
                Assert.That(result.Min, Is.EqualTo(2));
            });            
        }
    }
}
