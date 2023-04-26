﻿using AvisFormation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisFormation.WebUi.Models
{
    public class FormationAvecAvisViewModel
    {
        public string FormationNom { get; internal set; }
        public string FormationDescription { get; internal set; }
        public string FormationNomSeo { get; internal set; }
        public string FormationUrl { get; internal set; }
        public double Note { get; internal set; }
        public int NombreAvis { get; internal set; }
        public List<Avis> FormationAvis { get; internal set; }
       
    }
}