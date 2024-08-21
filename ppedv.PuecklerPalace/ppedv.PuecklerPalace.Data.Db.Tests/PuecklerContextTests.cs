using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ppedv.PuecklerPalace.Model.DomainModel;
using System.Diagnostics;
using System.Reflection;

namespace ppedv.PuecklerPalace.Data.Db.Tests
{
    public class PuecklerContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=PücklerDb_Test;Trusted_Connection=true;";

        [Fact]
        [Trait("Category", "System")]
        public void Can_create_db()
        {
            var con = new PuecklerContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }


        [Fact]
        [Trait("Category", "System")]
        public void Can_insert_Eisorte()
        {
            var testEis = new Eissorte() { Eistyp = Eistyp.Micheis, Name = "Schokotest" };
            var con = new PuecklerContext(conString);
            con.Database.EnsureCreated();

            con.Add(testEis);
            var result = con.SaveChanges();

            Assert.Equal(2, result);
        }

        [Fact]
        [Trait("Category", "System")]
        public void Can_read_Eisorte()
        {
            var testEis = new Eissorte() { Eistyp = Eistyp.Micheis, Name = $"Joghurttest_{Guid.NewGuid()}" };
            using (var con = new PuecklerContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(testEis);
                con.SaveChanges();
            }

            using (var con = new PuecklerContext(conString))
            {
                var loaded = con.Find<Eissorte>(testEis.Id);
                //var loaded = con.Eissorten.FirstOrDefault(x => x.Id == testEis.Id);

                //Assert.NotNull(loaded);
                loaded.Should().NotBeNull();
                //Assert.Equal(testEis.Name, loaded.Name);
                loaded.Name.Should().Be(testEis.Name);
                Assert.False(testEis == loaded);
                Assert.NotEqual(testEis, loaded);
            }
        }

        [Fact]
        [Trait("Category", "System")]
        public void Can_update_Eisorte()
        {
            var testEis = new Eissorte() { Eistyp = Eistyp.Fruchteis, Name = $"Apfeltest_{Guid.NewGuid()}" };
            var newName = $"Zitronentest_{Guid.NewGuid()}";
            using (var con = new PuecklerContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(testEis);
                con.SaveChanges();
            }

            using (var con = new PuecklerContext(conString))
            {
                var loaded = con.Find<Eissorte>(testEis.Id);
                loaded!.Name = newName;
                var result = con.SaveChanges();
                //Assert.Equal(1, result);
                result.Should().Be(1);
            }

            //opt. verify
            using (var con = new PuecklerContext(conString))
            {
                var loaded = con.Find<Eissorte>(testEis.Id);
                Assert.Equal(newName, loaded!.Name);
            }
        }

        [Fact]
        [Trait("Category", "System")]
        public void Can_delete_Eisorte()
        {
            var testEis = new Eissorte() { Eistyp = Eistyp.Fruchteis, Name = $"Deleteltest_{Guid.NewGuid()}" };
            using (var con = new PuecklerContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(testEis);
                con.SaveChanges();
            }

            using (var con = new PuecklerContext(conString))
            {
                var loaded = con.Find<Eissorte>(testEis.Id);
                con.Remove(loaded!);
                var result = con.SaveChanges();
                Assert.Equal(2, result);
            }

            //opt. verify
            using (var con = new PuecklerContext(conString))
            {
                var loaded = con.Find<Eissorte>(testEis.Id);
                Assert.Null(loaded);
            }
        }

        [Fact]
        [Trait("Category", "System")]
        public void Inserting_a_too_long_Kundenname_should_thow_exception()
        {
            var testBestell = new Bestellung() { Kunde = "Maximilian Alexander Johannes Friedrich Leopold Heinrich von Hohenstein-Habsburg-Lothringen-Windsor-Sachsen-Coburg und Gotha-Ludwig-Maria-Theodor-Ernst-Wilhelm-August-Bernhard-Georg-Johann-Philipp-Richard-Karl-Franz-Hermann-Emanuel-Otto-Rudolf-Albrecht-Ferdinand-Klemens-Hubert von Mecklenburg-Schwerin" };
            var con = new PuecklerContext(conString);
            con.Database.EnsureCreated();

            con.Add(testBestell);
            Assert.Throws<DbUpdateException>(() => con.SaveChanges());

        }

        [Fact]
        [Trait("Category", "System")]
        public void Insert_Bestellung_with_AutoFixture()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new TypeRelay(typeof(EisElement), typeof(Eissorte)));
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            var best = fix.Create<Bestellung>();

            using (var con = new PuecklerContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(best);
                var rows = con.SaveChanges();
                Debug.WriteLine($"ROWS: {rows}");
            }

            using (var con = new PuecklerContext(conString))
            {
                var loaded = con.Find<Bestellung>(best.Id);//Lazy Loading 

                //var loaded = con.Bestellungen.Include(x => x.Positionen)
                //                             .ThenInclude(x => x.Element)
                //                             .ThenInclude(x => x.Zutaten)
                //                             .FirstOrDefault(x => x.Id == best.Id); //Eager Loading 

                //explizit loading 
                //var loaded = con.Find<Bestellung>(best.Id);
                //con.Entry(loaded).Collection(x => x.Positionen).Load();
                //foreach (var item in loaded.Positionen)
                //{
                //    con.Entry(item).Reference(x => x.Element).Load();
                //    con.Entry(item.Element).Collection(x => x.Zutaten).Load();
                //}

                loaded.Should().BeEquivalentTo(best, x => x.IgnoringCyclicReferences());
            }

        }

    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}