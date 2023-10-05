namespace Archery.Tests
{
    public class ArcherTests
    {
        [Test]
        public void CheckIfArchersAreNotEqual()
        {
            Archer archer1 = new("Jan", "Kowalski");
            Archer archer2 = new("Piotr", "Kwiatkowski");

            Assert.Multiple(() =>
            {
                Assert.That(archer1, Is.Not.EqualTo(archer2));
                Assert.That(ReferenceEquals(archer1, archer2), Is.False);
            });
        }

        [Test]
        public void CheckIfArchersAreEqual()
        {
            Archer archer1 = new("Jan", "Kowalski");
            Archer archer2 = archer1;

            Assert.Multiple(() =>
            {
                Assert.That(archer1, Is.EqualTo(archer2));
                Assert.That(ReferenceEquals(archer1, archer2), Is.True);
            });
        }
    }
}