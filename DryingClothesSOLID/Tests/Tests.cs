using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Tests
{
    [TestFixture]
    public class Tests
    {
        private DryClothes _sut;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Air_Dried()
        {
            _sut = new DryClothes(new AirDryClothes());
            Assert.AreEqual("items dried = 10", _sut.GetTotalDried());
            Assert.AreEqual(", dried with Drying Rack", _sut.GetEquipmentUsed());
            Assert.AreEqual(String.Empty, _sut.GetPoweredBy());
        }

        [Test]
        public void Machine_Dry_Solar_Powered()
        {
            _sut = new DryClothes(new MachineDryClothes(), new SolarPowered());
            Assert.AreEqual("items dried = 5", _sut.GetTotalDried());
            Assert.AreEqual(", dried with Drying Machine", _sut.GetEquipmentUsed());
            Assert.AreEqual(", powered by solar powered", _sut.GetPoweredBy());
        }

        [Test]
        public void Machine_Dry_Grid_Powered()
        {
            _sut = new DryClothes(new MachineDryClothes(), new GridPowered());
            Assert.AreEqual("items dried = 5", _sut.GetTotalDried());
            Assert.AreEqual(", dried with Drying Machine", _sut.GetEquipmentUsed());
            Assert.AreEqual(", powered by grid powered", _sut.GetPoweredBy());
        }

        [Test]
        public void Two_In_One_Solar_Powered()
        {
            _sut = new DryClothes(new TwoInOneMachineDry(), new SolarPowered());
            Assert.AreEqual("items dried = 15", _sut.GetTotalDried());
            Assert.AreEqual(", dried with Two In One Machine", _sut.GetEquipmentUsed());
            Assert.AreEqual(", powered by solar powered", _sut.GetPoweredBy());
        }

        [Test]
        public void Two_In_One_Grid_Powered()
        {
            _sut = new DryClothes(new TwoInOneMachineDry(), new GridPowered());
            Assert.AreEqual("items dried = 15", _sut.GetTotalDried());
            Assert.AreEqual(", dried with Two In One Machine", _sut.GetEquipmentUsed());
            Assert.AreEqual(", powered by grid powered", _sut.GetPoweredBy());
        }

    }
}