using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace KamTu.Models
{
    public class KamTuInitializer : DropCreateDatabaseAlways <KamTuDB>
    {
        protected override void Seed(KamTuDB context) { 
        
            var pedestrians = new List<Pedestrian>
            { new Pedestrian{PersonId= 1, Name="Victor", eMail="victorgil.name", Origin="Navajas", CommunityId=1 },
                new Pedestrian{PersonId= 3, Name="Manolo", eMail="manolo.name", Origin="Navajas", CommunityId=1 }
            
            };
            var drivers = new List<Driver>
            { new Driver{PersonId= 2, Name="Jose", eMail="victorgil.name", Origin="Valencia", CommunityId=1 },
                new Driver{PersonId= 4, Name="Pepe", eMail="pepe.name", Origin="Valencia", CommunityId=1 }
            
            };

            var communities = new List<Community>
            { new Community{CommunityId= 1, Name="CSMD"}
             };

            communities.ForEach(s => context.Communitys.Add(s));
            pedestrians.ForEach(s => context.Pedestrians.Add(s));
            drivers.ForEach(s => context.Drivers.Add(s));
            context.SaveChanges();
        
        }

    }
}