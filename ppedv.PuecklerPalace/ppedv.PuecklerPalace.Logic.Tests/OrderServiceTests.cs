using Moq;
using ppedv.PuecklerPalace.Model.Contracts;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Logic.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CalcOrderSum_null_as_bestellung_throws_ArgumentNullEx()
        {
            var os = new OrderService(null);

            Assert.Throws<ArgumentNullException>(() => os.CalcOrderSum(null));
        }

        [Fact]
        public void CalcOrderSum_1_position_1_amount_3_preis_result_3()
        {
            var os = new OrderService(null);
            var best = new Bestellung();
            best.Positionen.Add(new BestellPosition()
            {
                Bestellung = best,
                Element = new Eissorte() { Preis = 3 },
                Amount = 1
            });

            var sum = os.CalcOrderSum(best);

            Assert.Equal(3, sum);
        }


        [Fact]
        public void CalcOrderSum_2_positionen_1_amount_3_preis_result_6()
        {
            var os = new OrderService(null);
            var best = new Bestellung();
            best.Positionen.Add(new BestellPosition()
            {
                Bestellung = best,
                Element = new Eissorte() { Preis = 3 },
                Amount = 1
            });
            best.Positionen.Add(new BestellPosition()
            {
                Bestellung = best,
                Element = new Eissorte() { Preis = 3 },
                Amount = 1
            });

            var sum = os.CalcOrderSum(best);

            Assert.Equal(6, sum);
        }

        [Fact]
        public void CalcOrderSum_1_positionen_2_amount_3_preis_result_6()
        {
            var os = new OrderService(null);
            var best = new Bestellung();
            best.Positionen.Add(new BestellPosition()
            {
                Bestellung = best,
                Element = new Eissorte() { Preis = 3 },
                Amount = 2
            });

            var sum = os.CalcOrderSum(best);

            Assert.Equal(6, sum);
        }

        [Fact]
        public void GetMostOrderdEissorte_shoudld_result_Schoko_TestRepo()
        {
            var os = new OrderService(new TestRepo());

            var result = os.GetMostOrderdEissorte();

            Assert.Equal("Schoko", result.Name);
        }

        [Fact]
        public void GetMostOrderdEissorte_shoudld_result_Schoko_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Eissorte>()).Returns(() =>
            {
                var eis1 = new Eissorte() { Name = "Vanille" };
                eis1.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis1 });
                var eis2 = new Eissorte() { Name = "Schoko" };
                eis2.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis2 });
                eis2.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis2 });
                eis2.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis2 });
                var eis3 = new Eissorte() { Name = "Erdbeer" };
                eis3.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis3 });
                eis3.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis3 });

                return new[] { eis1, eis2, eis3 }.AsQueryable();
            });

            var os = new OrderService(mock.Object);

            var result = os.GetMostOrderdEissorte();

            Assert.Equal("Schoko", result.Name);
            mock.Verify(x => x.GetAll<Eissorte>(), Times.Exactly(1));
            mock.Verify(x => x.Delete<Eissorte>(It.IsAny<Eissorte>()), Times.Never());
        }
    }

    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T? Get<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Eissorte))
            {
                var eis1 = new Eissorte() { Name = "Vanille" };
                eis1.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis1 });
                var eis2 = new Eissorte() { Name = "Schoko" };
                eis2.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis2 });
                eis2.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis2 });
                eis2.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis2 });
                var eis3 = new Eissorte() { Name = "Erdbeer" };
                eis3.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis3 });
                eis3.Positionen.Add(new BestellPosition() { Bestellung = new Bestellung(), Element = eis3 });

                return new[] { eis1, eis2, eis3 }.AsQueryable<Eissorte>().Cast<T>();
            }
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}