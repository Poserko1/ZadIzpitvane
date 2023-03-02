using Aqua;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;

namespace AquariumProject.Tests_
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void FishConstructorShouldInicializeCorrectly()
        {
            Fish fish = new Fish("Akula",100);
            Assert.AreEqual("Akula", fish.Type);
            Assert.AreEqual(100, fish.Price);
        }
        [Test]
        public void AquariumConstructorShouldInicializeCorrectly()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Assert.AreEqual("Square", aquarium.Shape);
            Assert.AreEqual(100, aquarium.Capacity);
        }
        [Test]
        public void RemoveMethodShoudThrowExIfListIsEmpty()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 0);
            Assert.Throws<InvalidOperationException>(() => aquarium.AddFish(fish));
        }
        [Test]
        public void RemoveMethodShoudThrowExactExceptionMessageIfListIsEmpty()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 0);
            var ex=Assert.Throws<InvalidOperationException>(() => aquarium.AddFish(fish));
            Assert.AreEqual("Invalid operation", ex.Message);
        }
        [Test]
        public void RemoveMethodShoudThrowExeptionIfFishIsMissing()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 0);
 
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Akula"));
        }
        [Test]
        public void RemoveMethodShoudThrowExactMessageIfFishIsMissing()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 1);
            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("akula"));
            Assert.AreEqual("Invalid operation", ex.Message);
        }
        [Test]
        public void RemoveMethodShoudWorkCorrectlyAndDecreseNumberOfFishesInTheList()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 1);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Akula");
            Assert.AreEqual(0, aquarium.Fishes.Count);
        }
        [Test]
        public void RemoveMethodShoudIncreaseFreeCapacity()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 100);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Akula");
            Assert.AreEqual(100, aquarium.Capacity);
        }
        [Test]
        public void RemoveMethodShoudRemoveExactFish()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 1);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Akula");
            Assert.AreEqual(0, aquarium.Fishes.Count);
        }
        [Test]
        public void ReportRemoveFishShoudPrintExactSuccessfulMessage()
        {
           
        }
        [Test]
        public void EmptyMethodShoudWorkCorrectly()
        {
            Fish fish = new Fish("Akula", 100);
            Aquarium aquarium = new Aquarium("Square", 100);
            aquarium.AddFish(fish);
            aquarium.Empty();
            Assert.AreEqual(100, aquarium.Capacity);
        }

    }
}