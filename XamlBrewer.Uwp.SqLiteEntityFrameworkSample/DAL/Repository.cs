using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using XamlBrewer.Uwp.SqLiteEntityFrameworkSample.Models;

namespace XamlBrewer.Uwp.SqLiteEntityFrameworkSample.Dal
{
    internal static class Repository
    {
        internal async static Task CreateDatabase()
        {
            using (var db = new PersonContext())
            {
                // Remove all content.
                foreach (var existingPerson in db.People)
                {
                    db.People.Remove(existingPerson);
                }

                db.SaveChanges(); // Otherwise multiple entities with the same Id are tracked.

                Person person = new Person();
                person.Id = 1;
                person.Name = "Tyrion Lannister";
                person.DayOfBirth = new DateTime(1969, 11, 6, 0, 0, 0, DateTimeKind.Utc);
                person.Description = "Peter Dinklage attended Bennington College in Vermont, graduating in 1991 with a degree in Drama. Performances these include Heart Piece, The Author's Voice, Landscape of the Body, and Video Priests. His debut film performance was as Tito in Living in Oblivion, with Kevin Corrigan. He is an active Off-Broadway theater actor, and has appeared in plays such as I Wanna Be Adored, Jonathan Marc Sherman's Hollywood, Imperfect Love, A Misty Christmas, and two productions of Saint Stanislaus Outside The House. He is also a playwright whose plays include Frog.";
                StorageFile file = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Pictures\GoT_1.png"));
                person.Picture = await file.AsByteArray();
                var i = db.People.Add(person);

                person = new Person();
                person.Id = 2;
                person.Name = "Cersei Lannister";
                person.DayOfBirth = new DateTime(1973, 10, 3, 0, 0, 0, DateTimeKind.Utc);
                person.Description = "Lena Headey was born in Bermuda, where her father, a police officer was stationed. The family moved to Huddersfield, Yorkshire when Lena was five years and remained their until Lena was seventeen. At the age of seventeen Lena was spotted by a Hollywood casting agent during her performance in an one-off show and her acting career began. In 1992, Lena made her big screen debut in the film Waterland.Over the next thirteen years Lena landed major and minor roles in numerous films, TV movies and television series. Lena enjoy acting and being able to live a somewhat normal life. In 2006, Lena landed the role of Queen Gorgo in the blockbuster hit 300 elevating her fame level.";
                file = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Pictures\GoT_2.png"));
                person.Picture = await file.AsByteArray();
                i = db.People.Add(person);

                person = new Person();
                person.Id = 3;
                person.Name = "Arya Stark";
                person.DayOfBirth = new DateTime(1997, 4, 15, 0, 0, 0, DateTimeKind.Utc);
                person.Description = "Maisie Williams is an English actress. She made her professional acting debut as Arya Stark in the HBO fantasy television series Game of Thrones, for which she won the EWwy Award for Best Supporting Actress in a Drama, the Portal Award for Best Supporting Actress – Television and Best Young Actor, and the Saturn Award for Best Performance by a Younger Actor. Williams has also had a recurring role in Doctor Who as Ashildr in 2015. In addition to television, she made her feature film debut in the mystery The Falling, for which she won the London Film Critics' Circle Award for Young Performer of the Year.";
                file = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Pictures\GoT_3.png"));
                person.Picture = await file.AsByteArray();
                i = db.People.Add(person);

                person = new Person();
                person.Id = 4;
                person.Name = "Daenerys Targaryen";
                person.DayOfBirth = new DateTime(1986, 10, 26, 0, 0, 0, DateTimeKind.Utc);
                person.Description = "Emilia Clarke is a British actress. She was born in London and grew up in Berkshire, England. Her father is a theatre sound engineer and her mother is a businesswoman. Her father was working on a theatre production of 'Show Boat' and her mother took her along to the performance. This is when, at the age of 3, her passion for drama began. From 2000 to 2005, she attended St. Edward's School of Oxford, where she appeared in two school plays. She went on to study at the prestigious Drama Centre London, where she took part in 10 plays. During this time Emilia first appeared on television with a guest role in the BBC's Doctors (2000). In 2010, after graduating from the Drama Centre London, Emilia got her first film role in the TV movie Triassic Attack(2010).Her breakthrough role came in 2011 when she replaced fellow newcomer Tamzin Merchant in Game of Thrones(2011) after the filming of the initial pilot.";
                file = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Pictures\GoT_4.png"));
                person.Picture = await file.AsByteArray();
                i = db.People.Add(person);

                person = new Person();
                person.Id = 5;
                person.Name = "Joffrey Baratheon";
                person.DayOfBirth = new DateTime(1992, 5, 20, 0, 0, 0, DateTimeKind.Utc);
                person.Description = "Jack Gleeson (born 20 May 1992) is an Irish actor who has worked in television and film. He has a minor role in the film Batman Begins and received a number of outstanding reviews for his lead role in the film All Good Children, with Variety describing him as 'the pic's big discovery.'";
                file = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Pictures\GoT_5.png"));
                person.Picture = await file.AsByteArray();
                i = db.People.Add(person);

                db.SaveChanges();
            }
        }

        internal static List<Person> GetAllPersons()
        {
            using (var db = new PersonContext())
            {
                return db.People.ToList();
            }
        }

        internal static Person GetPersonById(int id)
        {
            using (var db = new PersonContext())
            {
                return (from p in db.People
                        where p.Id.Equals(id)
                        select p).FirstOrDefault();
            }
        }

        internal static void SavePerson(Person model)
        {
            using (var db = new PersonContext())
            {
                if (model.Id > 0)
                {
                    db.Attach(model);
                    db.Update(model);
                }
                else
                {
                    db.Add(model);
                }

                db.SaveChanges();
            }
        }

        internal static void DeletePerson(Person model)
        {
            using (var db = new PersonContext())
            {
                db.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
