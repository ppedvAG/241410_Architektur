

using Microsoft.EntityFrameworkCore;
using ppedv.PuecklerPalace.Model;

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

                Assert.NotNull(loaded);
                Assert.Equal(testEis.Name, loaded.Name);
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
                Assert.Equal(1, result);
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
    }
}