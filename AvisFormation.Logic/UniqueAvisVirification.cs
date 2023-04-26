using AvisFormation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logic
{
    public class UniqueAvisVirification
    {
        public bool EstAutorisesAcommenter(string userId,int formationId) 
        {
            using (var context = new AvisEntities())
            {
                var pers = context.Avis.FirstOrDefault(p => p.UserId == userId && p.IdFormation==formationId);
                if (pers != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
               


            }
        }

    }
}
