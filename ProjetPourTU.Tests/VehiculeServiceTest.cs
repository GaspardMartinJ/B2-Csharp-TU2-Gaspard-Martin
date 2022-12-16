using ProjetPourTU.Model;
using ProjetPourTU.Services;
using ProjetPourTU.Services.CustomExceptions;
using System.Linq;

namespace ProjetPourTU.Tests
{
    public class VehiculeServiceTest
    {
        private VehiculeService _testedClass;
        [SetUp]
        public void Setup()
        {
            _testedClass = new VehiculeService();
        }

        [Test]
        public void getAllTest()
        {
            IEnumerable<Vehicule> vehicules = _testedClass.getAll();
            Assert.IsNotNull(vehicules);
            Assert.That(vehicules.Count(), Is.EqualTo(3));
            Assert.That(vehicules.ElementAt(0).ID, Is.EqualTo(1));
            Assert.That(vehicules.ElementAt(1).Immatriculation, Is.EqualTo("BBB"));
            Assert.That(vehicules.ElementAt(2).Nom, Is.EqualTo("Renault Clio"));
        }

        [Test]
        public void getByIDTest()
        {
            Assert.Throws<InvalidIDException>(() => _testedClass.getByID(0));
            Assert.Throws<InvalidIDException>(() => _testedClass.getByID(-1));
            Assert.Throws<VehiculeNotFoundException>(() => _testedClass.getByID(4));
            Assert.That(_testedClass.getByID(1).ID, Is.EqualTo(1));
            Assert.That(_testedClass.getByID(2).Immatriculation, Is.EqualTo("BBB"));
            Assert.That(_testedClass.getByID(3).Nom, Is.EqualTo("Renault Clio"));
        }

        [Test]
        public void AddVehiculeTest()
        {
            Vehicule? vn = null;
            Vehicule v1 = new Vehicule() { ID = 1, Immatriculation = "AAA", Nom = "Peugeot 308" };
            Vehicule v2 = new Vehicule() { ID = 4, Immatriculation = "test1", Nom = "test1" };
            Vehicule v3 = new Vehicule() { ID = 10, Immatriculation = "test2", Nom = "test2" };
            Vehicule v4 = new Vehicule() { ID = -1, Immatriculation = "test3", Nom = "test3" };
            _testedClass.AddVehicule(v2);
            _testedClass.AddVehicule(v3);
            _testedClass.AddVehicule(v4);
            Assert.Throws<NullNotAllowedException>(() => _testedClass.AddVehicule(vn));
            Assert.Throws<SameIDExistsException>(() => _testedClass.AddVehicule(v1));
            Assert.That(_testedClass.getByID(4), Is.EqualTo(v2));
            Assert.That(_testedClass.getByID(5), Is.EqualTo(v3));
            Assert.That(_testedClass.getByID(6), Is.EqualTo(v4));
        }

        [Test]
        public void CreerMessagePourUnVehiculeTest()
        {
            Vehicule v1 = new Vehicule() { ID = 1, Immatriculation = "AAA", Nom = "Peugeot 308" };
            string expected = "Véhicule : Peugeot 308, immatriculation : AAA";
            Assert.That(_testedClass.CreerMessagePourUnVehicule(v1), Is.EqualTo(expected));
        }

        [Test]
        public void CreerMessageTest()
        {
            string expected = "Véhicule : Peugeot 308, immatriculation : AAA\nVéhicule : Toyota Aygo, immatriculation : BBB\nVéhicule : Renault Clio, immatriculation : CCC";
            Assert.That(_testedClass.CreerMessage(), Is.EqualTo(expected));
        }
    }
}
