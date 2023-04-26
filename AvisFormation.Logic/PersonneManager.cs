using AvisFormation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logic
{
    public class PersonneManager
    {
        public void InsertName(string userId , string userName)
        {
            using (var context = new AvisEntities())
            {
                var pers = context.Personne.FirstOrDefault(p => p.UserId == userId);
                if (pers == null)
                {
                    Personne personne = new Personne { UserId = userId, UserName = userName };
                    context.Personne.Add(personne);
                    context.SaveChanges();
                }

                
            }

        }
        public string GetNameFromUserId( string userId)
        {
            using (var context = new AvisEntities())
            {
                var pers = context.Personne.FirstOrDefault(p => p.UserId == userId);
                if (pers != null)
                {
                    return pers.UserName;
                    
                }
                else
                {
                    return "anonyme";
                }


            }

        }
    }
}
